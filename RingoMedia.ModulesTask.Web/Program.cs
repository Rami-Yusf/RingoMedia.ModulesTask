using Microsoft.EntityFrameworkCore;
using RingoMedia.ModulesTask.Models;
using System.Net.Mail;
using System.Net;
using Hangfire;
using RingoMedia.ModulesTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
// Add Hangfire services.
builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add the Hangfire server.
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IReminderService, ReminderService>();
builder.Services.AddScoped<IEmailReminderSchedulerService, EmailReminderSchedulerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is migrated at startup
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
}

// Use Hangfire dashboard.
app.UseHangfireDashboard();
app.Run();

