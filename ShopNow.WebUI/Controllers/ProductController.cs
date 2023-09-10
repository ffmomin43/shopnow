using ShopNow.Model;
using ShopNow.Repository.Common.Repository.Impl;
using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.Common.Repository.Interface;
using System.Web.Mvc;

namespace ShopNow.WebUI.Controllers
{
    public class ProductController : Controller
    {

        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        public ProductController(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository
            )
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository; 
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

            var productModel= productRepository.Get(id);
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
    }
}
