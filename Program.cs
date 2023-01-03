using Microsoft.EntityFrameworkCore;
using TaskMaster;
using TaskMaster.Services;

var builder = WebApplication.CreateBuilder(args);

// Add in-memory database
builder.Services.AddDbContext<AppDbContext>(x => x.UseInMemoryDatabase("A"));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add the TaskService as a service
builder.Services.AddScoped<TaskService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
