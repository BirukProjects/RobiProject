using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data.Models;
using WebDirectory.Services;

namespace WebApplication1.Controllers.API
{
    public class CompanyController : ApiController
    {
        private ICompanyService _componyService;
        private IUserService _userService;
        private ICompanyTypeService _compnayTypeService;
        // GET api/Company
        public CompanyController(ICompanyService companyService, IUserService userService, ICompanyTypeService compnayTypeService)
        {
            _componyService = companyService;
            _userService = userService;
            _compnayTypeService = compnayTypeService;
        }
        public IEnumerable<Company> GetCompanies()
        {
            return _componyService.GetAllCompanys();
        }

        // GET api/Company/5
        [ResponseType(typeof(Company))]
        public Company GetCompany(int id)
        {
            Company company =  _componyService.FindByID(id);
            

            return company;
        }

        // PUT api/Company/5
        public Company PutCompany(Company company)
        {
           if (!_componyService.EditCompany(company))
                throw new HttpResponseException(HttpStatusCode.NotFound);

           return company;
           
        }

        // POST api/Company
        [ResponseType(typeof(Company))]
        public Company PostCompany(Company company)
        {

            company.UserCreatorId = 1;
            company.UserOwnerId = 1;
             _componyService.AddCompany(company);
           

            return  company;
        }

        // DELETE api/Company/5
        [ResponseType(typeof(Company))]
        public Company DeleteCompany(int id)
        {
            Company company =  _componyService.FindByID(id);

            _componyService.DeleteCompany(company);
           

            return company;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool CompanyExists(int id)
        //{
        //    return db.Companies.Count(e => e.CompanyId == id) > 0;
        //}
    }
}