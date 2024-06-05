using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ProtoVinylEksamenGruppe6.Model;
using System.ComponentModel.DataAnnotations;
using ProtoVinylEksamenGruppe6.Services;

namespace ProtoVinylEksamenGruppe6.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste brugernavn")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Du skal indtaste password")]
        public string Password { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            AdminBruger adminBruger = new AdminBruger();
            adminBruger.IsLoggedIn = false;
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Vinyl_Users WHERE Username=@Username AND Password=@Password", conn);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                adminBruger.IsLoggedIn = true;
            }
            conn.Close();

            if (adminBruger.IsLoggedIn)
            {
                SessionHelper.Set(adminBruger,  HttpContext);
                return RedirectToPage("AdminStart");
            }

            return Page();

        }
    }
}
