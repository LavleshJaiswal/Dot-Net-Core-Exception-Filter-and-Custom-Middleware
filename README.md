<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dot Net Core: Exception Filters, Model Validation, and Middleware</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            line-height: 1.6;
            background-color: #f9f9f9;
            color: #333;
        }

        header {
            background: #007bff;
            color: white;
            padding: 1rem 0;
            text-align: center;
        }

        h1, h2 {
            margin: 0.5rem 0;
        }

        h1 {
            font-size: 2rem;
        }

        h2 {
            font-size: 1.5rem;
            color: #007bff;
        }

        .container {
            max-width: 800px;
            margin: 2rem auto;
            padding: 1rem;
            background: white;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        ol, ul {
            margin: 1rem 0;
            padding-left: 1.5rem;
        }

        li {
            margin: 0.5rem 0;
        }

        code, pre {
            background: #f4f4f4;
            padding: 0.2rem 0.4rem;
            border-radius: 4px;
            font-family: monospace;
        }

        pre {
            background: #f8f9fa;
            padding: 1rem;
            overflow: auto;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .note {
            background: #e9ecef;
            border-left: 4px solid #007bff;
            padding: 1rem;
            margin-top: 1rem;
            border-radius: 4px;
        }

        .note strong {
            color: #007bff;
        }
    </style>
</head>

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
