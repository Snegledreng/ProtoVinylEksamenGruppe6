using ProtoVinylEksamenGruppe6.Model;
using System.Reflection;

namespace ProtoVinylEksamenGruppe6.Model
{
    public class Medie
    {
        //Properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Release { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public string Price { get; set; }
        public string Type { get; set; }
        public string VinylType { get; set; }


        //Konstruktør
        public Medie() { }
    }
}