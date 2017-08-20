using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Services;
using backend.Models;

namespace backend.Controllers
{
    [Produces("application/json")]
    [Route("api/organizations")]
    public class OrganizationsController : Controller
    {
        private IBannerStrikesBackRepository _bannerStrikesBackRepository;

        public OrganizationsController(IBannerStrikesBackRepository bannerStrikesBackRepository)
        {
            _bannerStrikesBackRepository = bannerStrikesBackRepository;
        }

        // GET api/organizations
        [HttpGet]
        public IActionResult GetOrganizations()
        {
            return Ok(_bannerStrikesBackRepository.GetOrganizations());
        }

        // GET api/organizations/:code
        [HttpGet("{code}")]
        public IActionResult GetOrganization(string code)
        {
            return Ok(_bannerStrikesBackRepository.GetOrganization(code));
        }

        // POST api/organizations
        [HttpPost]
        public IActionResult Post([FromBody]Organization organization)
        {
            _bannerStrikesBackRepository.AddOrganization(organization);
            if (!_bannerStrikesBackRepository.Save())
            {
                throw new Exception("Creating an organization failed on save.");
            }
            return Ok();
        }

        // PUT api/organizations/:code
        [HttpPut("{code}")]
        public IActionResult Put([FromBody]Organization organization)
        {
            _bannerStrikesBackRepository.UpdateOrganization(organization);
            if (!_bannerStrikesBackRepository.Save())
            {
                throw new Exception("Updating an organization failed on save.");
            }
            return Ok();
        }

        // DELETE api/organizations/:code
        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            _bannerStrikesBackRepository.DeleteOrganization(code);
            _bannerStrikesBackRepository.Save();
            return Ok();
        }

        // PATCH api/organizations
        [HttpPatch("{code}")]
        public IActionResult PartialUpdate(string code)
        {
            return NotFound();
        }
    }
}