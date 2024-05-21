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


        public IActionResult OnGet(int Id)
        {
            DeleteMedie = _repo.GetById(Id);

            if (DeleteMedie == null)
            {
                return RedirectToPage(nameof(Index));
            }
            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            _repo.DeleteById(Id);
            return RedirectToPage("Adminlager");
        }
    }
}
