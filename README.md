<!DOCTYPE html>
<html lang="en">
 
       
<body>
    <h1>Dot Net Core Exception Filter and Custom Middleware</h1>
    <h2>Steps to Implement Exception Filter</h2>
    <ol>
        <li>
            <strong>Create a Custom Exception Filter</strong><br>
            Exception Filter: Create a custom class that implements the <code>IExceptionFilter</code> interface from <code>Microsoft.AspNetCore.Mvc.Filters</code>.
        </li>
        <li>
            <strong>Register the Filter Globally</strong><br>
            To apply the filter globally, you can register it in the <code>Program.cs</code> file, depending on the structure of your project:
            <pre>
builder.Services.AddControllers(options =>
{
    options.Filters.Add&lt;CustomExceptionFilter&gt;(); // Register the filter globally
});
            </pre>
        </li>
        <li>
            <strong>Apply the Filter to Specific Controllers or Actions (Optional)</strong><br>
            If you only want to apply the filter to specific controllers or actions, decorate them with the <code>[ServiceFilter]</code> or <code>[TypeFilter]</code> attribute:
            <pre>
[HttpGet, Route("gettotal-cal")]
[TypeFilter(typeof(CustomExceptionFilter))]
public IActionResult GetTotalCal()
{
    int totalAmount = 10;
    int afterCal = totalAmount / 0; // This will cause a divide by zero exception
    return Ok(afterCal);
}
            </pre>
        </li>
        <li>
            <strong>Test the Implementation</strong><br>
            Start the application and invoke an endpoint where an exception occurs. Verify that the custom error response is returned instead of the default error page.
        </li>
    </ol>
    <div class="note">
        <strong>Note:</strong> For centralized exception handling across all endpoints, consider combining Exception Filters with Custom Middleware for a complete solution.
    </div>
 
    <h2>Steps to Implement Global Model Validation </h2>
 
</body>
</html>
