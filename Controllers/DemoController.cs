using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class DemoController : Controller
    {
      CityRepository cityRepository = new CityRepository(new Models.ProjectDbContext());
        // GET: Demo
        public ActionResult Index()
        {
            var city = cityRepository.GetAll();
            IEnumerable<SelectListItem> items1 = city.Select(c => new SelectListItem
            {
                Value = (c.CityId).ToString(),
                Text = c.CityName

            });
            ViewBag.CityList = items1;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product product,string CatId)
        {

            TempData["mydata"] = product;
           // if (product.CheckInDate != null && product.CheckOutDate != null && product.NoOfPeople != null && product.NoOfRoom != null && product.Name != null)
            if(CatId=="1")
            {
                return RedirectToAction("Search", "Hotel");
            }
            else if (CatId == "3")
            {
                return RedirectToAction("Search", "Flight");
            }
            else
            {
                return RedirectToAction("Search", "Car");
            }
        }

        [HttpPost]
        public JsonResult City(string Prefix)
        {
            //Note : you can bind same list from database  
             List<City> ObjList1 = cityRepository.GetAll().ToList();
        //    List<City> ObjList = new List<City>()
        //    {

        //        new City {CityId=1,CityName="Latur" },
        //        new City {CityId=2,CityName="Mumbai" },
        //        new City {CityId=3,CityName="Pune" },
        //        new City {CityId=4,CityName="Delhi" },
        //        new City {CityId=5,CityName="Dehradun" },
        //        new City {CityId=6,CityName="Noida" },
        //        new City {CityId=7,CityName="New Delhi" }

        //};

            //  Searching records from list using LINQ query
            //var CityList = (from N in ObjList
            //                where N.CityName.StartsWith(Prefix)
            //                select new { N.CityName });

            //var CityList = (from N in ObjList1
            //                where N.CityName.StartsWith(Prefix)
            //                select N.CityName );
            var CityList = from N in ObjList1
                            where N.CityName.StartsWith(Prefix)
                            select N;
            //  var CityList=
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
    }
}