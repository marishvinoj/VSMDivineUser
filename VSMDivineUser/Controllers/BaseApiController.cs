using VSMDivineUser.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace VSMDivineUser.Api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(AuthorizationFilterAttribute))]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}