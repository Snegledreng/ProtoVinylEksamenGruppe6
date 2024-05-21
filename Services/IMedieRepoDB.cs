using ProtoVinylEksamenGruppe6.Model;
using System.Text;

namespace ProtoVinylEksamenGruppe6.Services
{
    public interface IMedieRepoDB
    {

        Medie CreateMedie(Medie newMedie);
        Medie Update(Medie opdateretMedie);
        Medie DeleteById(int id);
        Medie GetById(int id);

        public List<Medie> GetAll();
        public List<Medie> SorterEfterTitel(List<Medie> medier);
        public List<Medie> SorterEfterTitelDESC(List<Medie> medier);
        public List<Medie> SorterEfterKunstner(List<Medie> medier);
        public List<Medie> SorterEfterKunstnerDESC(List<Medie> medier);
        public List<Medie> Search(string? query);



    }
}
