using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project1.Services.ProjectServices;

namespace Project1.Controllers
{
    [ApiController]
    [Route("Project")]
    public class ProjectController:ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> AddNew(Project newProject)
        {   
            var addedProject=await _projectService.AddNew(newProject);
            if(addedProject==null)
            {
                return StatusCode(409,"Id already exists");
            }
            return Ok(addedProject);
        }

        [HttpPut]
        public async Task<ActionResult<Project>> Update(Project updatedProject)
        {
            var checkProject=await _projectService.Update(updatedProject);
            if(checkProject==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkProject);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Project>>> Delete(int id)
        {
            var toDelete=await _projectService.Delete(id);
            if(toDelete==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<List<Project>>> GetAll()
        {
            return Ok(await _projectService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<Project>> GetById(int id)
        {
            var checkId=await _projectService.GetById(id);
            if(checkId==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<List<Project>>> GetByName(string name)
        {
            var matchedProjects=await _projectService.GetByName(name);
            if (matchedProjects==null)
            {
                return StatusCode(404,"No matching users");
            }
            return matchedProjects;
        }
    }
}