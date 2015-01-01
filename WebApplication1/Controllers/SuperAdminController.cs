using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebDirectory.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class SuperAdminController : Controller
    {
        //
        // GET: /SuperAdmin/
        private ApplicationDbContext db = new ApplicationDbContext(); 
        
        private ICategoryAreaService _categoryAreaService;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult TempUsers()
        {
            return View();
        }
        public ActionResult AddNewUser()
        {
            return PartialView("_AddUser");
        }

        public ActionResult ShowUsers()
        {
            return PartialView("_ShowUsers");
        }

        public ActionResult EditUser()
        {
            return PartialView("_EditUser");
        }

        public ActionResult DeleteUser()
        {
            return PartialView("_DeleteUser");
        }
        public ActionResult CatTreeView()
        {
            return View();
        }
        public ActionResult GetCompanyCategory()
        {
            var categoryAreaList = _categoryAreaService.GetAllCategoryArea();
            var categoryAreaViewModel = GetCategoryViewModel(categoryAreaList);

            return Json(categoryAreaViewModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUsersList()
        {
            var Db = new ApplicationDbContext();
            var users = Db.Users;
            //ViewModel will be posted at the end of the answer
            var model = new List<EditUserViewModel>();
            foreach (var user in users)
            {
                var u = new EditUserViewModel(user);
                model.Add(u);
            }
            return View(model);
           
        }
        private IEnumerable<CategoryTreeVeiw> GetCategoryViewModel(IEnumerable<CategoryArea> categoryAreas)
        {
            return (from categoryArea in categoryAreas
                    select new CategoryTreeVeiw()
                    {
                        CategoryID = Convert.ToInt32( categoryArea.CategoryID),
                        CategoryName = categoryArea.Category.Category1,
                        CategoryAreaId = categoryArea.CategoryAreaId,
                        CategoryAreaName = categoryArea.CategoryName,
                        IconPath = categoryArea.IconPath

                    }).Take(10);

        }
	}
}