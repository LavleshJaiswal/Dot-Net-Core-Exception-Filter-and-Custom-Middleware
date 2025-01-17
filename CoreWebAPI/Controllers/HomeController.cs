using CoreWebAPI.Filters;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace CoreWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{

    [Route("lav"), HttpGet]
    public IActionResult Name()
    {
        return Ok(new { data = "lavlesh", Mobile = "09348354645" });
    }
    [HttpGet, Route("gettotalbylavlesh")]
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
}

