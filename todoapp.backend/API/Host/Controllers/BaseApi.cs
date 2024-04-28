using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseApi : ControllerBase
{
}