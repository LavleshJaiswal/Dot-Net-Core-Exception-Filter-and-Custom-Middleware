using CoreWebAPI.Filters;
using CoreWebAPI.MiddleWare;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;

var builder = WebApplication.CreateBuilder(args);

///turn off the default Behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Use for handle model validation 
builder.Services.AddScoped<ActionFilters>();

//use for handle Exception filter on controller level:
builder.Services.AddScoped<CustomExceptionFilter>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ActionFilters());
    options.Filters.Add(new CustomExceptionFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
