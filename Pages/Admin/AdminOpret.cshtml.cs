using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminOpretModel : PageModel
    {
        private readonly IMedieRepoDB _repo;
        public AdminOpretModel(IMedieRepoDB repo)
        {
            _repo = repo;
        }

        [BindProperty] public string Titel { get; set; }

        [BindProperty] public string NyGenre { get; set; }
        public string Genre { get; set; }

        [BindProperty] public int År { get; set; }

        [BindProperty] public string Kunstner { get; set; }

        [BindProperty] public string NyStand { get; set; }
        public string Stand { get; set; }

        [BindProperty] public int Pris { get; set; }

        [BindProperty] public string Type { get; set; }

        [BindProperty] public string VinylType { get; set; }


        public AdminBruger adminBruger { get; set; } = new AdminBruger();

        public void OnGet()
        {
            try
            {
                adminBruger = SessionHelper.Get<AdminBruger>(HttpContext);
            }
            catch
            {
                // ignored
            }
        }

        public IActionResult OnPost()
        {
            Genre = NyGenre switch
            {
                "Pop" => "1",
                "Hiphop" => "2",
                "Rock" => "3",
                "RnB" => "4",
                "Soul" => "5",
                "Reggae" => "6",
                "Country" => "7",
                "Funk" => "8",
                "Folk" => "9",
                "Jazz" => "10",
                "Disco" => "11",
                "Klassisk" => "12",
                "Elektronisk" => "13",
                "Blues" => "14",
                "Børnemusik" => "15",
                "New-age" => "16",
                "Ska" => "17",
                "Traditionelt" => "18",
                "Indie" => "19",
                _ => Genre
            };

            Stand = NyStand switch
            {
                "Mint" => "1",
                "NM" => "2",
                "VG+" => "3",
                "VG" => "4",
                "Bad" => "5",
                "Ny" => "10",
                _ => Stand
            };

            Medie nyMedie = new Medie();
            nyMedie.Titel = Titel;
            nyMedie.Genre = Genre;
            nyMedie.Kunstner = Kunstner;
            nyMedie.År = År;
            nyMedie.Pris = Pris;
            nyMedie.Type = Type;
            nyMedie.VinylType = VinylType;
            if (nyMedie.VinylType == null)
                nyMedie.VinylType = " ";
            nyMedie.Stand = Stand;
            _repo.CreateMedie(nyMedie);

            return RedirectToPage("Adminlager");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Adminlager");
        }
    }
}
