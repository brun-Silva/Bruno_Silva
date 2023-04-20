using ApiBanco.Bussines.Services;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using User.Data;
using User.Data.Infrastructure.Factory;
using User.Data.Interface;
using User.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//add repo global escop
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IDTOFactory, DTOFactory>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
