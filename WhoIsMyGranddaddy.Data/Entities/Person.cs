using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhoIsMyGranddaddy.Data.Entities;

public class Person
{
    [Key]
    public int Id { get; set; }
    
    public int? FatherId { get; set; }
    public int? MotherId { get; set; }
    
    [ForeignKey("FatherId")]
    public Person? Father { get; set; }

    [ForeignKey("MotherId")]
    public Person? Mother { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }
    
    [Required]
    public string IdentityNumber { get; set; }
}