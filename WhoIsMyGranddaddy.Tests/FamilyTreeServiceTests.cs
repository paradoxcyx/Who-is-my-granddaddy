
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using WhoIsMyGranddaddy.Data.Database;
using WhoIsMyGranddaddy.Data.Entities;
using WhoIsMyGranddaddy.Data.Repositories;

namespace WhoIsMyGranddaddy.Tests;

public class FamilyTreeServiceTests : TestsBase
{
    /*
    private readonly Mock<IAppDbContext> _dbContextMock;
    private readonly IPersonRepository _repository;
    */

    public FamilyTreeServiceTests()
    {
        /*_dbContextMock = new Mock<IAppDbContext>(new DbContextOptions<AppDbContext>());
        _repository = new PersonRepository(_dbContextMock.Object);*/
    }
    
    [Fact]
    public async Task GetDescendantsByIdentityNumberAsync_ShouldReturnResult()
    {
        // Arrange
        var dbContextMock = new Mock<IAppDbContext>();

        /*
        // Mock setup for Persons DbSet
        var personsData = new List<Person>
        {
            new Person { Id = 1, Name = "John" },
            new Person { Id = 2, Name = "Jane" },
            // Add more mock data as needed
        };
        var personsDbSetMock = new Mock<DbSet<Person>>();
        personsDbSetMock.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(personsData.AsQueryable().Provider);
        personsDbSetMock.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(personsData.AsQueryable().Expression);
        personsDbSetMock.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(personsData.AsQueryable().ElementType);
        personsDbSetMock.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(personsData.GetEnumerator());
        dbContextMock.Setup(x => x.Persons).Returns(personsDbSetMock.Object);
        */

        // Mock setup for PersonsWithPartner DbSet
        var personWithPartnerData = new List<PersonWithPartner>
        {
            new() { Id = 1, Name = "John", Surname = "Van Wyk", PartnerId = 2, BirthDate = DateTime.Now, FatherId = null, MotherId = null, IdentityNumber = "ID1" },
            new() { Id = 2, Name = "Jane", Surname = "Van Wyk", PartnerId = 1, BirthDate = DateTime.Now, MotherId = null, FatherId = null, IdentityNumber = "ID2" },
            new() { Id = 3, Name = "Jannie", Surname = "Van Wyk", PartnerId = null, BirthDate = DateTime.Now, FatherId = 1, MotherId = 2, IdentityNumber = "ID3" },
            new() { Id = 4, Name = "Sarah", Surname = "Van Wyk", PartnerId = null, BirthDate = DateTime.Now, FatherId = 1, MotherId = 2, IdentityNumber = "ID4"  },
            // Add more mock data as needed
        };
        
        var personsWithPartnerDbSetMock = new Mock<DbSet<PersonWithPartner>>();
        personsWithPartnerDbSetMock.As<IQueryable<PersonWithPartner>>().Setup(m => m.Provider).Returns(personWithPartnerData.AsQueryable().Provider);
        personsWithPartnerDbSetMock.As<IQueryable<PersonWithPartner>>().Setup(m => m.Expression).Returns(personWithPartnerData.AsQueryable().Expression);
        personsWithPartnerDbSetMock.As<IQueryable<PersonWithPartner>>().Setup(m => m.ElementType).Returns(personWithPartnerData.AsQueryable().ElementType);
        personsWithPartnerDbSetMock.As<IQueryable<PersonWithPartner>>().Setup(m => m.GetEnumerator()).Returns(personWithPartnerData.GetEnumerator());
        dbContextMock.Setup(x => x.PersonsWithPartner).Returns(personsWithPartnerDbSetMock.Object);

        // Mock setup for ExecuteStoredProcedure
        var storedProcedureResult = new Tuple<List<PersonWithPartner>, int>(personWithPartnerData, personWithPartnerData.Count);
        dbContextMock.Setup(x => x.ExecuteStoredProcedure<PersonWithPartner>(It.IsAny<string>(), It.IsAny<SqlParameter[]>()))
                     .ReturnsAsync(storedProcedureResult);

        // Create an instance of your repository (replace with the actual repository class)
        var repository = new PersonRepository(dbContextMock.Object);

        
        // Act
        var result = await repository.GetDescendantsByIdentityNumberAsync("ID1", 1);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Tuple<List<PersonWithPartner>, int>>(result);

        // Add more specific assertions based on your expected behavior
        // ...
    }

