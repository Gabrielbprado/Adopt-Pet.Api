using Adopt_Pet.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adopt_Pet.Api.Data;

public class DataContext : IdentityDbContext<TutorModel, IdentityRole, string>
{
    public DataContext(DbContextOptions<DataContext> opts) : base(opts)
    {
        
    }
    public DbSet <AbrigoModel> abrigoModels { get; set; }

}
