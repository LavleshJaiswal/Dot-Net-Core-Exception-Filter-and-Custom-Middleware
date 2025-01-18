# Dot-Net-Core-Exception-Filter-and-Custom-Middleware
Create Exception Filter, Custom Middleware,and Globally model validation handler in Dot net 6.
Steps to Implement Exception Filter
1. Create a Custom Exception Filter<br>
        Exception Filter: Create a custom class that implements the IExceptionFilter interface from Microsoft.AspNetCore.Mvc.Filters
        <li>. Register the Filter Globally
           To apply the filter globally, you can register it in the Program.cs file, depending on the structure of your project.
               ** builder.Services.AddControllers(options =>
                {
                    options.Filters.Add<CustomExceptionFilter>(); // Register the filter globally
                });**
   </li>
        ii. Apply the Filter to Specific Controllers or Actions (Optional)
              If you only want to apply the filter to specific controllers or actions, decorate them with the [ServiceFilter] or [TypeFilter] attribute.
                   [HttpGet, Route("gettotal-cal")]
                   [TypeFilter(typeof(CustomExceptionFilter))]
                   public IActionResult GetTotalCal()
                 {
                     int totlamount = 10;
                     int aftercal = totlamount / 0;
                     return Ok(aftercal);
                 }
        iii. Test the Implementation
                Start the application and invoke an endpoint where an exception occurs.
                Verify that the custom error response is returned instead of the default error page.

 
