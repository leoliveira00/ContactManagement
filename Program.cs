using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContactManagement.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetConnectionString("MariaDB");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ContactManagementContext>(options => options.UseMySQL(configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
