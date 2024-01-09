using guneshukuk.DataAccessLayer.Concrete;
using guneshukuk.EntityLayer.Entities;
using guneshukuk.WebUI.ViewComponents.DefaultComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);
var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
builder.Services.AddDbContext<GuneshukukContext>();
builder.Services.AddMudServices();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<GuneshukukContext>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LogoutPath = "/";
});

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

app.UseAuthorization();

app.MapRazorComponents<_DefaultHomeComponentPartial>().AddInteractiveServerRenderMode();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");



app.Run();
