using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

		[BindProperty] public Category Category { get; set; }

		public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The display Order cannot exactly match the Name");
            }
            if (!ModelState.IsValid)
            {
                return Page();
			}
			await _db.Category.AddAsync(Category);
			await _db.SaveChangesAsync();
            TempData["succes"] = "Category Created Succesfully.";
			return RedirectToPage("Index");
        }
    }
}
