using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sanctuary.Data;
using Sanctuary.Data.Control;
using Sanctuary.Data.Control.ControlContracts;
using Sanctuary.Data.Models.Configurable;
using Sanctuary.Data.Models.UserTables;
using Sanctuary.Data.Repositories;
using Sanctuary.Data.Repositories.RepositoriesContracts;
using Sanctuary.Services;
using Sanctuary.Services.API;
using Sanctuary.Services.API.APIContracts;
using Sanctuary.Services.Contracts;

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

builder.Services.AddControllers(options => options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Sanctuary.Web",
        policy =>
        {
            policy.WithOrigins("https://localhost:44394").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddMvc(options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SanctuaryDbConnection")));
builder.Services.AddScoped(typeof(IPostalCodeRepository<>), typeof(PostalCodeRepository<>));
builder.Services.AddScoped(typeof(IAddressRepository<>), typeof(AddressRepository<>));
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped(typeof(ITransactionalManagementUoW<,>), typeof(TransactionalManagementUoW<,>));
builder.Services.AddScoped<IAPIGoogleGeocodingService, APIGoogleGeocodingService>();
builder.Services.AddScoped<IPostalCodeService, PostalCodeService>();
builder.Services.AddScoped(typeof(IAppointmentRepository<>), typeof(AppointmentRepository<>));
builder.Services.AddScoped(typeof(IAppointmentService), typeof(AppointmentService));
builder.Services.AddScoped(typeof(IPetRepository<>), typeof(PetRepository<>));
builder.Services.AddScoped<IUserRepository<BaseApplicationUser>>(x =>
    new UserRepository<BaseApplicationUser>(x.GetRequiredService<ApplicationDbContext>(), x.GetRequiredService<UserManager<BaseApplicationUser>>(),
        x.GetRequiredService<RoleManager<ApplicationRole>>()));

//IPetRepository<Pet> injPetRepository, IUserRepository<BaseApplicationUser> injUserRepository, IAppointmentRepository<Appointment> injAppRepository
//builder.Services.AddScoped((Func<IServiceProvider, IAddressService>)(x => new AddressService((Sanctuary.Data.Control.ControlContracts.IUnitOfWork<IAddressRepository<Address>, Address>)x.GetRequiredService<Sanctuary.Data.Control.ControlContracts.ITransactionalManagementUoW<AddressRepository<Address>, Address>>(),
//    x.GetRequiredService<IAPIGoogleGeocodingService>())));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("Sanctuary.Web");

app.UseAuthorization();

app.MapControllers();

app.Run();
