using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDirectory.Services;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        private IAspNetUserService _adminUserService;
        // GET api/<controller>
         public UserController( IAspNetUserService iAspNetUserService)
        {

         
            _adminUserService = iAspNetUserService;
        }
        public IEnumerable<AspNetUser> Get()
        {
            return _adminUserService.GetAllAspNetUser();
        }

        // GET api/<controller>/5
        public AspNetUser Get(int id)
        {
            AspNetUser c = _adminUserService.FindById(id);
            if (c == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return c;
        }

        // POST api/<controller>
        public AspNetUser Post(AspNetUser user)
        {
             _adminUserService.AddAspNetUser(user);
            return user;

        }

        // PUT api/<controller>/5
        public AspNetUser Put(AspNetUser user)
        {
            if (!_adminUserService.EditAspNetUser(user))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return user;

        }

        // DELETE api/<controller>/5
        public AspNetUser Delete(int id)
        {
            AspNetUser c = _adminUserService.FindById(id);
            _adminUserService.DeleteAspNetUser(c);
            return c;
        }
    }
    }

