using BlogProject.DAL.Concrete;
using BlogProject.BLL.Services.Concrete;
using BlogProject.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using BlogProject.DAL.Concrete.Context;
using BlogProject.BLL.Describers;
using BlogProject.Web.Filters.ArticleVisitors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();      //Session için eklendi.

// Add services to the container.
builder.Services.AddControllersWithViews(o =>
{
    o.Filters.Add<ArticleVisitorFilter>();  //Týklanma sayýsý için yaptýðýmýz filter'ý ekledik.
});

builder.Services.AddScopedDAL();    //EFContextDAL'ýn dependency injection iþlemi yapýlmýþ oldu.
builder.Services.AddScopedBLL();

builder.Services.AddIdentity<AppUser, AppRole>
    (
    //options =>
    //{   // ****KALDIRACAÐIZ
    //    options.Password.RequireNonAlphanumeric = false;   //deneme aþamasýnda þifreyi 1234 gibi girmek için
    //    options.Password.RequireLowercase = false;
    //    options.Password.RequireUppercase = false;
    //}
    )
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppIdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{                                   //area - control - action
    config.LoginPath = new PathString("/Admin/Authorize/Login");    //Giriþ yapýlmazsa, kullanýcý linki bilse dahi bizi login sayfasýna yönlendirecek.
    config.LogoutPath = new PathString("/Admin/Authorize/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "BlogProject",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest    //SameAsRequest: Hem HTTP hem de HTTPS sayfalarýný destekler. Proje canlýya çýkarsa burayý "Always" yapmamýz gerekir.
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromMinutes(8);
    config.AccessDeniedPath = new PathString("/Admin/Authorize/AccessDenied");   //Yetkisiz giriþler bu sayfaya yönlendirilecek.
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

app.UseSession();           //Session kullanmak için.

app.UseRouting();

app.UseAuthentication();    //Her zaman "Authorization" üstünde olur. Kimsin sen?
app.UseAuthorization();     //Rol ile ilgili. Ne iþ yaparsýn?

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute
    (
        name: "Admin",
        areaName: "Admin", pattern: "Admin/{Controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute
    (
        name: "default", pattern: "{controller=Home}/{action=About}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
});

app.Run();