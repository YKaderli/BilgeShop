using BilgeShop.Business.Manager;
using BilgeShop.Business.Services;
using BilgeShop.Data.Context;
using BilgeShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BilgeShopContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));
// IRepository tipinde bir newleme yap�ld���nda (d i) - SqlRepository kopyas� olu�tur� AddScoped - Her istek te yeni bir kopya olu�tur.
builder.Services.AddScoped<IUserService, UserManager>();
// IUserService tipinde bir d i newlemesi yap�l�rsai UserManager kullan�lacak demek.

builder.Services.AddControllersWithViews();

var app = builder.Build();

 

app.MapDefaultControllerRoute();

app.Run();
