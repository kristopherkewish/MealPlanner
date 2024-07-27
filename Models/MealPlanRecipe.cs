using System;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models;

public class MealPlanRecipe
{
    public int MealPlanId { get; set; }
    public MealPlan MealPlan { get; set; }

    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}