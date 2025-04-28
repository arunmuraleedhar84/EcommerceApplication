using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace ProductService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        //v{version:apiVersion}/
    }
}
