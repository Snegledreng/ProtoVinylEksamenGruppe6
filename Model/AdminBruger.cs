using ProtoVinylEksamenGruppe6.Services;

using System.Diagnostics.Metrics;

namespace ProtoVinylEksamenGruppe6.Model
{
    public class AdminBruger
    {
        //Konstruktør
        public AdminBruger()
        {
            IsLoggedIn = false;
        }

        //Property
        public bool IsLoggedIn { get; set; }
    }
}
