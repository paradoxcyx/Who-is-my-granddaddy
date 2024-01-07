using AutoMapper;
using WhoIsMyGranddaddy.Domain.Mappings;
using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Tests;

public class MappingTests : TestsBase
{
    // ** DESCENDANTS MAPPING TESTS ** //
    [Fact]
    public void EnsureDescendantsMappingCorrect_EnsurePidsNotNull()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<FamilyMemberProfile>();
        });

        var mapper = configuration.CreateMapper();

        // Act
        var familyMemberModels = mapper.Map<List<FamilyMemberModel>>(PeopleWithPartners);

        Assert.NotNull(familyMemberModels);
        // Assert
        Assert.NotEmpty(familyMemberModels);
        
        Assert.NotNull(familyMemberModels[0].Pids);
        Assert.NotNull(familyMemberModels[1].Pids);
    }

    [Fact]
    public void EnsureDescendantsMappingCorrect_EnsureContainsCorrectPids()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<FamilyMemberProfile>(); });

        var mapper = configuration.CreateMapper();

        // Act
        var familyMemberModels = mapper.Map<List<FamilyMemberModel>>(PeopleWithPartners);

        Assert.NotNull(familyMemberModels);
        // Assert
        Assert.NotEmpty(familyMemberModels);
        
        Assert.Contains(2, familyMemberModels[0].Pids);
        Assert.Contains(1, familyMemberModels[1].Pids);
    }

    [Fact]
    public void EnsureDescendantsMappingCorrect_CorrectMotherAndFatherId()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<FamilyMemberProfile>(); });

        var mapper = configuration.CreateMapper();

        // Act
        var familyMemberModels = mapper.Map<List<FamilyMemberModel>>(PeopleWithPartners);

        Assert.NotNull(familyMemberModels);
        // Assert
        Assert.NotEmpty(familyMemberModels);
        
        Assert.Equal(PeopleWithPartners[3].FatherId, familyMemberModels[3].Fid);
        Assert.Equal(PeopleWithPartners[3].MotherId, familyMemberModels[3].Mid);
    }
    
    // ** ASCENDANTS MAPPING TESTS ** //
    [Fact]
    public void EnsureAscendantsMappingCorrect_CorrectMotherAndFatherId()
    {
        // Arrange
        var configuration = new MapperConfiguration(cfg => { cfg.AddProfile<FamilyMemberProfile>(); });

        var mapper = configuration.CreateMapper();

        // Act
        var familyMemberModels = mapper.Map<List<FamilyMemberModel>>(People);
        
        Assert.NotNull(familyMemberModels);
        // Assert
        Assert.NotEmpty(familyMemberModels);
        
        Assert.Equal(People[0].FatherId, familyMemberModels[0].Fid);
        Assert.Equal(People[0].MotherId, familyMemberModels[0].Mid);
        
    }
}