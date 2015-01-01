using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDirectory.Services;

namespace WebApplication1.Controllers.API
{
    public class CompanyTypeController : ApiController
    {
        private ICompanyTypeService _companyTypeService;
        public CompanyTypeController(ICompanyTypeService iCompanyTypeService)
        {


            _companyTypeService = iCompanyTypeService;
        }
        // GET api/categoryarea
        public IEnumerable<CompanyType> Get()
        {
            return _companyTypeService.GetAllCompanyType();
        }

        // GET api/categoryarea/5
        public CompanyType Get(int id)
        {
            return _companyTypeService.FindById(id);
        }

        // POST api/categoryarea
        public CompanyType Post(CompanyType CompanyType)
        {
            _companyTypeService.AddCompanyType(CompanyType);
            return CompanyType;
        }

        // PUT api/categoryarea/5
        public CompanyType Put(CompanyType CompanyType)
        {
            if (!_companyTypeService.EditCompanyType(CompanyType))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return CompanyType;
        }

        // DELETE api/categoryarea/5
        public CompanyType Delete(int id)
        {
            CompanyType c = _companyTypeService.FindById(id);
            _companyTypeService.DeleteCompanyType(c);
            return c;
        }
    }
}
