using Microsoft.Data.SqlClient;
using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public class ReservationRepoDB : IReservationRepoDB
    {
        public Reservation ReadReservation(SqlDataReader reader)
        {
            {
                Reservation reservation = new Reservation();
                reservation.KundeNavn = reader.GetString(2);
                reservation.KundeTelefon = reader.GetString(3);
                Medie medie = new Medie();
                medie.Titel = reader.GetString(5);
                medie.Kunstner = reader.GetString(6);
                medie.År = reader.GetInt32(7);
                medie.Genre = reader.GetString(15);
                medie.Stand = reader.GetString(17);
                medie.Pris = reader.GetInt32(10);
                medie.Type = reader.GetString(11);
                if (!reader.IsDBNull(12))
                {
                    medie.VinylType = reader.GetString(12);
                }
                medie.Reserveret = reader.GetBoolean(13);
                reservation.Medie = medie;
                return reservation;
            }
        }

        public List<Reservation> GetAll(string typestring)
        {
            List<Reservation> reservationer = new List<Reservation>();
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(typestring, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reservation reservation = ReadReservation(reader);
                reservationer.Add(reservation);
            }
            conn.Close();
            return reservationer;
        }
    }
}
