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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PetModel>()
            .HasOne(pet => pet.AbrigoModel)
            .WithMany(abrigo => abrigo.PetModel) 
            .HasForeignKey(pet => pet.Abrigo_id); 

        // Outros mapeamentos aqui, se houver

        base.OnModelCreating(builder);
    }

    public DbSet <AbrigoModel> AbrigoModel { get; set; }
    public DbSet <PetModel> petModels { get; set; }

}
