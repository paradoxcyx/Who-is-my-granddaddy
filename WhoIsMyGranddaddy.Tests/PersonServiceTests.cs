using WhoIsMyGranddaddy.Data.Repositories;
using WhoIsMyGranddaddy.Domain.Services;

namespace WhoIsMyGranddaddy.Tests;

public class PersonServiceTests : TestsBase
{
    /// <summary>
    /// Test case to verify that a family tree is ordered by birthdate and that the correct people is in the correct positions
    /// </summary>
    [Fact]
    public async Task GetFullFamilyTree_ShouldReturnCorrectFamilyTree()
    {
        // Arrange
        var personRepository = new PersonRepository(TestContext);
        var personService = new PersonService(personRepository);

        // Act
        var familyTree = await personService.GetFullFamilyTree();

        // Assert
        Assert.NotNull(familyTree);
        Assert.NotEmpty(familyTree);
    
        // Assert that there are exactly two top-level persons (mother and father)
        Assert.Equal(2, familyTree.Count);

        // Assert children are the same for both Father & Mother, ordered by Birthdate ascending
        var expectedChildren = new[] { "ID6", "ID7", "ID3", "ID4", "ID5" };

        foreach (var person in familyTree)
        {
            // Assert that each person has the expected number of children
            Assert.Equal(expectedChildren.Length, person.Children.Count);

            // Assert that the children are in the expected order
            Assert.Collection(person.Children,
                child => Assert.Equal(expectedChildren[0], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[1], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[2], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[3], child.IdentityNumber),
                child => Assert.Equal(expectedChildren[4], child.IdentityNumber)
            );
        }
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