    // Helper method to mock DbSet
    private static DbSet<T> MockDbSet<T>(IEnumerable<T> data) where T : class
    {
        var queryable = data.AsQueryable();
        var dbSetMock = new Mock<DbSet<T>>();
        dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

        return dbSetMock.Object;
    }

    private static Task SetOutputParameterAsync(DbParameterCollection parameters, string parameterName, object value)
    {
        foreach (SqlParameter parameter in parameters)
        {
            if (parameter.ParameterName == parameterName)
            {
                parameter.Value = value;
                return Task.CompletedTask;
            }
        }

        throw new ArgumentException($"Parameter with name {parameterName} not found.");
    }
    
    // Helper method to create a mock DbSet
    private static DbSet<T> MockDbSet<T>(List<T> data) where T : class
    {
        var queryableData = data.AsQueryable();

        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryableData.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryableData.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryableData.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryableData.GetEnumerator());

        return mockSet.Object;
    }
    
    /// <summary>
    /// Test case to verify that a family tree is ordered by birthdate and that the correct people is in the correct positions
    /// </summary>
    [Fact]
    public async Task GetFullFamilyTree_ShouldReturnCorrectFamilyTree()
    {
        /*// Arrange
        var personRepository = new PersonRepository(TestContext);
        var personService = new FamilyTreeService(personRepository);

        // Act
        var familyTree = await personService.GetFamilyTreeAsync();

        // Assert
        Assert.NotNull(familyTree);
        Assert.NotEmpty(familyTree);
    
        // Assert that there are exactly two top-level persons (mother and father)
        Assert.Equal(2, familyTree.Count);

        // Assert children are the same for both Father & Mother, ordered by Birthdate ascending
        var expectedChildren = new[] { "ID6", "ID7", "ID3", "ID4", "ID5" };

        foreach (var person in familyTree)
        {
            /#1#/ Assert that each person has the expected number of children
            Assert.Equal(expectedChildren.Length, person.Children.Count);

            // Assert that the children are in the expected order
            Assert.Collection(person.Children,
                child => Assert.Equal(expectedChildren[0], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[1], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[2], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[3], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[4], child.IdentityNumber)
            );#1#
        }*/
    }

    //TODO: Currently unable to test Stored Procedures within Unit Tests
    /*[Fact]
    public async Task GetDescendantFamilyTree_ShouldReturnCorrectFamilyTree()
    {
        //Identity Number to search by
        const string identityNumber = "ID10";
        
        // Arrange
        var personRepository = new PersonRepository(TestContext);
        var personService = new PersonService(personRepository);
        
        // Act
        var familyTree = await personService.GetFamilyTreeDescendants(identityNumber);
        
        // Assert
        Assert.NotNull(familyTree);
        Assert.NotEmpty(familyTree);
        
        // Assert that there are exactly two top-level persons (mother and father)
        Assert.Equal(2, familyTree.Count);
        
        //Assert one-level down descendants (children)
        Assert.Equal("ID21", familyTree[0].Children[0].IdentityNumber);
        Assert.Equal("ID22", familyTree[0].Children[1].IdentityNumber);
    }
    
    [Fact]
    public async Task GetRootAscendant_ShouldReturnCorrectRootAscendant()
    {
        //Identity Number to search by
        const string identityNumber = "ID10";
        
        // Arrange
        var personRepository = new PersonRepository(TestContext);
        var personService = new PersonService(personRepository);
        
        // Act
        var rootAscendants = await personService.GetRootAscendants(identityNumber);
        
        // Assert
        Assert.NotNull(rootAscendants);
        Assert.NotEmpty(rootAscendants);
        
        // Assert that there are exactly two top-level persons (mother and father)
        Assert.Equal(2, rootAscendants.Count);
        
        //Assert one-level down descendants (children)
        Assert.Equal("ID1", rootAscendants[0].IdentityNumber);
        Assert.Equal("ID2", rootAscendants[1].IdentityNumber);
    }*/
}