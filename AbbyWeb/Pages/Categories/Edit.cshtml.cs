using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

		[BindProperty] public Category Category { get; set; }

		public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
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
			_db.Category.Update(Category);
			await _db.SaveChangesAsync();
			TempData["succes"] = "Category Edited Succesfully.";
			return RedirectToPage("Index");
        }
    }
}
