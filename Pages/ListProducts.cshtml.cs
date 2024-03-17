using Bleems_Task.Data;
using Bleems_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bleems_Task.Pages
{
    public class ListProductsModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListProductsModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _context.Products.ToListAsync();
        }
    }
}
