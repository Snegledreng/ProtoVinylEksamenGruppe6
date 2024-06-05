using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;
using System.ComponentModel.DataAnnotations;

namespace ProtoVinylEksamenGruppe6.Pages
{
    public class KurvModel : PageModel
    {
        private readonly IReservationRepoDB _repo;

        public KurvModel(IReservationRepoDB repo)
        {
            _repo = repo;
        }

        public List<Medie> Medier { get; set; } = new List<Medie> { };
        public int TotalPris {  get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste et navn.")]
        [StringLength(1000, MinimumLength = 2, ErrorMessage = "Navnet skal være mindst 2 tegn")]
        public string KundeNavn { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste et telefonnummer.")]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Telefonnummer skal være mellem 8-12 tegn")]
        public string KundeTelefon { get; set; }

        public void OnGet()
        {
            LoadSessionData();//Vi kalder metoden LoadSessionData
        }

        private void LoadSessionData()
        {
            Kurv kurv = null;
            try
            {
                kurv = SessionHelper.Get<Kurv>(HttpContext);
            }
            catch
            {
                kurv = new Kurv();
            }
            Medier = kurv.MedieList;

            foreach (var m in Medier)
            {
                TotalPris = TotalPris + m.Pris;
            }
        }

        public IActionResult OnPostSlet(int id)
        {
            Kurv kurv = SessionHelper.Get<Kurv>(HttpContext);
            
            Medie medieToRemove = kurv.MedieList.First(m => m.Id == id);
            kurv.MedieList.Remove(medieToRemove);

            SessionHelper.Set(kurv, HttpContext);


            return RedirectToPage();
        }

        public IActionResult OnPostOpretReservation()
        {
            if (!ModelState.IsValid)
            {
                LoadSessionData();
                return Page();
            }

            Kurv kurv = SessionHelper.Get<Kurv>(HttpContext);
            List<Reservation> reservationList = new List<Reservation>();
            foreach (var m in kurv.MedieList)
            {
                Reservation r = new Reservation();
                r.Medie = m;
                r.KundeNavn = KundeNavn;
                r.KundeTelefon = KundeTelefon;
                reservationList.Add(r);
            }
            _repo.OpretReservation(reservationList);
            SessionHelper.Clear<Kurv>(HttpContext);

            return RedirectToPage("ReservationBekræftet");
        }
    }
}
