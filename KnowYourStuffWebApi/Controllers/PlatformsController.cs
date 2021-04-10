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
        
        [HttpGet("{id}", Name = "GetPlatform")]
        public async Task<ActionResult<PlatformRead>> GetPlatform(Guid id)
        {
            try
            {
                var platformRead = await _platformService.GetPlatform(id);
                return Ok(platformRead);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<PlatformRead>> CreatePlatform(NewPlatform platform)
        {
            try
            {
                var platformRead = await _platformService.Create(platform);
                return CreatedAtRoute(nameof(GetPlatform), new { platformRead.Id }, platformRead);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("{platformId}/Tips")]
        public async Task<ActionResult<List<TipRead>>> GetTipsByPlatform(Guid platformId)
        {
            var tipsRead = await _platformService.GetTipsByPlatform(platformId);
            return tipsRead;
        }

        [HttpPost("{platformId}/Tips")]
        public async Task<ActionResult<TipRead>> AddTipToPlatform(Guid platformId, NewTip newTip)
        {
            newTip.PlatformId = platformId;
            try
            {
                var createdTip = await _platformService.AddTipToPlatform(newTip);
                return Created("/", createdTip);
            }
            catch (NotFoundException exception)
            {
                return NotFound(exception.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}