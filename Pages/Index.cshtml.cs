using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMedieRepoDB _repo;

        public IndexModel(IMedieRepoDB repo)
        {
            _repo = repo;
        }

        public List<Medie> Medier { get; set; }

        public void OnGet()
        {
            Medier = _repo.GetAll();
        }
    }
}
