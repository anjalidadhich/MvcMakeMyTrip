using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class CityController : Controller
    {
        StateRepository stateRepository = new StateRepository(new Models.ProjectDbContext());
        CountryRepository countryRepository = new CountryRepository(new Models.ProjectDbContext());
        CityRepository cityRepository = new CityRepository(new Models.ProjectDbContext());
        // GET: Repository
        public ActionResult Index()
        {
            var city = cityRepository.GetAll();
            return View(city);
        }

        public ActionResult Edit(int id)
        {
            int StateId = id;
            var state = cityRepository.GetById(StateId);

            var CountryList = countryRepository.GetAll().ToList();
            var StateList = stateRepository.GetAll().ToList();
            //Creating ViewBag named BrandListItem to used in VIEW.  
            ViewBag.CountryList = ToSelectList(CountryList);
            ViewBag.StateList = ToSelectList1(StateList);


            return View(state);
        }

        [NonAction]
        public SelectList ToSelectList(List<Country> lstCountry)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Country item in lstCountry)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.CountryName,
                    Value = Convert.ToString(item.ConId)
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [NonAction]
        public SelectList ToSelectList1(List<State> lstState)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (State item in lstState)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.StateName,
                    Value = Convert.ToString(item.StateId)
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        [HttpPost]
        public ActionResult Edit(City city)
        {
            try
            {
                cityRepository.Update(city);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            int StateId = id;
            var state = cityRepository.GetById(StateId);

            return View(state);
        }

        public ActionResult Create()
        {
            var state = stateRepository.GetAll();
            IEnumerable<SelectListItem> items1 = state.Select(c => new SelectListItem
            {
                Value = (c.StateId).ToString(),
                Text = c.StateName

            });
            ViewBag.StateList = items1;
            return View();
        }
        [HttpPost]
        public ActionResult Create(City city)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    cityRepository.Create(city);
                    return RedirectToAction("Index");
                }
                return View(city);
            }
            catch
            {
             
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            int CityId = id;
            var e = cityRepository.GetById(CityId);
            // TODO: Add delete logic here
            cityRepository.Delete(e);
            return RedirectToAction("Index");


        }
    }
}