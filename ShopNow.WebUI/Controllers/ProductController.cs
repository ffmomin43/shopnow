using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Impl;
using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.Common.Repository.Interface;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace ShopNow.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private IProductImageRepository productImageRepository;
        public ProductController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository
            )
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productImageRepository = productImageRepository;
        }
        // GET: Product
        public ActionResult Index()
        {

            return View(productRepository.GetAll());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View(productRepository.Get(id));
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
            try
            {
                // TODO: Add insert logic here

                productRepository.Insert(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            var productModel = productRepository.Get(id);
            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product newModel)
        {
            try
            {
                // TODO: Add update logic here


                productRepository.Update(newModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(productRepository.Get(id));
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productRepository.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddProductImages(int id)
        {
            var productId = id;

            var product = productRepository.Get(productId);

            ViewBag.Product = product;
            return View(product);

        }

        [HttpPost]
        public ActionResult AddProductImages(int id, HttpPostedFileBase[] UploadImage)
        {


            var product=productRepository.Get(id);
            foreach (var file in UploadImage)
            {
                try
                {
                    // Get the file name and file path.
                    var fileName = file.FileName;
                    string finalFileName = GetGuidFileNameWithExtension(fileName);
                    var filePath = Path.Combine(@"C:\MyCDN", finalFileName);

                    // Create a new FileStream object using the file path.
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        // Write the file contents to the FileStream object.
                        file.InputStream.CopyTo(fileStream);
                    }
                    file.SaveAs(filePath);
                    productImageRepository.Insert(new ProductImage()
                    {
                        AltText = "Test Alt Text",
                        ImageUrl = finalFileName,
                        Product= product
                    });

                }
                catch (System.Exception ex)
                {

                    throw;
                }
            }
            return RedirectToAction("Index");
        }

        private string GetGuidFileNameWithExtension(string fileName)
        {
            if(fileName != null)
            {
                var lastIndex = fileName.LastIndexOf('.');
                var extensionWithDot= fileName.Substring(lastIndex);

                return Guid.NewGuid().ToString() + extensionWithDot;
            }

            return null;
        }
    }
}
