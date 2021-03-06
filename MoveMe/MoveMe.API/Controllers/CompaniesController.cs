﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MoveMe.API.Data;
using MoveMe.API.Models;

namespace MoveMe.API.Controllers
{
    public class CompaniesController : ApiController
    {
        private MoveMeDataContext db = new MoveMeDataContext();

        // GET: api/Companies
        public IHttpActionResult GetCompanies()
        {
            var resultSet = db.Companys.Select(company => new
            {
                company.CompanyId,
                company.CompanyName,
                company.Telephone,
                company.StreetAddress,
                company.City,
                company.State,
                company.Zip,
                company.Employees,
                company.Radius,
                company.HourlyRate
            });


            return Ok (resultSet);
        }

        // GET: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }

                var resultSet = new
                {
                    company.CompanyId,
                    company.CompanyName,
                    company.Telephone,
                    company.StreetAddress,
                    company.City,
                    company.State,
                    company.Zip,
                    company.Employees,
                    company.Radius,
                    company.HourlyRate
                };


                return Ok(resultSet);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.CompanyId)
            {
                return BadRequest();
            }



            var dbCompany = db.Companys.Find(id);
            dbCompany.CompanyId = company.CompanyId;
            dbCompany.CompanyName = company.CompanyName;
            dbCompany.Telephone = company.Telephone;
            dbCompany.StreetAddress = company.StreetAddress;
            dbCompany.City = company.City;
            dbCompany.State = company.State;
            dbCompany.Zip = company.Zip;
            dbCompany.Employees = company.Employees;
            dbCompany.Radius = company.Radius;
            dbCompany.HourlyRate = company.HourlyRate;
            db.Entry(dbCompany).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var geocoder = new Geocoder.GeocodeService();
            var location = geocoder.GeocodeLocation($"{company.StreetAddress} {company.City} {company.State} {company.Zip}");
            company.Location = DbGeography.FromText($"POINT({location.Longitude} {location.Latitude})");
            

            db.Companys.Add(company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companys.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companys.Remove(company);
            db.SaveChanges();

            var resultSet = new
            {
                company.CompanyId,
                company.CompanyName,
                company.Telephone,
                company.StreetAddress,
                company.City,
                company.State,
                company.Zip,
                company.Employees,
                company.Radius,
                company.HourlyRate
            };


            return Ok(resultSet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companys.Count(e => e.CompanyId == id) > 0;
        }
    }
}