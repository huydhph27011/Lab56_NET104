using Buoi1.IServices;
using Buoi1.Models;
using Buoi1.Services;
using Lab56_Net104.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab56_Net104.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _productService = new ProductService();
        }
        List<Product> lstProductUpdated = new List<Product>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult ShowAll()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (_productService.CreateProduct(product))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public ActionResult ShowListSanPhamDaSua()
        {
            //List<Product> products = new List<Product>();
            //string productsString = _contextAccessor.HttpContext.Session.GetString("lstProductUpdated");

            //products = JsonConvert.DeserializeObject<List<Product>>(productsString);
            List<Product> pros = SesssionService.GetObjFromSession(HttpContext.Session, "LstProducts");
            return View(pros);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var prod = _productService.GetProductById(id);
            lstProductUpdated.Add(prod);
            SesssionService.SetObjToSession(HttpContext.Session, "LstProducts", lstProductUpdated);
            var product = _productService.GetProductById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            //string productsString = JsonConvert.SerializeObject(lstProductUpdated);
            //_contextAccessor.HttpContext.Session.SetString("LstProducts", productsString);
            //pros.Add()
            if (_productService.UpdateProduct(prod))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }


        [HttpPost]
        //public ActionResult Rollback(Guid id)
        //{
        //    //lstProductUpdated.Add(prod);
        //    //string productsString = JsonConvert.SerializeObject(lstProductUpdated);
        //    //_contextAccessor.HttpContext.Session.SetString("LstProducts", productsString);
        //    //SesssionService.SetObjToSession(HttpContext.Session, "LstProducts", lstProductUpdated);
        //    //var sessiondata = HttpContext.Session.GetString("LstProducts");


        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}