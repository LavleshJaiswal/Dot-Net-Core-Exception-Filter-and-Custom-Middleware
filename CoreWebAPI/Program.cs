var builder = WebApplication.CreateBuilder(args);

///turn off the default Behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


builder.Services.AddControllers(options =>
{
    ///To apply the filter globally, you can register it in the Program.cs file, depending on the structure of your project.
    //1. options.Filters.Add(new ActionFilters());

    //2. options.Filters.Add(new CustomExceptionFilter());
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

//register custom middleware in middleware pipline
app.UseMiddleware<CustomMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
