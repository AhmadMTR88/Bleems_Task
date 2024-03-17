using Bleems_Task.Data;
using Bleems_Task.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bleems_Task.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddModel(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Product Product { get; set; }

        [BindProperty]
        public IFormFile PhotoFile { get; set; }
        public IList<ProductCategory> Categories { get; set; }

        public async Task OnGetAsync()
        {
            Categories = await _context.ProductCategories.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (PhotoFile != null && PhotoFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PhotoFile.CopyToAsync(stream);
                }

                Product.Photo = "/uploads/" + uniqueFileName;
            }

            Product.CreatedOndate = DateTime.Now;

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();


            return RedirectToPage("/Products/List");
        }
    }
}