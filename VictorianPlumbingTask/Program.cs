using AutoMapper;
using BAS.VPTask.Application.Interfaces;
using BAS.VPTask.Application.Services;
using BAS.VPTask.Core.Mappings;
using BAS.VPTask.EntityFramework;
using BAS.VPTask.EntityFramework.Interfaces;
using BAS.VPTask.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext <VPTaskDbContext> (option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString(builder.Configuration["DefaultConnectionString"])));

builder.Services.AddScoped<IOrderService, OrderService>()
                .AddScoped<ICustomerRepository, CustomerRepository>()
                .AddScoped<IItemRepository, ItemRepository>();

// Configure AutoMapper

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();