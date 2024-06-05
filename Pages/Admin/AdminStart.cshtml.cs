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

            Reservationer = _repo.GetAll();
        }

        public IActionResult OnPostFjernReservation(int id)
        {
            return RedirectToPage("AdminFjernReservation", new { id = id });
        }

    }
}
