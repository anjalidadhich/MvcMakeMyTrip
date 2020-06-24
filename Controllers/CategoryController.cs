using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository(new Models.ProjectDbContext());

        // GET: Repository
        public ActionResult Index()
        {
            var category = categoryRepository.GetAll();
          
            return View(category);
        }

        public ActionResult Edit(int id)
        {
            int CatId = id;
            var category = categoryRepository.GetById(CatId);

            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                categoryRepository.Update(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            int CatId = id;
            var category = categoryRepository.GetById(CatId);

            return View(category);
        }

        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category  category)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    categoryRepository.Create(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
             
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            int CatId = id;
            var e = categoryRepository.GetById(CatId);
            // TODO: Add delete logic here
            categoryRepository.Delete(e);
            return RedirectToAction("Index");


        }
    }
}