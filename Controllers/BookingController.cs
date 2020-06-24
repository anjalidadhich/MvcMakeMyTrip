using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class BookingController : Controller
    {
        ProductModel productModel = new ProductModel();
        BookingDetailRepository bookingDetailRepository = new BookingDetailRepository(new Models.ProjectDbContext());
        CategoryRepository categoryRepository = new CategoryRepository(new Models.ProjectDbContext());
        // GET: Booking
        public ActionResult Index()
        {
            
            //if (CatId!=null)
            //{
                var list = bookingDetailRepository.GetAll();
                productModel.ListBookingDetail = list;
            //}
            //else
            //{
            //    int ID = 0;
            //    var list1 = bookingDetailRepository.GetById(ID);
            //    productModel.ListBookingDetail = list1;
            //}
            var category = categoryRepository.GetAll();
            ViewBag.CategoryList = category;
            IEnumerable<SelectListItem> items = category.Select(c => new SelectListItem
            {
                Value = (c.CatId).ToString(),
                Text = c.CatName

            });
            ViewBag.CategoryList = items;

            return View(productModel);
           // return PartialView("_Booking");
        }

        //public ActionResult BookingDetailOnBasisOfCatId(int ProId)
        //{
        //    var product = productRepository.GetById(ProId);
        //    productModel.Product = product;
        //    IEnumerable<SelectListItem> StateList = stateRepository.GetAll().Where(x => x.ConId == 1).Select(c => new SelectListItem

        //    {
        //        Value = (c.StateId).ToString(),
        //        Text = c.StateName

        //    });
        //    ViewBag.StateList = StateList;
        //    ViewBag.CitySelectList = null;

        //    return View(productModel);
        //}

    }
}