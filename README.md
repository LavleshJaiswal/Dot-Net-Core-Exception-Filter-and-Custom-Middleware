<!DOCTYPE html>
<html lang="en">

 
<body>
    <header>
        <h1>Dot Net Core: Exception Filters, Model Validation, and Middleware</h1>
    </header>

    <div class="container">
        <h2>Steps to Implement Exception Filter</h2>
        <ol>
            <li>
                <strong>Create a Custom Exception Filter</strong><br>
                Implement a custom class that uses the <code>IExceptionFilter</code> interface from <code>Microsoft.AspNetCore.Mvc.Filters</code>.
            </li>
            <li>
                <strong>Register the Filter Globally</strong><br>
                Add the filter globally in the <code>Program.cs</code> file:
                <pre>
builder.Services.AddControllers(options =>
{
    options.Filters.Add&lt;CustomExceptionFilter&gt;();
});
                </pre>
            </li>
            <li>
                <strong>Apply the Filter to Specific Controllers or Actions (Optional)</strong><br>
                Use <code>[ServiceFilter]</code> or <code>[TypeFilter]</code> for specific actions:
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
                Test the filter by invoking an endpoint that raises an exception. Verify the custom error response.
            </li>
        </ol>

        <div class="note">
            <strong>Note:</strong> Combine Exception Filters with Custom Middleware for centralized exception handling.
        </div>

        <h2>Steps to Implement Global Model Validation Handler</h2>
        <h3>To create a global or controller-level model validation handler in .NET Core 6:</h3>
        <ol>
            <li>
                <strong>Create a Custom Action Filter</strong><br>
                Use an action filter to validate models globally or at the controller level.
            </li>
            <li>
                <strong>Register the Filter Globally</strong><br>
                Add the filter in <code>Program.cs</code>:
                <pre>
builder.Services.AddControllers(options =>
{
    options.Filters.Add&lt;ValidateModelFilter&gt;();
});
                </pre>
            </li>
            <li>
                <strong>Apply the Filter at the Controller Level (Optional)</strong><br>
                Use <code>[ServiceFilter]</code> or <code>[TypeFilter]</code>:
                <pre>
[TypeFilter(typeof(ValidateModelFilter))]
[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    // Controller methods
}
                </pre>
                Ensure the filter is registered:
                <pre>
builder.Services.AddScoped&lt;ValidateModelFilter&gt;();
                </pre>
            </li>
            <li>
                <strong>Customizing the Response (Optional)</strong><br>
                Modify the action filter to return custom error responses.
            </li>
            <li>
                <strong>Test Your Validation</strong><br>
                Test the handler with valid and invalid input data.
            </li>
        </ol>
    </div>
</body>

</html>
