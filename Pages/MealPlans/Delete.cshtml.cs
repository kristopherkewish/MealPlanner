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
    public class DeleteModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public DeleteModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealplan = await _context.MealPlan.FindAsync(id);
            if (mealplan != null)
            {
                MealPlan = mealplan;
                _context.MealPlan.Remove(MealPlan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
