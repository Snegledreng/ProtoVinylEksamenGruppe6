using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public interface IReservationRepoDB
    {
        public List<Reservation> GetAll(string typestring);

    }
}
