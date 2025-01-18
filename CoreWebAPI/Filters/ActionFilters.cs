public class ActionFilters : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errorResponse = new
            {
                Message = "Validation failed. Please check the input.",
                Errors = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { Field = x.Key, Errors = x.Value.Errors.Select(e => e.ErrorMessage) }),
                StatusCode = 400
            };
            context.Result = new BadRequestObjectResult(errorResponse);
        }
    }
}
