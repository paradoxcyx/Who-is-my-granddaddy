using Microsoft.EntityFrameworkCore;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Tests;

public class TestsBase : IDisposable, IAsyncDisposable
{
    protected readonly AppDbContext TestContext;

    protected TestsBase()
    {
        var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: "WhoIsMyGranddaddy_Tests")
            .Options;

        TestContext = new AppDbContext(dbContextOptions);
        
        TestContext.Persons.AddRange(GetTestPersons());
        TestContext.SaveChanges();
        TestContext.Database.EnsureCreated();
    }
    
    private static IEnumerable<Person> GetTestPersons()
    {
        return new List<Person>
        {
            new Person { FatherId = null, MotherId = null, Name = "John", Surname = "Doe", BirthDate = new DateTime(1950, 01, 01), IdentityNumber = "ID1" },
            new Person { FatherId = null, MotherId = null, Name = "Jane", Surname = "Doe", BirthDate = new DateTime(1955, 02, 15), IdentityNumber = "ID2" },
            new Person { FatherId = 1, MotherId = 2, Name = "David", Surname = "Doe", BirthDate = new DateTime(1975, 05, 10), IdentityNumber = "ID3" },
            new Person { FatherId = 1, MotherId = 2, Name = "Emily", Surname = "Doe", BirthDate = new DateTime(1980, 08, 20), IdentityNumber = "ID4" },
            new Person { FatherId = 1, MotherId = 2, Name = "James", Surname = "Doe", BirthDate = new DateTime(1982, 11, 30), IdentityNumber = "ID5" },
            new Person { FatherId = 1, MotherId = 2, Name = "Robert", Surname = "Doe", BirthDate = new DateTime(1970, 03, 18), IdentityNumber = "ID6" },
            new Person { FatherId = 1, MotherId = 2, Name = "Alice", Surname = "Doe", BirthDate = new DateTime(1972, 06, 22), IdentityNumber = "ID7" },
            new Person { FatherId = 3, MotherId = 4, Name = "Samantha", Surname = "Doe", BirthDate = new DateTime(1995, 09, 12), IdentityNumber = "ID8" },
            new Person { FatherId = 3, MotherId = 4, Name = "Michael", Surname = "Doe", BirthDate = new DateTime(1998, 12, 25), IdentityNumber = "ID9" },
            new Person { FatherId = 3, MotherId = 4, Name = "Linda", Surname = "Doe", BirthDate = new DateTime(2002, 04, 02), IdentityNumber = "ID10" },
            new Person { FatherId = 5, MotherId = 6, Name = "William", Surname = "Doe", BirthDate = new DateTime(2005, 08, 15), IdentityNumber = "ID11" },
            new Person { FatherId = 5, MotherId = 6, Name = "Sophia", Surname = "Doe", BirthDate = new DateTime(2008, 11, 28), IdentityNumber = "ID12" },
            new Person { FatherId = 7, MotherId = 8, Name = "Isaac", Surname = "Doe", BirthDate = new DateTime(2020, 03, 15), IdentityNumber = "ID13" },
            new Person { FatherId = 7, MotherId = 8, Name = "Ella", Surname = "Doe", BirthDate = new DateTime(2022, 06, 28), IdentityNumber = "ID14" },
            new Person { FatherId = 9, MotherId = 10, Name = "Benjamin", Surname = "Doe", BirthDate = new DateTime(2019, 01, 10), IdentityNumber = "ID15" },
            new Person { FatherId = 9, MotherId = 10, Name = "Emma", Surname = "Doe", BirthDate = new DateTime(2021, 04, 23), IdentityNumber = "ID16" },
            new Person { FatherId = 11, MotherId = 12, Name = "Owen", Surname = "Doe", BirthDate = new DateTime(2040, 09, 05), IdentityNumber = "ID17" },
            new Person { FatherId = 11, MotherId = 12, Name = "Ava", Surname = "Doe", BirthDate = new DateTime(2043, 12, 18), IdentityNumber = "ID18" },
            new Person { FatherId = 13, MotherId = 14, Name = "Caleb", Surname = "Doe", BirthDate = new DateTime(2038, 03, 22), IdentityNumber = "ID19" },
            new Person { FatherId = 13, MotherId = 14, Name = "Chloe", Surname = "Doe", BirthDate = new DateTime(2040, 06, 05), IdentityNumber = "ID20" },
            new Person { FatherId = 15, MotherId = 16, Name = "Ethan", Surname = "Doe", BirthDate = new DateTime(2065, 08, 10), IdentityNumber = "ID21" },
            new Person { FatherId = 15, MotherId = 16, Name = "Sophie", Surname = "Doe", BirthDate = new DateTime(2068, 11, 23), IdentityNumber = "ID22" },
            new Person { FatherId = 17, MotherId = 18, Name = "Mia", Surname = "Doe", BirthDate = new DateTime(2063, 02, 28), IdentityNumber = "ID23" },
            new Person { FatherId = 17, MotherId = 18, Name = "Logan", Surname = "Doe", BirthDate = new DateTime(2065, 05, 12), IdentityNumber = "ID24" },
            new Person { FatherId = 19, MotherId = 20, Name = "Jackson", Surname = "Doe", BirthDate = new DateTime(2090, 07, 15), IdentityNumber = "ID25" },
            new Person { FatherId = 19, MotherId = 20, Name = "Aria", Surname = "Doe", BirthDate = new DateTime(2093, 10, 28), IdentityNumber = "ID26" },
            new Person { FatherId = 21, MotherId = 22, Name = "Noah", Surname = "Doe", BirthDate = new DateTime(2088, 01, 10), IdentityNumber = "ID27" },
            new Person { FatherId = 21, MotherId = 22, Name = "Lily", Surname = "Doe", BirthDate = new DateTime(2090, 04, 23), IdentityNumber = "ID28" }
        };
    }

    public void Dispose()
    {
        TestContext.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await TestContext.DisposeAsync();
    }
}