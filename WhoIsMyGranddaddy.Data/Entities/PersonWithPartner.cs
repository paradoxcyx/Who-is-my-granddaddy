namespace WhoIsMyGranddaddy.Data.Entities;

public class PersonWithPartner
{
    public int Id { get; set; }
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string IdentityNumber { get; set; }
    public int? PartnerId { get; set; }
}