using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test-connection")]
    public async Task<IActionResult> TestConnection()
    {
        // Your logic here
        return Ok(new { Message = "Connection successful." });
    }
}
