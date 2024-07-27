using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models;

public class Recipe
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    [Required]
    public string Instructions { get; set; }

    // Navigation property for ingredients
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    [Range(1, 360)]
    public int PrepTimeInMinutes { get; set; }

    [Range(1, 360)]
    public int CookTimeInMinutes { get; set; }

    public int Servings { get; set; }

    [Url]
    public string ImageUrl { get; set; }

    public List<string> Tags { get; set; } = new List<string>();

    [Range(0, 3000)]
    public int Calories { get; set; }

    [Range(0, 300)]
    public double ProteinInGrams { get; set; }

    [Range(0, 1000)]
    public double CarbsInGrams { get; set; }

    [Range(0, 1000)]
    public double FatsInGrams { get; set; }

    [StringLength(20)]
    public string Difficulty { get; set; }

    // Navigation property for meal plans
    public List<MealPlanRecipe> MealPlanRecipes { get; set; } = new List<MealPlanRecipe>();
}
