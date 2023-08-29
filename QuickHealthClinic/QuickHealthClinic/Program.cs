using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuickLifeCoachingClinic.Authorization;
using QuickLifeCoachingClinic.DataAccess.DbContexts;
using QuickLifeCoachingClinic.DataAccess.Entities;
using QuickLifeCoachingClinic.DataAccess.Repositories;
using QuickLifeCoachingClinic.DataAccess.Repositories.Interfaces;
using QuickLifeCoachingClinic.Services.MentorServices;
using QuickLifeCoachingClinic.Services.FileServices;
using QuickLifeCoachingClinic.Services.ClinicService;
using QuickLifeCoachingClinic.Services.StudentServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<QuickLifeCoachingClinicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuickHealthClinicConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddScoped<IMentorService, MentorService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IMentorRepository, MentorRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorizationHandler, MentorResourceOperationRequirementHandler>();
builder.Services
        .AddIdentity<Mentor, IdentityRole>()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<QuickLifeCoachingClinicContext>();


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
