using Adopt.Api.Migrations;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

public class DataContextInMemory : DbContext
{
    private readonly SqliteConnection _connection;
    private readonly DataContext _context;
    public DataContext GetContext() => _context;

    public DataContextInMemory()
    {
        Batteries.Init();
        _connection = new SqliteConnection("Data Source=:memory:");
        _connection.Open();
        var opts = new DbContextOptionsBuilder<DataContext>()
            .UseSqlite(_connection).EnableSensitiveDataLogging().Options;
        _context = new DataContext(opts);


        CreateTables();
        InsertFakeData();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connection);
    }

    private void CreateTables()
    {
        // Criar tabela AbrigoModel
        _context.Database.ExecuteSqlRaw(@"CREATE TABLE AbrigoModel (
                                            id INTEGER PRIMARY KEY,
                                            UserName TEXT,
                                            City TEXT,
                                            PhoneNumber TEXT,
                                            CNPJ TEXT,
                                            PasswordHash TEXT,
                                            State TEXT,
                                            Email TEXT
                                        )");

        // Criar tabela PetModel
        _context.Database.ExecuteSqlRaw(@"CREATE TABLE petModels (
                                            id INTEGER PRIMARY KEY,
                                            name TEXT,
                                            age TEXT,
                                            Abrigo_id INTEGER,
                                            description TEXT,
                                            address TEXT,
                                            Photo TEXT,
                                            adopted INTEGER,
                                            FOREIGN KEY(Abrigo_id) REFERENCES AbrigoModel(id)
                                        )");
    }



    private void InsertFakeData()
    {
        _context.AbrigoModel.Add(new AbrigoModel
        {

            id = 1,
            UserName = "Abrigo 1",
            City = "Rua 1",
            PhoneNumber = "123456789",
            CNPJ = "10.736.016/0001-10",
            PasswordHash = "@gA487177",
            State = "SP",
            Email = "email@gmail.com",


        });

        _context.petModels.Add(new PetModel
        {
            id = 1,
            name = "Dog",
            age = "2",
            Abrigo_id = 1,
            description = "Dog",
            Photo = "Dog.jpg",
            adopted = true,
            

        });

        _context.SaveChanges();
    }

   
    
}
