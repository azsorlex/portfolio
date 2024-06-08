﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Portfolio.Application.Models.DTOs;
using Portfolio.Application.Services.IServices;

namespace Portfolio.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ExperiencesController(IServiceManager serviceManager, ILogger<ExperiencesController> logger) : ControllerBase
    {
        private readonly IServiceManager _serviceManager = serviceManager;
        private readonly ILogger<ExperiencesController> _logger = logger;

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExperienceDTO>), 200)]
        public async Task<IActionResult> GetAllExperiences()
        {
            _logger.LogDebug("Fetching experiences");
            var response = await _serviceManager.ExperienceService.GetAll();
            _logger.LogDebug("Experiences successfully fetched");
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ExperienceDTO), 200)]
        public async Task<IActionResult> GetExperienceById(ObjectId id)
        {
            _logger.LogDebug("Fetching experience with ID {0}", id);
            var response = await _serviceManager.ExperienceService.GetByIds(id);
            _logger.LogDebug("Experience successfully fetched");
            return Ok(response);
        }
    }
}