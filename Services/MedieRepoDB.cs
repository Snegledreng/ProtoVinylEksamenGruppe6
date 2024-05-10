using Microsoft.Data.SqlClient;
using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public class MedieRepoDB : IMedieRepoDB
    {
        private List<Medie> _medieListe;

        public MedieRepoDB()
        {
            MedieRepoDB _medieliste = new MedieRepoDB();
        }

        public Medie Add(Medie newMedie)
        {
            throw new NotImplementedException();
        }

        public Medie Update(int id, Medie updatedMedie)
        {
            throw new NotImplementedException();
        }

        public Medie DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Medie ReadMedie(SqlDataReader reader)
        {
            {
                Medie medie = new Medie();
                medie.Titel = reader.GetString(0);
                medie.Kunstner = reader.GetString(1);
                medie.År = reader.GetInt32(2);
                medie.Genre = reader.GetString(3);
                medie.Stand = reader.GetString(4);
                medie.Pris = reader.GetString(5);
                medie.Type = reader.GetString(6);
                medie.VinylType = reader.GetString(7);
                medie.Reserveret = reader.GetBoolean(8);
                return medie;
            }
        }

        public Medie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medie> GetAll()
        {
            List<Medie> medier = new List<Medie>();
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Vinyl_Medie", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medie medie = ReadMedie(reader);
                medier.Add(medie);
            }
            conn.Close();
            return medier;
        }

    }
}