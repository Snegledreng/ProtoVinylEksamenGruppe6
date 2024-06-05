using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminUpdateModel : PageModel
    {
        private readonly IMedieRepoDB _repo;

        public AdminUpdateModel(IMedieRepoDB repo)
        {
            _repo = repo;
        }

        public Medie OldMedie { get; set; }

        [BindProperty] public string NyKunstner { get; set; }
        [BindProperty] public string NyTitel { get; set; }
        [BindProperty] public int Ny≈r { get; set; }
        [BindProperty] public string NyGenre { get; set; }
        [BindProperty] public string NyStand { get; set; }
        [BindProperty] public int NyPris { get; set; }
        [BindProperty] public string NyType { get; set; }
        [BindProperty] public string NyVinylType { get; set; }
        public string Genre { get; set; }
        public string Stand { get; set; }

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

            OldMedie = _repo.GetById(Id);
            NyKunstner = OldMedie.Kunstner;
            NyTitel = OldMedie.Titel;
            Ny≈r = OldMedie.≈r;
            NyGenre = OldMedie.Genre;
            NyStand = OldMedie.Stand;
            NyPris=OldMedie.Pris;
            NyType = OldMedie.Type;
            NyVinylType = OldMedie.VinylType;


            return Page();
        }

        public IActionResult OnPostUpdate(int Id)
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
                "B¯rnemusik" => "15",
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

            Medie opdateretMedie = new Medie();
            opdateretMedie.Id = Id;
            opdateretMedie.Kunstner = NyKunstner;
            opdateretMedie.Titel = NyTitel;
            opdateretMedie.≈r = Ny≈r;
            opdateretMedie.Genre = Genre;
            opdateretMedie.Stand = Stand;
            opdateretMedie.Pris = NyPris;
            opdateretMedie.Type = NyType;
            opdateretMedie.VinylType = NyVinylType;


            _repo.Update(opdateretMedie);

            return RedirectToPage("Adminlager");
        }






        public IActionResult OnPostCancel()
        {
            return RedirectToPage("Adminlager");
        }
    }
}
