using WhoIsMyGranddaddy.Data.Entities;

namespace WhoIsMyGranddaddy.Tests;

public class TestsBase
{
    protected readonly List<PersonWithPartner> PeopleWithPartners = new()
    {
        new PersonWithPartner()
        {
            Id = 1,
            BirthDate = DateTime.Now,
            FatherId = null,
            MotherId = null,
            IdentityNumber = "ID1",
            Name = "Heinrich",
            Surname = "van Wyk",
            PartnerId = 2
        },
        new PersonWithPartner
        {
            Id = 2,
            BirthDate = DateTime.Now,
            FatherId = null,
            MotherId = null,
            IdentityNumber = "ID2",
            Name = "Heinrich",
            Surname = "van Wyk",
            PartnerId = 1
        },
        new PersonWithPartner
        {
            Id = 3,
            BirthDate = DateTime.Now,
            FatherId = null,
            MotherId = null,
            IdentityNumber = "ID2",
            Name = "Heinrich",
            Surname = "van Wyk",
            PartnerId = null
        },
        new PersonWithPartner
        {
            Id = 4,
            BirthDate = DateTime.Now,
            FatherId = 1,
            MotherId = 2,
            IdentityNumber = "ID2",
            Name = "Heinrich",
            Surname = "van Wyk",
            PartnerId = null
        }
        
    };

    protected readonly List<Person> People = new()
    {
        new Person
        {
            Id = 3,
            BirthDate = DateTime.Now,
            FatherId = 1,
            MotherId = 2,
            IdentityNumber = "ID1",
            Name = "Heinrich",
            Surname = "van Wyk",
        }
    };
}