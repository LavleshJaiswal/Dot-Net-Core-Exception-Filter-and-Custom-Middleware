using CoreWebAPI.Filters;
using CoreWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(AuthorizeFilter))]
    public class HomeController : ControllerBase
    {

        [Route("lav"),HttpGet]
        public IActionResult Name()
        {
            return Ok(new { data = "lavlesh", Mobile = "09348354645" });
        }


        [HttpGet,Route("gettotalbylavlesh")]
        [ServiceFilter(typeof (CustomExceptionFilter))]
        
        public IActionResult GetTotalCal()
        {
            int totlamount=10;
            int aftercal = totlamount / 0;
            return Ok(aftercal);
        }

        [HttpPost("student-regietr")]
        public IActionResult RegisterStudent([FromBody] Students students)
        {
            if(ModelState.IsValid)
            {
                return Ok(new { Message = "OK", StatusCode = StatusCodes.Status200OK });
            }
            else
            {
              return  BadRequest(new { Message = "Required Parameters Missing",StatusCode=StatusCodes.Status400BadRequest });
            }
        }
    }
    
}
