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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ECommerceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<InventoryRepository>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CartItemRepository>();
builder.Services.AddScoped<CartItemService>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddAutoMapper(o =>
{
    o.CreateMap<Product, ProductDTO>()
    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));
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
        dest => dest.ProductName,
        opt => opt.MapFrom(src => src.Product!.Name));
    o.CreateMap<CartItemCreateDTO, CartItem>();
    o.CreateMap<CartItemUpdateDTO, CartItem>();
    o.CreateMap<Order, OrderDTO>();
    o.CreateMap<OrderCreateDTO, Order>();
    o.CreateMap<OrderUpdateDTO, Order>();
});


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
//await SeedDataAsync(app);


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.MapControllers();
app.Run();

//static async Task SeedDataAsync(WebApplication app)
//{
//    using var scope = app.Services.CreateScope();
//    var context = scope.ServiceProvider.GetRequiredService<ECommerceDBContext>();
//    await context.Database.MigrateAsync();
//}
