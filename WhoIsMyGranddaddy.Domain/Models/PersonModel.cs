﻿namespace WhoIsMyGranddaddy.Domain.Models;

public class PersonModel
{
    public string IdentityNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public List<PersonModel> Children { get; set; }
}