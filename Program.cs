using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<TutorModel, IdentityRole>().AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<ITutorRepository,TutorRepository>();
builder.Services.AddTransient<IAbrigoRepository,AbrigoRepository>();
builder.Services.AddTransient<IPetRepository, PetRepository>();
builder.Services.AddScoped<TokenService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
