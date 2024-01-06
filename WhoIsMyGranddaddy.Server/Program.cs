using WhoIsMyGranddaddy.Data;
using WhoIsMyGranddaddy.Domain;
using WhoIsMyGranddaddy.Server.Attributes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    // Register the global exception handler attribute
    options.Filters.Add(new GlobalExceptionHandlerAttribute());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policyBuilder => policyBuilder.WithOrigins("https://127.0.0.1:4200") // Add your Angular app's URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddData(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDomain();

var app = builder.Build();

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
