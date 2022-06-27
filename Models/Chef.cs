#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required]
    public string FirstName {get;set;}
    [Required]
    public string LastName {get;set;}
    [Required]
    public DateOnly DOB {get;set;}
    public List<Dish> DishesMade {get;set;} = new List<Dish>();
    [Required]
    public DateTime CreatedAt = DateTime.Now;
    [Required]
    public DateTime UpdatedAt = DateTime.Now;
}