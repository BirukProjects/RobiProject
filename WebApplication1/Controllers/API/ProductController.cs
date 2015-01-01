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
    public class ProductController : ApiController
    {
        private ICompanyProductServiceService _companyProductServiceService;
        public ProductController(ICompanyProductServiceService iCompanyProductServiceService)
        {


            _companyProductServiceService = iCompanyProductServiceService;
        }
        // GET api/categoryarea
        public IEnumerable<CompanyProductService> Get()
        {
            return _companyProductServiceService.GetAllCompanyProductService();
        }

        // GET api/categoryarea/5
        public CompanyProductService Get(int id)
        {
            return _companyProductServiceService.FindById(id);
        }

        // POST api/categoryarea
        public CompanyProductService Post(CompanyProductService productCategory)
        {
            _companyProductServiceService.AddCompanyProductService(productCategory);
            return productCategory;
        }

        // PUT api/categoryarea/5
        public CompanyProductService Put(CompanyProductService productCategory)
        {
            if (!_companyProductServiceService.EditCompanyProductService(productCategory))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return productCategory;
        }

        // DELETE api/categoryarea/5
        public CompanyProductService Delete(int id)
        {
            CompanyProductService c = _companyProductServiceService.FindById(id);
            _companyProductServiceService.DeleteCompanyProductService(c);
            return c;
        }
    }
}
