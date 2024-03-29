using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using StudentsApp.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("database"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Students/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
