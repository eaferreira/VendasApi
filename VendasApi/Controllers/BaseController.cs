using Microsoft.AspNetCore.Mvc;
using VendasApi.Services;

namespace VendasApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
