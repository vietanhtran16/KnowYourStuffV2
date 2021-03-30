using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Exceptions;
using KnowYourStuffCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KnowYourStuffWebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformService _platformService;
        public PlatformsController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatformRead>>> GetPlatforms()
        {
            var platformReadDtos = await _platformService.GetPlatforms();
            return Ok(platformReadDtos);
        }
        
        [HttpPost]
        public async Task<ActionResult<PlatformRead>> CreatePlatform(NewPlatform platform)
        {
            try
            {
                var platformRead = await _platformService.Create(platform);
                return Created("/", platformRead);
            }
            catch (MissingPropertyException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}