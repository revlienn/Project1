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
        public async Task<ActionResult<ServiceResponse<Project>>> AddNew(Project newProject)
        {   
            var addedProject=await _projectService.AddNew(newProject);
            if(addedProject.Data==null)
            {
                return Conflict(addedProject);
            }
            return Ok(addedProject);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Project>>> Update(Project updatedProject)
        {
            var checkProject=await _projectService.Update(updatedProject);
            if(checkProject.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(checkProject);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Project>>>> Delete(int id)
        {
            var toDelete=await _projectService.Delete(id);
            if(toDelete.Data==null)
            {
                return StatusCode(404,"Id Not Found");
            }
            return Ok(toDelete);
        }

        [HttpGet("All")]
        public async Task<ActionResult<ServiceResponse<List<Project>>>> GetAll()
        {
            return Ok(await _projectService.GetAll());
        }

        [HttpGet("ById")]
        public async Task<ActionResult<ServiceResponse<Project>>> GetById(int id)
        {
            var checkId=await _projectService.GetById(id);
            if(checkId.Data==null)
            {
                return NotFound(checkId);
            }
            return Ok(checkId);
        }

        [HttpGet("ByName")]
        public async Task<ActionResult<ServiceResponse<List<Project>>>> GetByName(string name)
        {
            var matchedProjects=await _projectService.GetByName(name);
            if (matchedProjects.Data==null)
            {
                return NotFound(matchedProjects);
            }
            return matchedProjects;
        }
    }
}