using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public Species Species { get; set; }
    public int Age { get; set; }
    [Required]
    public Gender Gender { get; set; }
  }

  public enum Species
  {
    Cat,
    Dog
  }

  public enum Gender
  {
    Male,
    Female
  }
}