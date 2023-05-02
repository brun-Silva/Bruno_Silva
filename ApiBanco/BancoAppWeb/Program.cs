using ApiBanco.Bussines.Services;
using Microsoft.EntityFrameworkCore;
using User.Data.Interface;
using User.Data.Repository;
using User.Data;
using BancoAppWeb.Factory;
using User.Data.Infrastructure.Factory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();





//add repo global escop
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDTOFactory, DTOFactory>();
builder.Services.AddScoped<IViewFactory, ViewFactory>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddDbContext<ApiBancoContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    var migrationsAssembly = typeof(ApiBancoContext).Assembly.GetName().Name;

    opts.UseSqlServer(connectionString, sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(migrationsAssembly);
        sqlOptions.EnableRetryOnFailure(3, TimeSpan.FromSeconds(15), null);
    });
});


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
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Login}/");

app.Run();
