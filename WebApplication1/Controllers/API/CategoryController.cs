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
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService iCategoryService)
        {


            _categoryService = iCategoryService;
        }
        // GET api/categoryarea
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAllCategory();
        }

        // GET api/categoryarea/5
        public Category Get(int id)
        {
            return _categoryService.FindById(id);
        }

        // POST api/categoryarea
        public Category Post(Category category)
        {
            _categoryService.AddCategory(category);
            return category;
        }

        // PUT api/categoryarea/5
        public Category Put(Category category)
        {
            if (!_categoryService.EditCategory(category))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return category;
        }

        // DELETE api/categoryarea/5
        public Category Delete(int id)
        {
            Category c = _categoryService.FindById(id);
            _categoryService.DeleteCategory(c);
            return c;
        }
    }
}
