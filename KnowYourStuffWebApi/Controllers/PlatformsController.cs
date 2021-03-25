using KnowYourStuffCore.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KnowYourStuffWebApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        [HttpPost]
        public ActionResult<PlatformRead> CreatePlatform(NewPlatform platform)
        {
            return Ok();
        }
    }
}