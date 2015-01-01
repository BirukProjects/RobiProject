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
    public class CategoryAreaController : ApiController
    {
        private ICategoryAreaService _categoryAreaService;
        public CategoryAreaController(ICategoryAreaService iCategoryAreaService)
        {


            _categoryAreaService = iCategoryAreaService;
        }
        // GET api/categoryarea
        public IEnumerable<CategoryArea> Get()
        {
            return _categoryAreaService.GetAllCategoryArea();
        }

        // GET api/categoryarea/5
        public CategoryArea Get(int id)
        {
            return _categoryAreaService.FindById(id);
        }

        // POST api/categoryarea
        public CategoryArea Post(CategoryArea categoryArea)
        {
            _categoryAreaService.AddCategoryArea(categoryArea);
            return categoryArea;
        }

        // PUT api/categoryarea/5
        public CategoryArea Put(CategoryArea categoryArea)
        {
            if (!_categoryAreaService.EditCategoryArea(categoryArea))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return categoryArea;
        }

        // DELETE api/categoryarea/5
        public CategoryArea Delete(int id)
        {
            CategoryArea c = _categoryAreaService.FindById(id);
            _categoryAreaService.DeleteCategoryArea(c);
            return c;
        }
    }
}
