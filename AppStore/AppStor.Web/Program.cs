using AppStor.Web.Middleware;
using AppStore.Aplication.Services.Implements;
using AppStore.Aplication.Services.Interfaces;
using AppStore.Data.Context;
using AppStore.Data.Repositoreis;
using AppStore.Domain.Contracts;
using AppStore.IOC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.SlidingExpiration = true;
});

builder.Services.AddDbContext<AppStore_DB_Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppStorConnectionString"));
});

builder.Services.RegisterServices();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountServices, AccountServices>();
builder.Services.AddScoped<IProductGroupServices, ProductGroupServices>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IProductSubGroupServices, ProductSubGroupServices>();
builder.Services.AddScoped<IProductSubGroupRepository, ProductSubGroupRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
//builder.Services.AddScoped<IProductGalleryServices, ProductGalleryServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();


app.UseMiddleware<CheckAdmin>();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
//app.MapControllerRoute(
//      name: "areas",
//      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
