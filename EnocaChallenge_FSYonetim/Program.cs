using BusinessLayer.Concreate.FSYonetim;
using DataAccessLayer.Abstract.FSYonetim;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// DB Services 
builder.Services.AddScoped<FirmalarManager>();
builder.Services.AddScoped<UrunlerManager>();
builder.Services.AddScoped<SiparislerManager>();
builder.Services.AddScoped<IFirmalarDal, EfFirmalarDal>();
builder.Services.AddScoped<ISiparislerDal, EfSiparislerDal>();
builder.Services.AddScoped<IUrunlerDal, EfUrunlerDal>();


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
