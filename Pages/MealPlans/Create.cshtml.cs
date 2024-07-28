using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MealPlanner.Data;
using MealPlanner.Models;

namespace MealPlanner.Pages.MealPlans
{
    public class CreateModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public CreateModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MealPlan MealPlan { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MealPlan.Add(MealPlan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
