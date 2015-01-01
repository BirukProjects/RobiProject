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
    public class CompaniesCategoryController : ApiController
    {
        private ICompaniesCategoryService _companiesCategoryService;
        public CompaniesCategoryController(ICompaniesCategoryService iCompaniesCategoryService)
        {


            _companiesCategoryService = iCompaniesCategoryService;
        }
        // GET api/categoryarea
        public IEnumerable<CompaniesCategory> Get()
        {
            return _companiesCategoryService.GetAllCompaniesCategory();
        }

        // GET api/categoryarea/5
        public CompaniesCategory Get(int id)
        {
            return _companiesCategoryService.FindById(id);
        }

        // POST api/categoryarea
        public CompaniesCategory Post(CompaniesCategory category)
        {
            _companiesCategoryService.AddCompaniesCategory(category);
            return category;
        }

        // PUT api/categoryarea/5
        public CompaniesCategory Put(CompaniesCategory category)
        {
            if (!_companiesCategoryService.EditCompaniesCategory(category))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return category;
        }

        // DELETE api/categoryarea/5
        public CompaniesCategory Delete(int id)
        {
            CompaniesCategory c = _companiesCategoryService.FindById(id);
            _companiesCategoryService.DeleteCompaniesCategory(c);
            return c;
        }
    }
}
