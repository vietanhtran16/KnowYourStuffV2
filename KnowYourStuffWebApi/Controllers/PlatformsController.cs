using System.Threading.Tasks;
using KnowYourStuffCore.Dtos;
using KnowYourStuffCore.Interfaces;
using KnowYourStuffWebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KnowYourStuffWebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepo;
        public PlatformsController(IPlatformRepository platformRepository)
        {
            _platformRepo = platformRepository;
        }
        
        [HttpPost]
        public async Task<ActionResult<PlatformRead>> CreatePlatform(NewPlatform platform)
        {
            var createdPlatform = await _platformRepo.CreatePlatform(platform.ToPlatform());
            var platformRead = new PlatformRead(createdPlatform);
            return Created("/", platformRead);
        }
    }
}