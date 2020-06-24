using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class FlightController : Controller
    {
        ProductRepository productRepository = new ProductRepository(new Models.ProjectDbContext());
        ProductModel productModel = new ProductModel();
        // GET: Flight
        public ActionResult Index()
        {
            var flight = productRepository.GetAll().Where(a => a.CatId == 3);
            return View(flight);
        }
        public ActionResult FlightDetail(int ProId)
        {
            var flight = productRepository.GetById(ProId);
            return View(flight);
        }
        public ActionResult Booking(int ProId)
        {
            var flight = productRepository.GetById(ProId);
            return View(flight);
        }
        
        public ActionResult Search()
        {
            Product data = TempData["mydata"] as Product;
            //return null;
            // Product data = TempData["mydata"] as Product;
            List<Product> product = null;
            if (data.From != null && data.To != null && data.DepartureDate != null && data.ArrivingDate != null )
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 3) && (a.From == data.From) && (a.To == data.To) && (a.DepartureDate == data.DepartureDate) && (a.ArrivingDate == data.ArrivingDate))).ToList();
            }
            else if (data.From != null || data.To != null || data.DepartureDate != null || data.ArrivingDate != null)
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 3) && ((a.From == data.From) || (a.To == data.To) || (a.DepartureDate == data.DepartureDate) || (a.ArrivingDate == data.ArrivingDate)))).ToList();
            }
           
            productModel.ListProduct = product;
            return View(productModel);
        }
    }
}