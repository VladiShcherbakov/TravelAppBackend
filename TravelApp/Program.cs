using Microsoft.EntityFrameworkCore;
using TravelApp.Services.TravelInfo;
using TravelApp.Services.TravelPlan;
using TravelApp.TravelApp;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7226/",
                                              "http://localhost:3000",
                                              "http://127.0.0.1:3000",
                                              "https://localhost:3000",
                                              "https://127.0.0.1:3000");
                          policy.AllowAnyHeader();
                          policy.AllowCredentials();
                          policy.WithExposedHeaders("*");
                          policy.AllowAnyMethod();
                      });
});

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddScoped<ITravelPlan, TravelPlan>();
builder.Services.AddScoped<ITravelInfo, TravelInfo>();
builder.Services.AddControllers();
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
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
