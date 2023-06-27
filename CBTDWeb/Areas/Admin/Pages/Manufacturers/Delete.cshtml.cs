using CBTD.ApplicationCore.Models;
using CBTD.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CBTDWeb.Pages.Manufacturers
{
    public class DeleteModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        [BindProperty]
        public Manufacturer objManufacturer { get; set; }


        public DeleteModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet(int? id)
        {
            objManufacturer = new Manufacturer();


            objManufacturer = _unitOfWork.Manufacturer.GetById(id);


            if (objManufacturer == null) // could be a bad id
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _unitOfWork.Manufacturer.Delete(objManufacturer); //Removes to memory
            TempData["success"] = "Manufacturer Deleted Successfully";


            _unitOfWork.Commit(); //saves to DB

            return RedirectToPage("./Index");
        }
    }
}
