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
            Medier = _repo.GetAll("SELECT vm.medie_ID, vm.titel, vm.kunstner, vm.�r, vg.Genre, vs.stand, vm.pris, vm.type, vm.vinyltype, vm.reserveret FROM dbo.Vinyl_Medie vm INNER JOIN  dbo.Vinyl_Genre vg ON vm.genre = vg.Id INNER JOIN dbo.Vinyl_Stand vs ON vm.stand = vs.Id ORDER BY vm.type DESC;");
        }
    }
}