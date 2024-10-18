using HealthcareAppointment.Bussiness;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// JWT Authentication configuration
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourdomain.com", // Can be replace 
        ValidAudience = "yourdomain.com", // Can be replace 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret_key")) // Replace with a secret key
    };
});

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS-Allow", policy =>
    {
        policy.WithOrigins("https://localhost:7066", "http://localhost:8080")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("CORS-Allow");

// Enable Authentication and Authorization Middleware
app.UseAuthentication();  // This must be added before UseAuthorization
app.UseAuthorization();
app.UseMiddleware<CustomAuthorizationMiddleware>();

app.MapControllers();

app.Run();
