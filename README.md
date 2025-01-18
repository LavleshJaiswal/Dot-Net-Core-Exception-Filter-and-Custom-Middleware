<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dot Net Core: Exception Filters, Model Validation, and Middleware</title>
</head>
<body style="font-family: Arial, sans-serif; line-height: 1.6; margin: 20px; padding: 20px; background-color: #f9f9f9;">
    <h1 style="color: #333;">Dot Net Core: Exception Filters, Model Validation, and Middleware</h1>

    <div style="background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);">
        <h2 style="color: #333;">Steps to Implement Exception Filter</h2>
        <ol style="margin-left: 20px;">
            <li>
                <strong>Create a Custom Exception Filter</strong><br>
                Implement a custom class that uses the <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">IExceptionFilter</code> interface from <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">Microsoft.AspNetCore.Mvc.Filters</code>.
            </li>
            <li>
                <strong>Register the Filter Globally</strong><br>
                Add the filter globally in the <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">Program.cs</code> file:
                <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; font-family: Consolas, 'Courier New', monospace; color: #333;">
builder.Services.AddControllers(options =>
{
    options.Filters.Add&lt;CustomExceptionFilter&gt;();
});
                </pre>
            </li>
            <li>
                <strong>Apply the Filter to Specific Controllers or Actions (Optional)</strong><br>
                Use <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">[ServiceFilter]</code> or <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">[TypeFilter]</code> for specific actions:
                <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; font-family: Consolas, 'Courier New', monospace; color: #333;">
[HttpGet]
[Route("gettotal-cal")]
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

        <div style="margin-top: 20px; padding: 10px; background-color: #e7f3fe; border-left: 4px solid #2196f3;">
            <strong>Note:</strong> Combine Exception Filters with Custom Middleware for centralized exception handling.
        </div>

        <h2 style="color: #333;">Steps to Implement Global Model Validation Handler</h2>
        <h3 style="color: #333;">To create a global or controller-level model validation handler in .NET Core 6:</h3>
        <ol style="margin-left: 20px;">
            <li>
                <strong>Create a Custom Action Filter</strong><br>
                Use an action filter to validate models globally or at the controller level.
            </li>
            <li>
                <strong>Register the Filter Globally</strong><br>
                Add the filter in <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">Program.cs</code>:
                <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; font-family: Consolas, 'Courier New', monospace; color: #333;">
builder.Services.AddControllers(options =>
{
    options.Filters.Add&lt;ValidateModelFilter&gt;();
});
                </pre>
            </li>
            <li>
                <strong>Apply the Filter at the Controller Level (Optional)</strong><br>
                Use <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">[ServiceFilter]</code> or <code style="background-color: #f4f4f4; padding: 2px 4px; border-radius: 4px; font-family: Consolas, 'Courier New', monospace; color: #c7254e;">[TypeFilter]</code>:
                <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; font-family: Consolas, 'Courier New', monospace; color: #333;">
[TypeFilter(typeof(ValidateModelFilter))]
[ApiController]
[Route("api/[controller]")]
public class SampleController : ControllerBase
{
    // Controller methods
}
                </pre>
                Ensure the filter is registered:
                <pre style="background-color: #f4f4f4; padding: 10px; border-radius: 5px; overflow-x: auto; font-family: Consolas, 'Courier New', monospace; color: #333;">
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
