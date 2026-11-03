using ProductServices.DTO.CategoryDTO_s;
using ProductServices.DTO.InventoryDTO_s;
using ProductServices.DTO.ProductDTO_s;
using ProductServices.Models;
using ProductServices.Repositories;
using ProductServices.Repositories.Interfaces;
using ProductServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductServices.Data;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddAutoMapper(config =>
{
    config.CreateMap<Category, CategoryDTO>();
    config.CreateMap<CategoryCreateAndUpdateDTO, Category>();

    config.CreateMap<Product, ProductDTO>()
        .ForMember(
            destination => destination.AvailableQuantity,
            options => options.MapFrom(source =>
                source.Inventory == null
                    ? 0
                    : source.Inventory.AvailableQuantity));
    config.CreateMap<ProductCreateDTO, Product>();
    config.CreateMap<ProductUpdateDTO, Product>();

    config.CreateMap<Inventory, InventoryDTO>()
        .ForMember(
            destination => destination.AvailableQuantity,
            options => options.MapFrom(source =>
                source.AvailableQuantity));
    config.CreateMap<InventoryCreateDTO, Inventory>();
    config.CreateMap<InventoryUpdateDTO, Inventory>();
});

var jwtKey = builder.Configuration["Jwt:Key"];
var jwtEncryptionKey = builder.Configuration["Jwt:EncryptionKey"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrWhiteSpace(jwtKey) ||
    string.IsNullOrWhiteSpace(jwtEncryptionKey) ||
    string.IsNullOrWhiteSpace(jwtIssuer) ||
    string.IsNullOrWhiteSpace(jwtAudience))
{
    throw new InvalidOperationException(
        "JWT configuration is missing. Configure Jwt:Key, Jwt:EncryptionKey, Jwt:Issuer, and Jwt:Audience.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)),

            TokenDecryptionKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtEncryptionKey)),

            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Cookies["access_token"];

                if (!string.IsNullOrWhiteSpace(accessToken))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("ECommerce Product Service");
    });
}

app.UseHttpsRedirection();

app.UseCors("ReactApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();