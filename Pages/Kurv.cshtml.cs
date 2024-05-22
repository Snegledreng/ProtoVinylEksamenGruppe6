using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProtoVinylEksamenGruppe6.Model;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages
{
    public class KurvModel : PageModel
    {


        public List<Medie> Medier { get; set; } = new List<Medie> { };
        public int TotalPris {  get; set; }

        public void OnGet()
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
    }
}
