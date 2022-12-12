using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

		[BindProperty] public Category Category { get; set; }

		public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var CategoryFromDb = _db.Category.Find(Category.Id);

            if (CategoryFromDb != null)
            {
                _db.Category.Remove(CategoryFromDb);
                await _db.SaveChangesAsync();
				TempData["succes"] = "Category Deleted Succesfully.";
				return RedirectToPage("Index");
            }
            return Page();
		}
    }
}
