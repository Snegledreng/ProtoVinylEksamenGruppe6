using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public interface IMedieRepoDB
    {

        Medie Add(Medie newMedie);
        Medie Update(int id, Medie updatedMedie);
        Medie DeleteById(int id);
        Medie GetById(int id);
        public List<Medie> GetAll(string typestring);

    }
}
