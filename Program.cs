global using Project1.Models;
using Project1.Services.ContactServices;
using Project1.Services.OrganisationServices;
using Project1.Services.ProjectServices;
using Project1.Services.StaffServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// REGISTER StaffService
builder.Services.AddScoped<IStaffService,StaffService>();
// REGISTER ContactService
builder.Services.AddScoped<IContactService,ContactService>();
// REGISTER ProjectService
builder.Services.AddScoped<IProjectService,ProjectService>();
// REGISTER OrganisationService
builder.Services.AddScoped<IOrganisationService,OrganisationService>();

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
