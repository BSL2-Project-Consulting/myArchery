using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using myArchery.Persistance;
using myArchery.Persistance.Models;
using myArchery.Services;
using myArchery.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ArcheryDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// RequireConfirmedAccount == email bestätigung
builder.Services.AddDefaultIdentity<AspNetUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<myArcheryContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<myArcheryContext>();

// Add Emailconfirmation here

var app = builder.Build();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

//Utility.GenerateDummyValues();