using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class AdminFjernReservationModel : PageModel
    {
        private readonly IReservationRepoDB _repo;

        public AdminFjernReservationModel(IReservationRepoDB repo)
        {
            _repo = repo;
        }


        public Reservation DeleteReservation { get; set; }


        public IActionResult OnGet(int Id)
        {
            DeleteReservation = _repo.GetById(Id);

            return Page();
        }

        public IActionResult OnPost(int Id)
        {
            _repo.DeleteById(Id);
            return RedirectToPage("AdminStart");
        }
    }
}
