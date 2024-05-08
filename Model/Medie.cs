using ProtoVinylEksamenGruppe6.Model;
using System.Reflection;

namespace ProtoVinylEksamenGruppe6.Model
{
    public class Medie
    {
        //Properties
        public string Titel { get; set; }
        public string Kunstner { get; set; }
        public int År { get; set; }
        public string Genre { get; set; }
        public string Stand { get; set; }
        public string Pris { get; set; }
        public string Type { get; set; }
        public string VinylType { get; set; }
        public bool Reserveret {  get; set; }

        //Default Konstruktør
        public Medie() { }
    }
}