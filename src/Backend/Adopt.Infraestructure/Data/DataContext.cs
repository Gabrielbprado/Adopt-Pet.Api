﻿using Adopt_Pet.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        builder.Entity<AdocaoModel>().HasOne(adocao => adocao.PetModel)
            .WithOne(pet => pet.AdocaoModel)
            .HasForeignKey<AdocaoModel>(adocao => adocao.pet_id);
        builder.Entity<AdocaoModel>().HasOne(adocao => adocao.TutorModel)
    .WithOne(tuto => tuto.AdocaoModel)
    .HasForeignKey<AdocaoModel>(adocao => adocao.tutor_id);

        // Outros mapeamentos aqui, se houver

        base.OnModelCreating(builder);
    }


    public DbSet <AbrigoModel> AbrigoModel { get; set; }
    public DbSet <PetModel> petModels { get; set; }
    public DbSet<AdocaoModel> AdocaoModel { get; set; }
    public DbSet<TutorModel> Tutors { get; set; } 

}
