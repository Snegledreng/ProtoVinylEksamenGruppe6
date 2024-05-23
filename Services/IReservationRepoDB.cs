using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public interface IReservationRepoDB
    {
        public List<Reservation> GetAll();
        public void OpretReservation(List<Reservation> reservations);
        public Reservation GetById(int id);
        public Reservation DeleteById(int id);

    }
}
