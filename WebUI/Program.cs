using Microsoft.AspNetCore.Authorization;
using WebUI.Configs;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IAuthorizationHandler, PermissionHandler>();

builder.Services.AddAuthorization(options =>
{
    // Đăng ký chính sách Authorization
    options.AddPolicy("Authorization", policy =>
    {
        // Thêm AuthorizationRequirement vào chính sách
        policy.Requirements.Add(new AuthorizationRequirement());
    });
});

builder.Services.Configure<CookiePolicyOptions>(optitons =>
{
    optitons.CheckConsentNeeded = context => true;
    optitons.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = cvidproStatic.CookieScheme;
    options.DefaultSignInScheme = cvidproStatic.CookieScheme;

}) // Sets the default scheme to cookies
               .AddCookie(cvidproStatic.CookieScheme);

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
public class cvidproStatic
{

    public const string CookieScheme = "cvidpro";
    public const string apiLink = "https://staging.cvidpro.net";
}