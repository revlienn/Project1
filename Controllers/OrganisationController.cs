using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Organisation")]
    public class OrganisationController:ControllerBase
    {
        private List<Organisation> Organisations=new List<Organisation>
        {
            new Organisation()
            {
                Id=1,
                Name="Thames Corporation",
                Phone="020-90909090"
            },
            new Organisation()
            {
                Id=2,
                Name="Big Ben",
                Phone="020-90909090"
            },
            new Organisation()
            {
                Id=3,
                Name="OakTree",
                Phone="020-94638000"
            },
        };

        [HttpGet("ById")]
        public ActionResult<Organisation> GetOrganisationById(int Id)
        {
            return Ok(Organisations.FirstOrDefault(c=>c.Id==Id));
        }

        [HttpGet("All")]
        public ActionResult<List<Organisation>> GetAllOrganisations()
        {
            return Ok(Organisations);
        }

        [HttpGet("ByName")]
        public ActionResult<List<Organisation>> GetOrganisationByName(string name)
        {
            var matchingOrganisation=new List<Organisation>();

            foreach(Organisation organisation in Organisations)
            {
                if(organisation.Name.ToLower().Contains(name))
                {
                    matchingOrganisation.Add(organisation);
                }
            }
            return Ok(matchingOrganisation);
        }

        [HttpPost]
        public ActionResult<List<Organisation>> AddNewOrganisation(Organisation newOrganisation)
        {
            Organisations.Add(newOrganisation);
            return Ok(Organisations);
        }

        [HttpPut]
        public ActionResult<Organisation> Update(Organisation updatedOrganisation)
        {
            var organisation=Organisations.FirstOrDefault(s=>s.Id==updatedOrganisation.Id);
            if(organisation==null)
            {
                return NotFound(organisation);
            }
            if(organisation!=null)
            {
                organisation.Name=updatedOrganisation.Name;
                organisation.Phone=updatedOrganisation.Phone;
            }
            return Ok(organisation);
        }

        [HttpDelete]
        public ActionResult<List<Organisation>> Delete(int id)
        {
            Organisation organisation=Organisations.FirstOrDefault(o=>o.Id==id);

            if(organisation==null)
            {
                return NotFound(organisation);
            }

            Organisations.Remove(organisation);
            return Ok(Organisations);
        }
    }
}