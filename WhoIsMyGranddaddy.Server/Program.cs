using WhoIsMyGranddaddy.Data;
using WhoIsMyGranddaddy.Domain;
using WhoIsMyGranddaddy.Server.Attributes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    // Registering the global exception handler attribute
    options.Filters.Add(new GlobalExceptionHandlerAttribute());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Using the CORS service by specify the origin URL
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder => policyBuilder.WithOrigins("https://127.0.0.1:4200")
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
