<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dot Net Core Exception Filter and Middleware</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 20px;
            background-color: #f9f9f9;
            color: #333;
        }
        h1 {
            color: #007ACC;
        }
        h2 {
            color: #005C99;
        }
        pre {
            background-color: #f4f4f4;
            border-left: 4px solid #007ACC;
            padding: 10px;
            overflow-x: auto;
        }
        li {
            margin-bottom: 10px;
        }
        code {
            background-color: #eee;
            padding: 2px 4px;
            font-family: Consolas, monospace;
            color: #c7254e;
        }
        .note {
            background-color: #e7f3fe;
            border-left: 4px solid #2196F3;
            padding: 10px;
            margin-top: 20px;
        }
    </style>
</head>
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
</body>
</html>
