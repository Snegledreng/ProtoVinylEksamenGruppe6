using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminStartModel : PageModel
    {
        private readonly IReservationRepoDB _repo;

        public AdminStartModel(IReservationRepoDB repo)
        {
            _repo = repo;
        }

        public List<Reservation> Reservationer { get; set; }

        public void OnGet()
        {
            Reservationer = _repo.GetAll("Select * from Vinyl_Reservation INNER JOIN Vinyl_Medie ON Vinyl_Reservation.medie = Vinyl_Medie.medie_ID INNER JOIN  Vinyl_Genre ON Vinyl_Medie.genre = Vinyl_Genre.Id INNER JOIN Vinyl_Stand ON Vinyl_Medie.stand = Vinyl_Stand.Id;");
        }
    }
}
