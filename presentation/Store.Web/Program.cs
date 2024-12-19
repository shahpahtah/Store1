
using Store;
using Store.Messages;
using Store.Contractors;
using Store.Web;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Store.YandexCassa;
using Store.Web.Contractors;
using Store.Web.App;
using Store.Data.EF;
using Store.Memory;

var builder = WebApplication.CreateBuilder(args);

var services=builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Autentification/Registration");
builder.Services.AddAuthorization();
builder.Services.AddEfRepositories(configuration.GetConnectionString("Store"));


builder.Services.AddSingleton<INotificationService,DebugNotificationService>();
builder.Services.AddSingleton<IDeliveryService,PostamateDeliveryService>();
builder.Services.AddSingleton<IPaymentService,CashPaymentService>();
builder.Services.AddSingleton<IPaymentService, YandexCassaPaymentService>();
builder.Services.AddSingleton<IWebContractorService, YandexCassaPaymentService>();
builder.Services.AddSingleton<IUserRepository,UserRepository>();
builder.Services.AddSingleton<IJwtProvider,JwtProvider>();
builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "yandex.kassa",
    areaName: "YandexKassa",
    pattern: "YandexKassa/{controller=Home}/{action=Index}/{id?}");

app.Run();
