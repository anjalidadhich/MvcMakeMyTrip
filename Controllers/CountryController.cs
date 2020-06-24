using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class CountryController : Controller
    {
        CountryRepository countryRepository = new CountryRepository(new Models.ProjectDbContext());
     
        // GET: Repository
        public ActionResult Index()
        {
            var country = countryRepository.GetAll();
            // var lstCustomers = customerDb.Customers.Include(a => a.City).Include(a => a.State).Include(a => a.Country).ToList();
            return View(country);
        }

        public ActionResult Edit(int id)
        {
            int ConId = id;
            var country = countryRepository.GetById(ConId);

            return View(country);
        }
        [HttpPost]
        public ActionResult Edit(Country country)
        {
            try
            {
                countryRepository.Update(country);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            int ConId = id;
            var country = countryRepository.GetById(ConId);

            return View(country);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Country country)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    countryRepository.Create(country);
                    return RedirectToAction("Index");
                }
                return View(country);
            }
            catch
            {
                // return RedirectToAction("Create");
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            int ConId = id;
            //   countryRepository.Delete(ConId);
            var e = countryRepository.GetById(id);
            // TODO: Add delete logic here
            countryRepository.Delete(e);
            return RedirectToAction("Index");


        }

    }
}