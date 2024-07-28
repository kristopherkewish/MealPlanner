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
    public class IndexModel : PageModel
    {
        private readonly MealPlanner.Data.MealPlannerContext _context;

        public IndexModel(MealPlanner.Data.MealPlannerContext context)
        {
            _context = context;
        }

        public IList<MealPlan> MealPlan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            MealPlan = await _context.MealPlan.ToListAsync();
        }
    }
}
