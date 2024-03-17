using Bleems_Task.Data;
using Bleems_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bleems_Task.Pages.Categories
{
    public class AddModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        public AddModel(AppDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        [BindProperty]
        public ProductCategory Category { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Category.IsActive = true;
            Category.CreatedOndate = DateTime.Now;

            _unitOfWork.CategoryRepository.Add(Category);
            _unitOfWork.SaveChanges();

            return RedirectToPage("/Categories/List");
        }
    }
}
