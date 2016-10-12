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
using SaudaWebAPI4.Models;

namespace SaudaWebAPI4.Controllers
{
    public class ListHeadersController : ApiController
    {
        private saudadbEntities db = new saudadbEntities();

        // GET: api/ListHeaders
        public IQueryable<ListHeader> GetListHeaders()
        {
            return db.ListHeaders;
        }

        // GET: api/ListHeaders/5
        [ResponseType(typeof(ListHeader))]
        public IHttpActionResult GetListHeader(int id)
        {
            ListHeader listHeader = db.ListHeaders.Find(id);
            if (listHeader == null)
            {
                return NotFound();
            }

            return Ok(listHeader);
        }

        // PUT: api/ListHeaders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListHeader(int id, ListHeader listHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listHeader.ListHeaderID)
            {
                return BadRequest();
            }

            db.Entry(listHeader).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListHeaderExists(id))
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

        // POST: api/ListHeaders
        [ResponseType(typeof(ListHeader))]
        public IHttpActionResult PostListHeader(ListHeader listHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListHeaders.Add(listHeader);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listHeader.ListHeaderID }, listHeader);
        }

        // DELETE: api/ListHeaders/5
        [ResponseType(typeof(ListHeader))]
        public IHttpActionResult DeleteListHeader(int id)
        {
            ListHeader listHeader = db.ListHeaders.Find(id);
            if (listHeader == null)
            {
                return NotFound();
            }

            db.ListHeaders.Remove(listHeader);
            db.SaveChanges();

            return Ok(listHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListHeaderExists(int id)
        {
            return db.ListHeaders.Count(e => e.ListHeaderID == id) > 0;
        }
    }
}