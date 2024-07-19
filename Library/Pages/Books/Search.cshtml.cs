using LibraryCore.Models;
using LibraryCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Book
{
    public class SearchModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<LibraryCore.Models.Book> Books { get; set; }
        public IList<Category> Categories { get; set; }

        public void OnGet(List<int> cid, int? pages, string? name)
        {
            Categories = _unitOfWork.CategoryRepository.GetAll();
            var all = _unitOfWork.BookRepository.GetAll().Where(x => x.Status.Value).ToList();

            if (cid != null && cid.Any())
            {
                all = all.Where(x => cid.Contains(x.CategoryId)).ToList();
            }

            if (!pages.HasValue)
            {
                pages = 1;
            }

            if (!String.IsNullOrEmpty(name))
            {
                all = all.Where(x =>
                    x.Title.ToLower().Contains(name.ToLower()) || x.Author.Fullname.ToLower().Contains(name.ToLower())).ToList();
            }

            ViewData["idValue"] = cid;
            ViewData["pages"] = pages;
            ViewData["search"] = name;
            ViewData["countPage"] = Math.Ceiling(all.Count / 3d);
            Books = all.Skip((pages.Value - 1) * 3).Take(8).ToList();
        }
    }
}
