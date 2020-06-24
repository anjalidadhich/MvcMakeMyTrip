using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class CarController : Controller
    {
        ProductRepository productRepository = new ProductRepository(new Models.ProjectDbContext());
        ProductModel productModel = new ProductModel();
        // GET: Car
        public ActionResult Index()
        {
            var car = productRepository.GetAll().Where(a => a.CatId == 4);
            return View(car);
        }
        [HttpPost]
        public ActionResult Index(Product product)
        {
            var car = productRepository.GetAll().Where(a => a.CatId == 4);
            return View(car);
        }
        public ActionResult CarDetail(int ProId)
        {
            var car = productRepository.GetById(ProId);
            return View(car);
        }
        public ActionResult Booking(int ProId)
        {
            var car = productRepository.GetById(ProId);
            return View(car);
        }

        public ActionResult Search()
        {
            Product data = TempData["mydata"] as Product;
            //return null;
            // Product data = TempData["mydata"] as Product;
            List<Product> product = null;
            if (data.From != null && data.Name != null && data.ArrivingDate != null && data.DepartureDate != null )
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 4) && (a.From == data.From) && (a.Name == data.Name) && (a.ArrivingDate == data.ArrivingDate) && (a.DepartureDate == data.DepartureDate))).ToList();
            }
            else if (data.From != null || data.Name != null || data.ArrivingDate != null || data.DepartureDate != null)
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 4) && ((a.From == data.From) || (a.Name == data.Name) || (a.ArrivingDate == data.ArrivingDate) || (a.DepartureDate == data.DepartureDate)))).ToList();
            }

            productModel.ListProduct = product;
            return View(productModel);
        }
    }
}