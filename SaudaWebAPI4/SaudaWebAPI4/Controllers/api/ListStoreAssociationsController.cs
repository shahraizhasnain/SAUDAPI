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
    public class ListStoreAssociationsController : ApiController
    {
        private saudadbEntities db = new saudadbEntities();

        // GET: api/ListStoreAssociations
        public IQueryable<ListStoreAssociation> GetListStoreAssociations()
        {
            return db.ListStoreAssociations;
        }

        // GET: api/ListStoreAssociations/5
        [ResponseType(typeof(ListStoreAssociation))]
        public IHttpActionResult GetListStoreAssociation(int id)
        {
            ListStoreAssociation listStoreAssociation = db.ListStoreAssociations.Find(id);
            if (listStoreAssociation == null)
            {
                return NotFound();
            }

            return Ok(listStoreAssociation);
        }

        // PUT: api/ListStoreAssociations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListStoreAssociation(int id, ListStoreAssociation listStoreAssociation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listStoreAssociation.ListStoreID)
            {
                return BadRequest();
            }

            db.Entry(listStoreAssociation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListStoreAssociationExists(id))
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

        // POST: api/ListStoreAssociations
        [ResponseType(typeof(ListStoreAssociation))]
        public IHttpActionResult PostListStoreAssociation(ListStoreAssociation listStoreAssociation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListStoreAssociations.Add(listStoreAssociation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = listStoreAssociation.ListStoreID }, listStoreAssociation);
        }

        // DELETE: api/ListStoreAssociations/5
        [ResponseType(typeof(ListStoreAssociation))]
        public IHttpActionResult DeleteListStoreAssociation(int id)
        {
            ListStoreAssociation listStoreAssociation = db.ListStoreAssociations.Find(id);
            if (listStoreAssociation == null)
            {
                return NotFound();
            }

            db.ListStoreAssociations.Remove(listStoreAssociation);
            db.SaveChanges();

            return Ok(listStoreAssociation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListStoreAssociationExists(int id)
        {
            return db.ListStoreAssociations.Count(e => e.ListStoreID == id) > 0;
        }
    }
}