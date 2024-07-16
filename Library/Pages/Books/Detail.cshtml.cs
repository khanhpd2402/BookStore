using LibraryCore.Models;
using LibraryCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Library.Pages
{
    public class DetailModel : PageModel
    {
        public LibraryCore.Models.Book Book { get; set; }
        public IList<LibraryCore.Models.Book> BooksByCategory { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public DetailModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookRepository.Find(id);
            if (Book != null)
            {
                BooksByCategory = _unitOfWork.BookRepository.GetAll().Where(x => x.CategoryId == Book.CategoryId
                                                                            && x.BookId != Book.BookId
                                                                            && x.Status.Value).OrderByDescending(x => x.BookId).ToList();
                ViewData["Title"] = Book.Title;
            }

        }
    }
}
