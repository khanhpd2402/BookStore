using LibraryCore.Models;
using LibraryCore.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages
{
    public class DetailModel : PageModel
    {
        public LibraryCore.Models.Book Book { get; set; }

        private readonly IUnitOfWork _unitOfWork;
        public DetailModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Book = _unitOfWork.BookRepository.Find(id);
        }
    }
}
