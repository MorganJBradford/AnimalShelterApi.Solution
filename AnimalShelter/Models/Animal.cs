using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Animal
  {
    public int AnimalId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [RegularExpression("Dog|Cat", ErrorMessage = "The species options are 'Dog' and 'Cat'")]
    public string Species { get; set; }
    public int Age { get; set; }
    [Required]
    [RegularExpression("F|M", ErrorMessage = "The gender options are 'F' and 'm'")]
    public string Gender { get; set; }
  }
}