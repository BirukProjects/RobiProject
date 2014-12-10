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

namespace WebApplication1.Controllers
{
    public class UserInfoAPIController : ApiController
    {
        private TheDirDB3Context db = new TheDirDB3Context();

        // GET api/UserInfo
        public IQueryable<AspNetUser> GetUsers()
        {
            return db.AspNetUsers;
        }

        // GET api/UserInfo/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult GetUser(string id)
        {
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return NotFound();
            }

            return Ok(aspnetuser);
        }

        // PUT api/UserInfo/5
        public IHttpActionResult PutUser(string id, AspNetUser aspnetuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aspnetuser.Id)
            {
                return BadRequest();
            }

            db.Entry(aspnetuser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AspNetUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/UserInfo
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult PostUser(AspNetUser aspnetuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AspNetUsers.Add(aspnetuser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AspNetUserExists(aspnetuser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = aspnetuser.Id }, aspnetuser);
        }

        // DELETE api/UserInfo/5
        [ResponseType(typeof(AspNetUser))]
        public IHttpActionResult DeleteUser(string id)
        {
            AspNetUser aspnetuser = db.AspNetUsers.Find(id);
            if (aspnetuser == null)
            {
                return NotFound();
            }

            db.AspNetUsers.Remove(aspnetuser);
            db.SaveChanges();

            return Ok(aspnetuser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AspNetUserExists(string id)
        {
            return db.AspNetUsers.Count(e => e.Id == id) > 0;
        }
    }
}