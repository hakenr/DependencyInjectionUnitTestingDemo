using DependencyInjectionUnitTestingDemo.Data;
using DependencyInjectionUnitTestingDemo.Repositories.Sales;
using DependencyInjectionUnitTestingDemo.Services.Sales;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


// Add application services.
builder.Services.AddTransient<IPriceResolver, PriceResolver>();

// repositories
builder.Services.AddTransient<IBasicPriceRepository, BasicPriceRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerPriceRepository, CustomerPriceRepository>();
builder.Services.AddTransient<ICustomerProductGroupDiscountRepository, CustomerProductGroupDiscountRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// UI services
builder.Services.AddTransient<ICustomerSelectOptions, CustomerSelectOptions>();
builder.Services.AddTransient<IProductSelectOptions, ProductSelectOptions>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
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

// Initial data seed
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
	var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
	context.EnsureSeedData();
}


app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
