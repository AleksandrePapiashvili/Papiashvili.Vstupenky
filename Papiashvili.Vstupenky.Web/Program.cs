using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Papiashvili.Vstupenky.Web.Areas.Identity.Data;
using Papiashvili.Vstupenky.Web.Vstupenky.Abstraction;
using Papiashvili.Vstupenky.Web.Vstupenky.Implementation;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PapiashviliVstupenkyWebContextConnection") ?? throw new InvalidOperationException("Connection string 'PapiashviliVstupenkyWebContextConnection' not found.");

builder.Services.AddDbContext<PapiashviliVstupenkyWebContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PapiashviliVstupenkyWebUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() // Добавляем роли
    .AddEntityFrameworkStores<PapiashviliVstupenkyWebContext>()
    .AddUserStore<UserStore<PapiashviliVstupenkyWebUser, IdentityRole, PapiashviliVstupenkyWebContext, string>>()
    .AddRoleStore<RoleStore<IdentityRole, PapiashviliVstupenkyWebContext, string>>();

// Добавление сервисов в контейнер.
builder.Services.AddScoped<IConcertAdminService, ConcertAdminDFakeService>();
builder.Services.AddScoped<IConcertManagerService, ConcertManagerDFakeService>();
builder.Services.AddScoped<IHomeService, HomeService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<PapiashviliVstupenkyWebUser>>();

await EnsureRoleExistsAsync(roleManager, "Admin");
await EnsureRoleExistsAsync(roleManager, "Manager");

var adminUser = await userManager.FindByEmailAsync("Admin@gmail.com");
var managerUser = await userManager.FindByEmailAsync("Manager@gmail.com");

if (adminUser != null)
{
    await EnsureUserHasRoleAsync(userManager, adminUser, "Admin");
}

if (managerUser != null)
{
    await EnsureUserHasRoleAsync(userManager, managerUser, "Manager");
}

// Настройка запросов HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

async Task EnsureRoleExistsAsync(RoleManager<IdentityRole> roleManager, string roleName)
{
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        await roleManager.CreateAsync(new IdentityRole(roleName));
    }
}

async Task EnsureUserHasRoleAsync(UserManager<PapiashviliVstupenkyWebUser> userManager, PapiashviliVstupenkyWebUser user, string roleName)
{
    if (!await userManager.IsInRoleAsync(user, roleName))
    {
        await userManager.AddToRoleAsync(user, roleName);
    }
}
