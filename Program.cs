using System.Reflection;
using MediatR;
using StudentCQRS.Data;
using StudentCQRS.Repositories;
using StudentCQRS.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
    builder.Services.AddDbContext<StudentDbContext>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}