using TradingERP.Models;
using TradingERP.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection(nameof(DatabaseConfig)));

builder.Services.AddSingleton<AdminService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<DriverService>();
builder.Services.AddSingleton<PartyService>();
builder.Services.AddSingleton<SiteService>();
builder.Services.AddSingleton<DealerService>();
builder.Services.AddSingleton<VehicleNoService>();
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<PumpService>();
builder.Services.AddSingleton<RegisterService>();
builder.Services.AddSingleton<DieselService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

//app.MapControllerRoute(
//    name: "areas",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
