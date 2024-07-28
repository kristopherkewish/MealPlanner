using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models;

public class Ingredient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public double Quantity { get; set; }

    [StringLength(50)]
    public string Unit { get; set; }

    public int RecipeId { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe Recipe { get; set; }
}