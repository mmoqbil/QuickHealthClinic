using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuickHealthClinic.Authorization;
using QuickHealthClinic.DataAccess.DbContexts;
using QuickHealthClinic.DataAccess.Entities;
using QuickHealthClinic.DataAccess.Repositories;
using QuickHealthClinic.DataAccess.Repositories.Interfaces;
using QuickHealthClinic.Services.DoctorServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<QuickHealthClinicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuickHealthClinicConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorizationHandler, DoctorResourceOperationRequirementHandler>();
builder.Services
        .AddIdentity<Doctor, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<QuickHealthClinicContext>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
