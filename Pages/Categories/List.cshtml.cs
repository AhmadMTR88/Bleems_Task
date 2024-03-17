using Bleems_Task.Data;
using Bleems_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bleems_Task.Pages.Categories
{
    public class ListModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<ProductCategory> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.ProductCategories.ToListAsync();
        }
    }
}
