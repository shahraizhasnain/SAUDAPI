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
    public class CustomerStoreRelationsController : ApiController
    {
        private saudadbEntities db = new saudadbEntities();

        // GET: api/CustomerStoreRelations
        public IQueryable<CustomerStoreRelation> GetCustomerStoreRelations()
        {
            return db.CustomerStoreRelations;
        }

        // GET: api/CustomerStoreRelations/5
        [ResponseType(typeof(CustomerStoreRelation))]
        public IHttpActionResult GetCustomerStoreRelation(int id)
        {
            CustomerStoreRelation customerStoreRelation = db.CustomerStoreRelations.Find(id);
            if (customerStoreRelation == null)
            {
                return NotFound();
            }

            return Ok(customerStoreRelation);
        }

        // PUT: api/CustomerStoreRelations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerStoreRelation(int id, CustomerStoreRelation customerStoreRelation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerStoreRelation.CustomerStoreID)
            {
                return BadRequest();
            }

            db.Entry(customerStoreRelation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerStoreRelationExists(id))
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

        // POST: api/CustomerStoreRelations
        [ResponseType(typeof(CustomerStoreRelation))]
        public IHttpActionResult PostCustomerStoreRelation(CustomerStoreRelation customerStoreRelation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerStoreRelations.Add(customerStoreRelation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerStoreRelation.CustomerStoreID }, customerStoreRelation);
        }

        // DELETE: api/CustomerStoreRelations/5
        [ResponseType(typeof(CustomerStoreRelation))]
        public IHttpActionResult DeleteCustomerStoreRelation(int id)
        {
            CustomerStoreRelation customerStoreRelation = db.CustomerStoreRelations.Find(id);
            if (customerStoreRelation == null)
            {
                return NotFound();
            }

            db.CustomerStoreRelations.Remove(customerStoreRelation);
            db.SaveChanges();

            return Ok(customerStoreRelation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerStoreRelationExists(int id)
        {
            return db.CustomerStoreRelations.Count(e => e.CustomerStoreID == id) > 0;
        }
    }
}