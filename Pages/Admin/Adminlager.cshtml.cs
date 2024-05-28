using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminlagerModel : PageModel
    {
        private readonly IMedieRepoDB _repo;

        public AdminlagerModel(IMedieRepoDB repo)
        {
            _repo = repo;
        }

        public List<Medie> Medier { get; set; }

        public void OnGet()
        {
            Medier = _repo.GetAll();
        }
        public IActionResult OnPostSorterTitel()
        {
            Medier = _repo.GetAll();
            Medier = _repo.SorterEfterTitel(Medier);
            return Page();
        }
        public IActionResult OnPostSorterTitelDESC()
        {
            Medier = _repo.GetAll();
            Medier = _repo.SorterEfterTitelDESC(Medier);
            return Page();
        }
        public IActionResult OnPostSorterKunstner()
        {
            Medier = _repo.GetAll();
            Medier = _repo.SorterEfterKunstner(Medier);
            return Page();
        }
        public IActionResult OnPostSorterKunstnerDESC()
        {
            Medier = _repo.GetAll();
            Medier = _repo.SorterEfterKunstnerDESC(Medier);
            return Page();
        }
        public IActionResult OnPostSearch(string query)
        {
            Medier = _repo.Search(query);
            return Page();
        }
        public IActionResult OnPostUpdate(int id)
        {
            return RedirectToPage("AdminUpdate", new { id = id });
        }
        public IActionResult OnPostDelete(int id)
        {
            return RedirectToPage("AdminDelete", new { id = id });
        }

        public IActionResult OnPostOpret()
        {
            return RedirectToPage("AdminOpret");
        }
    }
}
