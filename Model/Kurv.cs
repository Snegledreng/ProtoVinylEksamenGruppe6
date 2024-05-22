namespace ProtoVinylEksamenGruppe6.Model
{
    public class Kurv
    {
        public List<Medie> MedieList { get; set; }

        //default constructor uden parametre
        public Kurv()
        {
            MedieList = new List<Medie>();
        }
    }
}
