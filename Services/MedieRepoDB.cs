using Microsoft.Data.SqlClient;
using ProtoVinylEksamenGruppe6.Model;

namespace ProtoVinylEksamenGruppe6.Services
{
    public class MedieRepoDB : IMedieRepoDB
    {

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
                medie.Titel = reader.GetString(1);
                medie.Kunstner = reader.GetString(2);
                medie.År = reader.GetInt32(3);
                medie.Genre = reader.GetString(4);
                medie.Stand = reader.GetString(5);
                medie.Pris = reader.GetString(6);
                medie.Type = reader.GetString(7);
                if (!reader.IsDBNull(8))
                {
                    medie.VinylType = reader.GetString(8);
                }
                medie.Reserveret = reader.GetBoolean(9);
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
            SqlCommand command = new SqlCommand("SELECT vm.medie_ID, vm.titel, vm.kunstner, vm.år, vg.Genre, vs.stand, vm.pris, vm.type, vm.vinyltype, vm.reserveret FROM dbo.Vinyl_Medie vm INNER JOIN  dbo.Vinyl_Genre vg ON vm.genre = vg.Id INNER JOIN dbo.Vinyl_Stand vs ON vm.stand = vs.Id;", conn);
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