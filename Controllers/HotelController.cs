using RoleBasedAuthanticationInMvc.Models;
//using System.Data.Linq.SqlClient;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class HotelController : Controller
    {
        ProductRepository productRepository = new ProductRepository(new Models.ProjectDbContext());
        ProductModel productModel = new ProductModel();
        BookingDetailRepository bookingDetailRepository = new BookingDetailRepository(new Models.ProjectDbContext());
        StateRepository stateRepository = new StateRepository(new Models.ProjectDbContext());
        CityRepository cityRepository = new CityRepository(new Models.ProjectDbContext());

        // GET: Hotel
        public ActionResult Index()
        {
           List<Product> product = productRepository.GetAll().Where(a=>a.CatId==1).ToList();
          
            productModel.ListProduct = product;
            

            return View(productModel);
        }
        [HttpPost]
        public ActionResult Index(ProductModel productModel)
        {
           var products = productRepository.GetAll().Where(a => a.CatId == 1);
            
           //  List<Product> product = products.Where(c => SqlMethods.Like(c.Name, "john")).ToList();
             List<Product> product = products.Where(c => c.Name.Contains(productModel.Name)).ToList();
            productModel.ListProduct = product;
            return View(productModel);
        }
            public ActionResult HotelDetail(int ProId)
        {
            var product = productRepository.GetById(ProId);
            return View(product);
        }
        public ActionResult Booking(int ProId)
        {
            var product = productRepository.GetById(ProId);
            productModel.Product = product;
            IEnumerable<SelectListItem> StateList = stateRepository.GetAll().Where(x => x.ConId == 1).Select(c => new SelectListItem

            {
                Value = (c.StateId).ToString(),
                Text = c.StateName

            });
            ViewBag.StateList = StateList;
            ViewBag.CitySelectList = null;

            return View(productModel);
        }
        [HttpPost]
        public ActionResult Booking(ProductModel productModel)
        {
            var product = productRepository.GetById(productModel.Product.ProId);
            productModel.BookingDetail.CatId = product.CatId;
            productModel.BookingDetail.ProId = productModel.Product.ProId;
            productModel.BookingDetail.ArrivingDate = DateTime.UtcNow;
            productModel.BookingDetail.DepartureDate = DateTime.UtcNow;           
            productModel.BookingDetail.Extra = "";
            bookingDetailRepository.Create(productModel.BookingDetail);
            return RedirectToAction("Index");

        }


        public ActionResult Search()
        {
            Product data = TempData["mydata"] as Product;
            List<Product> product = null ;
            if (data.CheckInDate != null && data.CheckOutDate != null && data.NoOfPeople != null && data.NoOfRoom !=null && data.CityId != 0)
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 1) && (a.CityId == data.CityId) && (a.NoOfRoom == data.NoOfRoom) && (a.NoOfPeople == data.NoOfPeople) && (a.CheckOutDate == data.CheckOutDate) && (a.CheckInDate == data.CheckInDate))).ToList();
            }
            else if(data.CheckInDate != null || data.CheckOutDate != null || data.NoOfPeople != null || data.NoOfRoom != null || data.CityId != 0)
            {
                product = productRepository.GetAll().Where(a => ((a.CatId == 1) && ((a.CityId == data.CityId) || (a.NoOfRoom == data.NoOfRoom) || (a.NoOfPeople == data.NoOfPeople) || (a.CheckOutDate == data.CheckOutDate) || (a.CheckInDate == data.CheckInDate)))).ToList();
            }
            //  List<Product> product = products.Where(c => SqlMethods.Like(c.Name, "john")).ToList();
            // List<Product> product = products.Where(c => c.Name.Contains(productModel.Name)).ToList();
            productModel.ListProduct = product;
            return View(productModel);
        }

        [HttpGet]
        public JsonResult FillCity(int StateId)
        {
            ViewBag.StateCityList = StateId;
            ViewBag.NewlegalEntity = 1;


            IEnumerable<SelectListItem> CityList = cityRepository.GetAll().Where(x => x.StateId == StateId).Select(c => new SelectListItem

            {
                Value = (c.CityId).ToString(),
                Text = c.CityName

            });
            ViewBag.StateList = CityList;



            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
    }
}