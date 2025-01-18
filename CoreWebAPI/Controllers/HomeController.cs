
namespace CoreWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
// To apply all the actions,[remove filter from actions ]
//  [TypeFilter(typeof(CustomExceptionFilter))]

[TypeFilter(typeof(ActionFilters))]
public class HomeController : ControllerBase
{

    [Route("lav"), HttpGet]
    public IActionResult Name()
    {
        return Ok(new { data = "lavlesh", Mobile = "09348354645" });
    }
    [HttpGet, Route("gettotal-cal")]
    [TypeFilter(typeof(CustomExceptionFilter))]
    public IActionResult GetTotalCal()
    {
        int totlamount = 10;
        int aftercal = totlamount / 0;
        return Ok(aftercal);
    }

    [HttpPost("student-register")]
    public IActionResult RegisterStudent([FromBody] Students students)
    {
        return Ok(new { Message = "OK", StatusCode = StatusCodes.Status200OK });

    }
    //[TypeFilter(typeof(ActionFilters))]
    [HttpPost("register-manager")]
    public IActionResult RegisterManager([FromBody] Manage manage)
    {
        return Ok(new { Message = "OK", StatusCode = StatusCodes.Status200OK });
    }
}

