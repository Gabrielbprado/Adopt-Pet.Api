using Adopt_Pet.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adopt_Pet.Api.Data;

public class DataContext : IdentityDbContext<TutorModel>
{

    public DataContext(DbContextOptions<DataContext> opts) : base(opts)
    {
        
    }

}
