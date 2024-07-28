using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner.Pages.MealPlans
{
    public class EditModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public EditModel(MealPlanner.Data.MealPlannerContext context)
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

            var mealplan =  await _context.MealPlan.FirstOrDefaultAsync(m => m.Id == id);
            if (mealplan == null)
            {
                return NotFound();
            }
            MealPlan = mealplan;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(MealPlan.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MealPlanExists(int id)
        {
            return _context.MealPlan.Any(e => e.Id == id);
        }
    }
}
