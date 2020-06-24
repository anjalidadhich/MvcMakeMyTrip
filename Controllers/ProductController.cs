using RoleBasedAuthanticationInMvc.Models;
using RoleBasedAuthanticationInMvc.Models.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace RoleBasedAuthanticationInMvc.Controllers
{
    public class ProductController : Controller
    {
      
        CountryRepository countryRepository = new CountryRepository(new Models.ProjectDbContext());
        StateRepository stateRepository = new StateRepository(new Models.ProjectDbContext());
        CityRepository cityRepository = new CityRepository(new Models.ProjectDbContext());
        CategoryRepository categoryRepository = new CategoryRepository(new Models.ProjectDbContext());
        ProductRepository productRepository = new ProductRepository(new Models.ProjectDbContext());
        // GET: Repository
        public ActionResult Index()             
        {
            var product = productRepository.GetAll();
            return View(product);
        }

        public ActionResult Edit(int id)
        {
            int StateId = id;
            var product = productRepository.GetById(StateId);

            var CountryList = countryRepository.GetAll().ToList();
            var StateList = stateRepository.GetAll().ToList();
            var CityList = cityRepository.GetAll().ToList();
            var CategoryList = categoryRepository.GetAll().ToList();
            //Creating ViewBag named BrandListItem to used in VIEW.  
            ViewBag.CountryList = ToSelectList(CountryList);
            ViewBag.StateList = ToSelectListState(StateList);
            ViewBag.CityList = ToSelectListCity(CityList);
            ViewBag.CategoryList = ToSelectListCategory(CategoryList);
            return View(product);
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
        public SelectList ToSelectListState(List<State> lstState)
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
        [NonAction]
        public SelectList ToSelectListCity(List<City> lstCity)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (City item in lstCity)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.CityName,
                    Value = Convert.ToString(item.CityId)
                });
            }

            return new SelectList(list, "Value", "Text");
        }
        [NonAction]
        public SelectList ToSelectListCategory(List<Category> lstCategory)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Category item in lstCategory)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.CatName,
                    Value = Convert.ToString(item.CatId)
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase EventImagePost)
        {
            try
            {
                if (EventImagePost != null && !Regex.IsMatch(EventImagePost.FileName, ".gif$|.jpg$|.jpeg$", RegexOptions.IgnoreCase))
                {
                    ModelState.AddModelError("", "Only valid image files are allowed as post image file");
                }
                else if (EventImagePost != null)
                {

                    string name = Path.GetFileName(EventImagePost.FileName);
                    string path = "~/Content/upload/" + name;

                    //Saving file to Folder
                    EventImagePost.SaveAs(Server.MapPath(path));
                    product.Image = path;

                }
                productRepository.Update(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Details(int id)
        {
            int ProId = id;
            var state = productRepository.GetById(ProId);

            return View(state);
        }

        public ActionResult Create()
        {
            var country = countryRepository.GetAll();
            IEnumerable<SelectListItem> items1 = country.Select(c => new SelectListItem
            {
                Value = (c.ConId).ToString(),
                Text = c.CountryName

            });
            ViewBag.CountryList = items1;

            var category = categoryRepository.GetAll();
            IEnumerable<SelectListItem> items = category.Select(c => new SelectListItem
            {
                Value = (c.CatId).ToString(),
                Text = c.CatName

            });
            ViewBag.CategoryList = items;

            ViewBag.NewlegalEntity = null;
            ViewBag.StateSelectList = null;
            ViewBag.CitySelectList = null;


            return View();
        }
        [HttpGet]
        public JsonResult FillState(int countryId)
        {
            ViewBag.StateSelectList = countryId;
            ViewBag.NewlegalEntity = 1;


            IEnumerable<SelectListItem> StateList = stateRepository.GetAll().Where(x => x.ConId == countryId).Select(c => new SelectListItem

            {
                Value = (c.StateId).ToString(),
                Text = c.StateName

            });
            ViewBag.StateList = StateList;



            return Json(StateList, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult Create(Product product ,HttpPostedFileBase EventImagePost)
        {
            try
            {

                //if (ModelState.IsValid)
                //{
                    //Getting File Details
                    string name = Path.GetFileName(EventImagePost.FileName);
                    string path = "~/Content/upload/" + name;

                //Saving file to Folder
                EventImagePost.SaveAs(Server.MapPath(path));
                    product.Image = path;
                if (product.CatId == 1)
                {
                    product.ArrivingDate = DateTime.UtcNow.Date; ;
                    product.DepartureDate = DateTime.UtcNow.Date; ;
                }
                else
                {
                    product.CheckInDate = DateTime.UtcNow.Date;
                    product.CheckOutDate = DateTime.UtcNow.Date;
                }
             
                productRepository.Create(product);
                    return RedirectToAction("Index");
                //}
                //return View(product);
            }
            catch (Exception e)
            {
               
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            int ProId = id;
            var e = productRepository.GetById(ProId);
            // TODO: Add delete logic here
            productRepository.Delete(e);
            return RedirectToAction("Index");


        }
    }
}