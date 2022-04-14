using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myArchery.Persistance;
using myArchery.Persistance.Models;
using myArchery.Services;
using myArchery.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using myArchery.Hubs;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<myArcheryContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// RequireConfirmedAccount == email bestätigung
builder.Services.AddDefaultIdentity<AspNetUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<myArcheryContext>();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddScoped<ArcheryDbContext>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<ParcourService>();
builder.Services.AddScoped<ParcourTargetService>();
builder.Services.AddScoped<ArrowService>();
builder.Services.AddScoped<EventRoleService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<PointService>();

// Add Emailconfirmation here
WebApplication app;

try
{
    app = builder.Build();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Source} : {ex.Message}");
    throw;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");
app.MapHub<LiverankingHub>("/liverankingHub");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

//Utility.GenerateDummyValues();