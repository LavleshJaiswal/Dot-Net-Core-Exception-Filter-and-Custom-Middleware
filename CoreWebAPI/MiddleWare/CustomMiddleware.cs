
namespace CoreWebAPI.MiddleWare;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;
    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {

        var stopwa = Stopwatch.StartNew();
        var requredPath = context.Request.Path;
        Console.WriteLine("Code before pass to the next middleware");
        context.Response.Headers.Add("X-ProcessingTime", stopwa.ElapsedMilliseconds.ToString());
        await _next(context);
        stopwa.Stop();
        Console.WriteLine("Code After pass to the next middleware");
    }
}