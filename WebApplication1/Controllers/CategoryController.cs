using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDirectory.Services;
using Microsoft.AspNet.Identity;
using Data.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    //[Authorize(Roles="Admin")]
    public class CategoryController : Controller
    {

        private IAspNetUserService _adminUserService;
        private ICategoryAreaService _categoryAreaService;
        private ICategoryService _categoryService;
        public CategoryController(ICategoryAreaService categoryAreaService, ICategoryService categoryService, IAspNetUserService iAspNetUserService)
        {


            _categoryAreaService = categoryAreaService;
              
            _categoryService = categoryService;
            _adminUserService = iAspNetUserService;
        }
        public ActionResult Index()
        {
            var categorArea = _categoryAreaService.GetAllCategoryArea();
            return View(categorArea);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {

            var categorArea = new CategoryArea();
            ViewBag.Create = "True";
           
            ViewBag.CategoryID = new SelectList(_categoryService.GetAllCategory(), "CategoryID", "Category1", 0);
               
            return View(categorArea);
        }

        //
        // POST: /Company/Create
        [HttpPost]
        public ActionResult Create(CategoryArea categoryArea)
        {
            try
            {

                _categoryAreaService.AddCategoryArea(categoryArea);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Company/Edit/5
        public ActionResult Edit(int id)
        {
            var categorArea = _categoryAreaService.FindById(id);
            return View(categorArea);
        }

        //
        // POST: /Company/Edit/5
        [HttpPost]
        public ActionResult Edit(CategoryArea categoryArea)
        {
            try
            {

                _categoryAreaService.EditCategoryArea(categoryArea);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        //////////////////  Category contndroller//////////
        #region Category Controller 
        public ActionResult SuperAdmin()
        {
            var categorArea = _categoryAreaService.GetAllCategoryArea();
            return View(categorArea);
        }

        // GET: /Company/Create
        public ActionResult CreateCategory()
        {

            var category = new Category();

           
           

            return View(category);
        }

        //
        // POST: /Company/Create
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            try
            {

                _categoryService.AddCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Company/Edit/5
        public ActionResult EditCategory(int id)
        {
            var categor = _categoryService.FindById(id);
            return View(categor);
        }

        //
        // POST: /Company/Edit/5
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            try
            {

                _categoryService.EditCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GetUserList()
        {

            var userList = _adminUserService.GetAllAspNetUser();
            var UserListViewModel = GetUserListViewModel(userList);

            return Json(UserListViewModel, JsonRequestBehavior.AllowGet);
        }
        private IEnumerable<UserListViewModel> GetUserListViewModel(IEnumerable<AspNetUser> users)
        {
            return (from user in users
                    select new UserListViewModel()
                    {
                        UserName = user.UserName,
                        UserEmail = user.Email,
                       // Package = user.Package,

                    }).Take(10);

        }
        public ActionResult GetCompanyCategory()
        {
            var categoryList = _categoryService.GetAllCategory();
            var categoryViewModel = GetCategoryViewModel(categoryList);

            return Json(categoryViewModel, JsonRequestBehavior.AllowGet);
        }
        private IEnumerable<CategoryViewModel> GetCategoryViewModel(IEnumerable<Category> categories)
        {
            return (from category in categories
                    select new CategoryViewModel()
                    {
                        CategoryID = category.CategoryID,
                        Area = category.Area,
                        Category1 = category.Category1,
                        Subcategory =category.Subcategory

                    }).Take(10);

        }
       

#endregion 
    }
}