using ShopNow.Model;
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

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IProductImageRepository productImageRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;
        public HomeController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IProductImageRepository productImageRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository
            )
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.productImageRepository = productImageRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        [HttpPost]
        public ActionResult AddToCart(int id)
        {
            var productId = id;
            var CurrentCustomer = this.customerRepository.Get(((Customer)Session["Customer"]).Id);

            var currentProduct = productRepository.Get(productId);
            var order = this.orderRepository.CheckOrderExistence(CurrentCustomer.Id);
            OrderDetail orderDetail = new OrderDetail()
            {   
                OrderedQuantity = 1,
                Product = currentProduct
            };
            if (order!=null)
            {
                orderDetail.Order=order;
                this.orderDetailRepository.Insert(orderDetail);
            }
             else
            {
                
                Order newOrder = new Order()
                {
                    CreatedDate = DateTime.Now,
                    //Customer = CurrentCustomer,
                    Status = Model.Common.Enum.OrderStatus.Draft
                    
                };
                //this.orderRepository.Insert(newOrder);
                orderDetail.Order=newOrder;
                this.orderDetailRepository.Insert(orderDetail);
                
            }
            var productObject = productRepository.Get(productId);
            if( productObject == null )
            {
                return View("InvalidRequest");
            }
            

            return View();
        }
        public ActionResult Shop()
        {

            var allProducts = productRepository.GetAll()
                                .Include("ProductImages");
                                
            
            var productBoxItemModelList = (from p in allProducts
                                           select new ProductBoxItemModel()
                                           {
                                               Id = p.Id,
                                               ImageUrl = @"/MyCDN/" + p.ProductImages.FirstOrDefault().ImageUrl,
                                               IsNewBadgeVisible = false,
                                               ProductPrice = p.SalePrice,
                                               ProductTitle = p.ProductTitle
                                           }).OrderByDescending(x => x.Id);

            ViewBag.ProductCount = productBoxItemModelList.Count();

            List<List<ProductBoxItemModel>> finalList = new List<List<ProductBoxItemModel>>();
            int numberOfrows = productBoxItemModelList.Count() % 3 == 0 ?
                productBoxItemModelList.Count() / 3 :
                (productBoxItemModelList.Count() / 3) + 1;
            int count = 0;
            for (int i=1;i<= numberOfrows; i++)
            {
                List<ProductBoxItemModel> products = new List<ProductBoxItemModel>();
                for (int j=1; j<=3 && count<productBoxItemModelList.Count() ;j++)
                {
                    products.Add(productBoxItemModelList.ToArray()[count]);
                    count++;
                }
                finalList.Add(products);
            }
            
            
            return View(finalList);
        }

        // GET: Home
        public ActionResult Index()
        {
            var customerObject = this.customerRepository.Get(1);
            Session["Customer"] = customerObject;

            var currentClientId = System.Web.Configuration.WebConfigurationManager.AppSettings["ClientId"];
            var showSliderInText = System.Web.Configuration.WebConfigurationManager.AppSettings["ShowSlider"];
            var showSliderInList= showSliderInText.Split(',');
            ViewBag.ShowSliderInList = showSliderInList;
            ViewBag.CurrentClientId = currentClientId;

            var allProducts = productRepository.GetAll()
                                .Include("ProductImages")
                                .ToList()
                                .Where(x=>x.ProductImages.Count()>=1);

            //var productImages=productImageRepository.GetAll();

            var productBoxItemModelList = (from p in allProducts                                          
                                           select new ProductBoxItemModel()
                                           {
                                               Id = p.Id,                                               
                                               ImageUrl = @"/MyCDN/" + p.ProductImages.First().ImageUrl,
                                               IsNewBadgeVisible = true,
                                               ProductPrice = p.SalePrice,
                                               ProductTitle = p.ProductTitle
                                           }).OrderByDescending(x=>x.Id).Take(4);



            ViewBag.Products = productBoxItemModelList.ToList();
            return View();
        }
    }
}