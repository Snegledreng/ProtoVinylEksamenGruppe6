namespace ProtoVinylEksamenGruppe6.Model
{
    public class Reservation
    {
        //instansfelter
        private int _id;
        private Medie _medie;
        private string _kundeNavn;
        private string _kundeTelefon;

        //properties
        public int Id { get { return _id; } set { _id = value; } }
        public Medie Medie { get { return _medie; } set { _medie = value; } }
        public string KundeNavn
        {
            get { return _kundeNavn; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Navn skal minimum være 2 tegn langt");
                }

                if (value.Trim().Length < 2)
                {
                    throw new ArgumentException("Navn skal være minimum 2 tegn langt");
                }
                _kundeNavn = value;

            }


            
        }
        public string KundeTelefon
        {
            get { return _kundeTelefon; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Telefon nummer skal være mellem 8-12 tegn langt");
                }
                if (value.Length < 8 || 12 < value.Length)
                {
                    throw new ArgumentException("Telefon nummer skal være mellem 8-12 tegn langt");
                }
                _kundeTelefon = value;


               
            }
        }

        //konstruktør
        public Reservation() { }
    }
}
