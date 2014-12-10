using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDirectory.Services;
using Microsoft.AspNet.Identity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/
        private ICompanyService _componyService;
        private IUserService _userService;
        private ICompanyTypeService _compnayTypeService;

        public CompanyController(ICompanyService companyService, IUserService userService , ICompanyTypeService compnayTypeService)
        {
            _componyService = companyService;
            _userService = userService;
            _compnayTypeService = compnayTypeService;
        }

        public ActionResult Index()
        {
            var companyList = _componyService.GetAllCompanys();
            return View(companyList);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        //
                // GET: /Company/Create
                public ActionResult Create()
                {
                    ViewBag.UserId = new SelectList(_userService.GetAllUsers(), "UserId", "UserEmail");
                    ViewBag.CompanyTypeId = new SelectList(_compnayTypeService.GetAllCompanyType(), "CompanyTypeId", "CompanyTypeName", 0);
                    var company = new Company();
                    return View(company);
                }

                //
                // POST: /Company/Create
                [HttpPost]
                public ActionResult Create(Company company)
                {
                    try
                    {
                        // TODO: Add insert logic here
                        company.CreationDate = DateTime.Now; // set curent date and time insated of accepting form the user and hide on UI
                        company.LastUpdateDate = DateTime.Now; // set curent date and time insated of accepting form the user and hide on UI and udoate when user edit Company
                       // company.UserCreatorId = User.Identity.GetUserId();
                        _componyService.AddCompany(company);

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
                    var compnay = _componyService.FindByID(id);
                    return View(compnay);
                }

                //
                // POST: /Company/Edit/5
                [HttpPost]
                public ActionResult Edit(Company company)
                {
                    try
                    {
                        _componyService.EditCompany(company);

                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
                public ActionResult GetCompany()
                {
                    var companyList = _componyService.GetAllCompanys();
                    var companyViewModel = GetCompanyViewModel(companyList);

                    return Json(companyViewModel, JsonRequestBehavior.AllowGet);
                }
        private IEnumerable<CompanyViewModel> GetCompanyViewModel(IEnumerable<Company> companies)
        {
            return (from company in companies
                    select new CompanyViewModel()
                    {
                        CompanyId = company.CompanyId,
                        CompanyName = company.CompanyName,
                        CompanyWebsite = company.CompanyWebsite,
                        CompanyEmail1 =company.CompanyEmail1,
                        CompanyEmail2 = company.CompanyEmail2,
                        CompanyTelephone = company.CompanyTelephone,
                        CompanyDescription = company.companydescription,
                        UserOwnerName =company.User.UserEmail,
                        CompanyLogoPath = company.CompanyLogoPath,
                        CompanyFoundedDate = company.CompanyFoundedDate,
                        turnover = company.turnover,
                        numberOfEmployees =company.numberOfEmployees,
                        companydescription =company.companydescription,
                        CompanyType = company.CompanyType.CompanyTypeName,
                        LastUpdateDate = company.LastUpdateDate
                      


                    }).Take(10);

        }


	}
}