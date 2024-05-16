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



        public void OnGet() {}

        public IActionResult OnPost()
        {
            if (NyGenre == "Pop")
            {
                Genre = "1";
            }
            else if(NyGenre == "Hiphop")
            {
                Genre = "2";
            }
            else if(NyGenre == "Rock")
            {
                Genre = "3";
            }
            else if (NyGenre == "RnB")
            {
                Genre = "4";
            }
            else if (NyGenre == "Soul")
            {
                Genre = "5";
            }
            else if (NyGenre == "Reggae")
            {
                Genre = "6";
            }
            else if (NyGenre == "Country")
            {
                Genre = "7";
            }
            else if (NyGenre == "Funk")
            {
                Genre = "8";
            }
            else if (NyGenre == "Folk")
            {
                Genre = "9";
            }
            else if (NyGenre == "Jazz")
            {
                Genre = "10";
            }
            else if (NyGenre == "Disco")
            {
                Genre = "11";
            }
            else if (NyGenre == "Klassisk")
            {
                Genre = "12";
            }
            else if (NyGenre == "Elektronisk")
            {
                Genre = "13";
            }
            else if (NyGenre == "Blues")
            {
                Genre = "14";
            }
            else if (NyGenre == "Børnemusik")
            {
                Genre = "15";
            }
            else if (NyGenre == "New-age")
            {
                Genre = "16";
            }
            else if (NyGenre == "Ska")
            {
                Genre = "17";
            }
            else if (NyGenre == "Traditionelt")
            {
                Genre = "18";
            }
            else if (NyGenre == "Indie")
            {
                Genre = "19";
            }

            if (NyStand == "Mint")
            {
                Stand = "1";
            }
            if (NyStand == "NM")
            {
                Stand = "2";
            }
            if (NyStand == "VG+")
            {
                Stand = "3";
            }
            if (NyStand == "VG")
            {
                Stand = "4";
            }
            if (NyStand == "Bad")
            {
                Stand = "5";
            }
            if (NyStand == "Ny")
            {
                Stand = "10";
            }



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
