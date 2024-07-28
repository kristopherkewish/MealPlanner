using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner.Pages.MealPlans
{
    public class DetailsModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public DetailsModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public MealPlan MealPlan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealplan = await _context.MealPlan.FirstOrDefaultAsync(m => m.Id == id);
            if (mealplan == null)
            {
                return NotFound();
            }
            else
            {
                MealPlan = mealplan;
            }
            return Page();
        }
    }
}
