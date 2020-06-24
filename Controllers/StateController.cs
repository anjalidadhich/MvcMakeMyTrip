using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class StateController : Controller
    {
        StateRepository stateRepository = new StateRepository(new Models.ProjectDbContext());
        CountryRepository countryRepository = new CountryRepository(new Models.ProjectDbContext());
        // GET: Repository
        public ActionResult Index()
        {
            var country = stateRepository.GetAll();
          //  var lstCustomers = customerDb.Customers.Include(a => a.City).Include(a => a.State).Include(a => a.Country).ToList();
            return View(country);
        }

        public ActionResult Edit(int id)
        {
            int StateId = id;
            var state = stateRepository.GetById(StateId);

            var CountryList = countryRepository.GetAll().ToList();
            //Creating ViewBag named BrandListItem to used in VIEW.  
            ViewBag.CountryList = ToSelectList(CountryList);



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
        [HttpPost]
        public ActionResult Edit(State state)
        {
            try
            {
                stateRepository.Update(state);
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
            var state = stateRepository.GetById(StateId);

            return View(state);
        }

        public ActionResult Create()
        {
            var country = countryRepository.GetAll();
            IEnumerable<SelectListItem> items = country.Select(c => new SelectListItem
            {
                Value = (c.ConId).ToString(),
                Text = c.CountryName

            });
            ViewBag.CountryList = items;
            return View();
        }
        [HttpPost]
        public ActionResult Create(State state)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    stateRepository.Create(state);
                    return RedirectToAction("Index");
                }
                return View(state);
            }
            catch
            {
                // return RedirectToAction("Create");
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            int StateId = id;
            //   countryRepository.Delete(ConId);
            var e = stateRepository.GetById(id);
            // TODO: Add delete logic here
            stateRepository.Delete(e);
            return RedirectToAction("Index");


        }
    }
}