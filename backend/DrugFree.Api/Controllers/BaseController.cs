using Microsoft.AspNetCore.Mvc;

namespace DrugFree.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected ActionResult<T> HandleResult<T>(T? result)
    {
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }
    
    protected ActionResult HandleResult(bool success)
    {
        if (!success)
            return BadRequest();
            
        return Ok();
    }
} 