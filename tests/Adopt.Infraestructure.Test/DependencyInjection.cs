using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

public class DependencyInjection
{
    protected readonly ServiceProvider _serviceProvider;
    protected readonly DbContextOptions<DataContext> _dbContextOptions;

    public DependencyInjection()
    {
        var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();
        _dbContextOptions = new DbContextOptionsBuilder<DataContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var services = new ServiceCollection();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDatabase"));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped<TokenService>();
        services.AddTransient<IPetRepository,PetRepository>();

        // Configuração do Identity
        services.AddIdentity<TutorModel, IdentityRole>()
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();

        // Configuração de outros serviços necessários para os testes, como IMapper, TokenService, etc.

        services.AddLogging(); // Configuração do logger

        _serviceProvider = services.BuildServiceProvider();
        SeedData();
    }
    protected void SeedData()
    {
        using (var context = new DataContext(_dbContextOptions))
        {
            // Verifica se já existem dados no banco de dados em memória
            if (!context.Tutors.Any())
            {
                // Adiciona alguns dados iniciais
                var tutor1 = new TutorModel { Id = "1",UserName = "username", City = "City1", State = "State1", Email = "tutor1@example.com",PasswordHash = "" };
                var tutor2 = new TutorModel { Id = "2",UserName = "tutor2", City = "City2", State = "State2", Email = "tutor2@example.com" };

                context.Tutors.AddRange(tutor1, tutor2);
                context.SaveChanges();
            }
        }
    }
}
