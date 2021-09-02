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
using NotifyServer.Models;

namespace NotifyServer.Controllers
{
    public class MedalListsController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/MedalLists
        public IQueryable<MedalList> GetMedalLists()
        {
            return db.MedalLists;
        }

        // GET: api/MedalLists/5
        [ResponseType(typeof(MedalList))]
        public IHttpActionResult GetMedalList(int id)
        {
            MedalList medalList = db.MedalLists.Find(id);
            if (medalList == null)
            {
                return NotFound();
            }
            return Ok(medalList);
        }

        // PUT: api/MedalLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedalList(int id, MedalList medalList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medalList.ID)
            {
                return BadRequest();
            }

            db.Entry(medalList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedalListExists(id))
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

        // POST: api/MedalLists
        [ResponseType(typeof(MedalList))]
        public IHttpActionResult PostMedalList(MedalList medalList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MedalLists.Add(medalList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medalList.ID }, medalList);
        }

        // DELETE: api/MedalLists/5
        [ResponseType(typeof(MedalList))]
        public IHttpActionResult DeleteMedalList(int id)
        {
            MedalList medalList = db.MedalLists.Find(id);
            if (medalList == null)
            {
                return NotFound();
            }

            db.MedalLists.Remove(medalList);
            db.SaveChanges();

            return Ok(medalList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedalListExists(int id)
        {
            return db.MedalLists.Count(e => e.ID == id) > 0;
        }
    }
}