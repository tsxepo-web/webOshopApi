using MediatR;
using webOshop.Application.Commands.Handlers;
using webOshop.Application.Queries.Handlers;
using webOshop.Domain.Interfaces;
using webOshop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(CreateProductHandler).Assembly);
builder.Services.AddMediatR(typeof(GetProductByIdHandler).Assembly);
builder.Services.AddMediatR(typeof(GetAllProductsHandler).Assembly);
builder.Services.AddMediatR(typeof(UpdateProductHandler).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbContext>(builder.Configuration);
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
