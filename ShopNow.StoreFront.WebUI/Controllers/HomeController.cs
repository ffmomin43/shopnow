using ShopNow.Repository.Common.Repository.Intefrace;
using ShopNow.Repository.Common.Repository.Interface;
using ShopNow.StoreFront.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopNow.StoreFront.WebUI.Controllers
{
    public class HomeController : Controller
    {

        private IProductRepository productRepository;
        private ICategoryRepository categoryRepository;
        private IProductImageRepository productImageRepository;
        public HomeController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository
            )
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productImageRepository = productImageRepository;
        }
        // GET: Home
        public ActionResult Index()
        {
            var currentClientId = System.Web.Configuration.WebConfigurationManager.AppSettings["ClientId"];
            var showSliderInText = System.Web.Configuration.WebConfigurationManager.AppSettings["ShowSlider"];
            var showSliderInList= showSliderInText.Split(',');
            ViewBag.ShowSliderInList = showSliderInList;
            ViewBag.CurrentClientId = currentClientId;

            var allProducts = productRepository.GetAll();
            var productImages=productImageRepository.GetAll();

            var productBoxItemModelList = (from p in allProducts
                       join pi in productImages on p.Id equals pi?.Product?.Id
                       select new ProductBoxItemModel()
                       {
                           Id=p.Id,
                           ImageUrl = @"C:\\MyCDN"+pi.ImageUrl,
                           IsNewBadgeVisible = true,
                           ProductPrice = p.SalePrice,
                           ProductTitle = p.ProductTitle
                       }).OrderByDescending(x=>x.Id).Take(4);



            ViewBag.Products = productBoxItemModelList.ToList();
            return View();
        }
    }
}