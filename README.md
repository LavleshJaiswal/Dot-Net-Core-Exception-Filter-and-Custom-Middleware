<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dot Net Core: Exception Filters, Model Validation, and Middleware</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 20px;
            padding: 20px;
            background-color: #f9f9f9;
        }
        .container {
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1, h2, h3 {
            color: #333;
        }
        .note {
            margin-top: 20px;
            padding: 10px;
            background-color: #e7f3fe;
            border-left: 4px solid #2196f3;
        }
        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border-radius: 5px;
            overflow-x: auto;
            font-family: Consolas, "Courier New", monospace;
            color: #333;
        }
        code {
            background-color: #f4f4f4;
            padding: 2px 4px;
            border-radius: 4px;
            font-family: Consolas, "Courier New", monospace;
            color: #c7254e;
        }
        ol {
            margin-left: 20px;
        }
    </style>
</head>
<body>
    <h1>Dot Net Core: Exception Filters, Model Validation, and Middleware</h1>

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
    options.Filters.Add<CustomExceptionFilter>();
});
                </pre>
            </li>
            <li>
                <strong>Apply the Filter to Specific Controllers or Actions (Optional)</strong><br>
                Use <code>[ServiceFilter]</code> or <code>[TypeFilter]</code> for specific actions:
                <pre>
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
    options.Filters.Add<ValidateModelFilter>();
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
builder.Services.AddScoped<ValidateModelFilter>();
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
