#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models;

public class Dish
{
    [Key]
    public int DishId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public int Calories {get;set;}
    [Required]
    public int Tastiness {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    public int ChefId {get;set;}
    public Chef? Chef {get;set;}
    [Required] 
    public DateTime CreatedAt = DateTime.Now;
    [Required]
    public DateTime UpdatedAt = DateTime.Now;
}