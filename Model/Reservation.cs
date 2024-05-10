namespace ProtoVinylEksamenGruppe6.Model
{
    public class Reservation
    {
        //instansfelter
        private Medie _medie;
        private string _kundeNavn;
        private string _kundeTelefon;

        //properties
        public Medie Medie { get { return _medie; } set { _medie = value; } }
        public string KundeNavn { get {  return _kundeNavn; } set { _kundeNavn = value; } }
        public string KundeTelefon { get { return _kundeTelefon; } set { _kundeTelefon = value; }}

        //konstruktør
        public Reservation() { }
    }
}
