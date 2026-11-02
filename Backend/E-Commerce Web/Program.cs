using E_CommerceBTO.Services;
using E_CommerceDTO.Context;
using E_CommerceDTO.DTO.CartItemDTO_s;
using E_CommerceDTO.DTO.CategoryDTO_s;
using E_CommerceDTO.DTO.InventoryDTO_s;
using E_CommerceDTO.DTO.OrderDTO_s;
using E_CommerceDTO.DTO.ProductDTO_s;
using E_CommerceDTO.DTO.UserDTO_s;
using E_CommerceDTO.models;
using E_CommerceDTO.Repositories;
using E_CommerceDTO.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ECommerceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<CartItemService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddAutoMapper(o =>
{
    o.CreateMap<Product, ProductDTO>()
    .ForMember(
        destination => destination.AvailableQuantity,
        options => options.MapFrom(
            source => source.Inventory == null
                ? 0
                : source.Inventory.AvailableQuantity));
    o.CreateMap<ProductCreateDTO, Product>();
    o.CreateMap<ProductUpdateDTO, Product>();
    o.CreateMap<Category, CategoryDTO>();
    o.CreateMap<CategoryCreateAndUpdateDTO, Category>();
    o.CreateMap<Inventory, InventoryDTO>();
    o.CreateMap<InventoryCreateDTO, Inventory>();
    o.CreateMap<InventoryUpdateDTO, Inventory>();
    o.CreateMap<User, UserDTO>();
    o.CreateMap<CartItem, CartItemDTO>()
    .ForMember(
        destination => destination.ProductName,
        options => options.MapFrom(source => source.Product!.Name))
    .ForMember(
        destination => destination.ProductImageUrl,
        options => options.MapFrom(source => source.Product!.ImageUrl))
    .ForMember(
        destination => destination.ProductPrice,
        options => options.MapFrom(source => source.Product!.Price))
    .ForMember(
        destination => destination.AvailableQuantity,
        options => options.MapFrom(source =>
            source.Product!.Inventory == null
                ? 0
                : source.Product.Inventory.AvailableQuantity));
    o.CreateMap<CartItemCreateDTO, CartItem>();
    o.CreateMap<CartItemUpdateDTO, CartItem>();
    o.CreateMap<Order, OrderDTO>();
    o.CreateMap<OrderUpdateDTO, Order>();
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var jwtkey = builder.Configuration["Jwt:Key"];
var jwtEncryptionKey = builder.Configuration["Jwt:EncryptionKey"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];
if (string.IsNullOrWhiteSpace(jwtkey) || string.IsNullOrWhiteSpace(jwtEncryptionKey))
    throw new InvalidOperationException("JWT signing or encryption key is missing.");
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
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtkey)),
            TokenDecryptionKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtEncryptionKey)),
            // Ensure the role claim type used by the token handler is recognized when Authorize(Roles=...) is evaluated
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["access_token"];

                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddScoped<JWTTokenService>();

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
var app = builder.Build();
//await SeedDataAsync(app);


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseCors("ReactApp");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

//static async Task SeedDataAsync(WebApplication app)
//{
//    using var scope = app.Services.CreateScope();
//    var context = scope.ServiceProvider.GetRequiredService<ECommerceDBContext>();
//    await context.Database.MigrateAsync();
//}
