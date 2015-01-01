using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Owin.Security;
using System.Web.Http;
using WebApplication1.Models;
using WebDirectory.Services;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        private IAspNetUserService _adminUserService;
        private ApplicationUser userManager;


       
        public UserController(IAspNetUserService iAspNetUserService)
           
        {


            _adminUserService = iAspNetUserService;

        }
        //  
        //public ApplicationUser UserManager
        //{
        //    get
        //    {
        //        return userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUser>();
        //    }
        //    private set
        //    {
        //        userManager = value;
        //    }
        //}
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public IEnumerable<AspNetUser> Get()
        
        {
           // 
          
           //System.Web.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return _adminUserService.GetAllAspNetUser();
        }

        // GET api/<controller>/5
        public  AspNetUser Get(string id)
        {
            AspNetUser c = _adminUserService.FindById(id);
            if (c == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return c;
        }

        // POST api/<controller>
        public  AspNetUser Post(AspNetUser user)
        {

            var user1 = new ApplicationUser() { UserName = user.UserName, Email = user.Email };
            //var a=  HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUser>();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var result =  manager.CreateAsync(user1, "password");
           
            //user.SecurityStamp = Guid.NewGuid().ToString();
            //user.PhoneNumber = "0911306248";
            //user.PasswordHash = _adminUserService.HashPassword("password");
            //_adminUserService.AddAspNetUser(user);
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

