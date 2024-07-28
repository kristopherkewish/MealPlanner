using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MealPlanner.Models;

public class MealPlanRecipe
{
    [Key, Column(Order = 0)]
    public int MealPlanId { get; set; }

    [ForeignKey("MealPlanId")]
    public MealPlan MealPlan { get; set; }

    [Key, Column(Order = 1)]
    public int RecipeId { get; set; }

    [ForeignKey("RecipeId")]
    public Recipe Recipe { get; set; }
}
