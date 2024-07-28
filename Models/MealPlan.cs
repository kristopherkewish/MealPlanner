using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models;

public class MealPlan
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(1000)]
    public string Description { get; set; }

    public List<MealPlanRecipe> MealPlanRecipes { get; set; } = new List<MealPlanRecipe>();

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

    [Range(0, 7)]
    public int Duration { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
