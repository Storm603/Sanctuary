using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Services;
using Sanctuary.Services.API;
using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Contracts;
using Sanctuary.Data;
using Sanctuary.Data.Control;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Models.Configurable;
using Sanctuary.Data.Repositories;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Data.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SanctuaryDbConnection")));
builder.Services.AddDefaultIdentity<BaseApplicationUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 6;
    })
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IAddressRepository<>), typeof(AddressRepository<>));
builder.Services.AddScoped(typeof(IImageRepository<>), typeof(ImageRepository<>));
builder.Services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
builder.Services.AddScoped(typeof(IPetRepository<>), typeof(PetRepository<>));
builder.Services.AddScoped(typeof(IClinicRepository<>), typeof(ClinicRepository<>));
builder.Services.AddScoped(typeof(IAppointmentRepository<>), typeof(AppointmentRepository<>));


builder.Services.AddScoped<IUserRepository<BaseApplicationUser>>(x =>
    new UserRepository<BaseApplicationUser>(x.GetRequiredService<ApplicationDbContext>(), x.GetRequiredService<UserManager<BaseApplicationUser>>(),
        x.GetRequiredService<RoleManager<ApplicationRole>>()));
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped(typeof(ITransactionalManagementUoW<,>), typeof(TransactionalManagementUoW<,>));
builder.Services.AddScoped<IAPIGoogleGeocodingService, APIGoogleGeocodingService>();
//builder.Services.AddScoped((Func<IServiceProvider, IAddressService>)(x => new AddressService((TransactionalManagementUoW<IAddressRepository<Address>, Address>)x.GetRequiredService<ITransactionalManagementUoW<AddressRepository<Address>, Address>>(),
//    x.GetRequiredService<IAPIGoogleGeocodingService>())));


builder.Services.AddDataProtection();
builder.Services.AddControllersWithViews(options => options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>());
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
});




var app = builder.Build();

// Seed data on application startup

//using (var serviceScope = app.Services.CreateScope())
//{
//    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    dbContext.Database.EnsureDeleted();
//    dbContext.Database.Migrate();

//    //method moved inInitial migration
//    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// use cors for apps that use js to retrieve static files
app.UseStaticFiles();

app.UseRouting();

//app.UseCors();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
