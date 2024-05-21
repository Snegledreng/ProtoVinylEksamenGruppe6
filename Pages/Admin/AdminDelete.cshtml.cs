using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminDeleteModel : PageModel
    {
        private readonly IMedieRepoDB _repo;

        public AdminDeleteModel(IMedieRepoDB repo)
        {
            _repo = repo;
        }


        //Properties til view

        // Property for the member to be deleted
        public Medie DeleteMedie { get; set; }


        // The OnGet method retrieves the member to be deleted
        public IActionResult OnGet(int Id)
        {
            // Attempt to retrieve the member by ID
            DeleteMedie = _repo.GetById(Id);

            // If no member is found, redirect to the index page
            if (DeleteMedie == null)
            {
                return RedirectToPage(nameof(Index));
            }
            // Return to the page with the member data
            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            _repo.DeleteById(Id);
            return RedirectToPage("Adminlager");
        }


        //public void OnGet()
        //{
            
        //}

    }
}
