using Microsoft.EntityFrameworkCore;
using Serilog;
using TeacherStudentDAL.Models.Entities;
using TeacherStudentRepository.Implemaintations;
using TeacherStudentRepository.Interfaces;
using TeacherStudentServices.AutoMapper;
using TeacherStudentServices.Implemaintations;
using TeacherStudentServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

// Add services to the container.

builder.Services.AddDbContext<TeacherStudentDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();


// Mapping Configuration

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
