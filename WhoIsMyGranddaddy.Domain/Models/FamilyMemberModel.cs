namespace WhoIsMyGranddaddy.Domain.Models;

public class FamilyMemberModel
{
    public int Id { get; init; }
    public int[]? Pids { get; set; }
    public int? Mid { get; set; }
    public int? Fid { get; set; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string FullName => $"{Name} {Surname}";
    public string IdentityNumber { get; set; }
    public DateTime BirthDate { get; set; }
}

