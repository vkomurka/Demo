using Microsoft.AspNetCore.Mvc;

namespace Demo.WebApi;

[Route("Api/[controller]")]
[ApiController]
public class ControllerBase : Controller
{
}

