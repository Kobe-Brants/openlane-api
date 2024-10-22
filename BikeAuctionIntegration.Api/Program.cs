
using BikeAuctionIntegration.Api.Configurations;
using BikeAuctionIntegration.BL;
using Hellang.Middleware.ProblemDetails;

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterServices();

builder.ConfigureCors();
builder.ConfigureSwagger();
builder.ConfigureAutoMapper();
builder.ConfigureProblemDetail();

builder.Services.AddControllers();

var app = builder.Build();

if (builder.Configuration.GetValue<bool>("EnableSwagger"))
    app.UseSwaggerConfig();

app.UseProblemDetails();
app.UseCors();

app.MapControllers();
app.MapControllers();

app.Run();