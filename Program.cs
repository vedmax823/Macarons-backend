using System.Text;
using DonMacaron.Data;
using DonMacaron.Repositories;
using DonMacaron.Repositories.AllergenRepository;
using DonMacaron.Repositories.IngredientRepository;
using DonMacaron.Repositories.MacaronRepository;
using DonMacaron.Services;
using DonMacaron.Services.AllergenService;
using DonMacaron.Services.IngredientService;
using DonMacaron.Services.MacaronService;
using DonMacaron.Services.TokenServices;
using DonMacaron.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("http://localhost:5173", "http://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

// builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMacaronService, MacaronService>();
builder.Services.AddScoped<IMacaronRepository, MacaronRepository>();

builder.Services.AddScoped<IAllergenService, AllergenService>();
builder.Services.AddScoped<IAllergenRepository, AllergenRepository>();

builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

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
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSpecificOrigins"); // Apply the CORS policy here

app.UseAuthentication(); // Ensure authentication middleware is before authorization
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseStaticFiles();


app.MapControllers();
// app.Urls.Add("http://0.0.0.0:5000");
app.Run();
