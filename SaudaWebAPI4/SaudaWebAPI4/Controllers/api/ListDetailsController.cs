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
    public class ListDetailsController : ApiController
    {
        private saudadbEntities db = new saudadbEntities();

        // GET: api/ListDetails
        public IQueryable<ListDetail> GetListDetails()
        {
            return db.ListDetails;
        }

        // GET: api/ListDetails/5
        [ResponseType(typeof(ListDetail))]
        public IHttpActionResult GetListDetail(int id)
        {
            ListDetail listDetail = db.ListDetails.Find(id);
            if (listDetail == null)
            {
                return NotFound();
            }

            return Ok(listDetail);
        }

        // PUT: api/ListDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListDetail(int id, ListDetail listDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listDetail.ListDetailID)
            {
                return BadRequest();
            }

            db.Entry(listDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListDetailExists(id))
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

        // POST: api/ListDetails
        [ResponseType(typeof(ListDetail))]
        public IHttpActionResult PostListDetail(ListDetail listDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListDetails.Add(listDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listDetail.ListDetailID }, listDetail);
        }

        // DELETE: api/ListDetails/5
        [ResponseType(typeof(ListDetail))]
        public IHttpActionResult DeleteListDetail(int id)
        {
            ListDetail listDetail = db.ListDetails.Find(id);
            if (listDetail == null)
            {
                return NotFound();
            }

            db.ListDetails.Remove(listDetail);
            db.SaveChanges();

            return Ok(listDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListDetailExists(int id)
        {
            return db.ListDetails.Count(e => e.ListDetailID == id) > 0;
        }
    }
}