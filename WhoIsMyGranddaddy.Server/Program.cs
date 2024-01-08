using Microsoft.AspNetCore.Mvc;
using WhoIsMyGranddaddy.Data;
using WhoIsMyGranddaddy.Domain;
using WhoIsMyGranddaddy.Server.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // Registering the global exception handler attribute
    options.Filters.Add(new GlobalExceptionHandlerAttribute());
}).ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        //Using a custom validation handler for modal binding errors e.g. when a value is required but not populated
        var problems = new ApiModalValidationHandler<object>(context);
        return new BadRequestObjectResult(problems.Value);
    };
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Using the CORS service by specify the origin URL
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder => policyBuilder.WithOrigins(builder.Configuration.GetSection("App").GetValue<string>("FrontendUrl"))
            .AllowAnyHeader()
            .AllowAnyMethod());
});

//Injecting the Data & Domain related services
builder.Services.AddData(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDomain();

var app = builder.Build();

//using the CORS policy
app.UseCors("AllowFrontend");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
