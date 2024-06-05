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


        public Medie DeleteMedie { get; set; }
        public AdminBruger adminBruger { get; set; } = new AdminBruger();

        public IActionResult OnGet(int Id)
        {
            try
            {
                adminBruger = SessionHelper.Get<AdminBruger>(HttpContext);
            }
            catch
            {
                // ignored
            }
            DeleteMedie = _repo.GetById(Id);

            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            _repo.DeleteById(Id);
            return RedirectToPage("Adminlager");
        }
    }
}