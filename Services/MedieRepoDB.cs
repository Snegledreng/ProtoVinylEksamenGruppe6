using System.ComponentModel;
using Microsoft.Data.SqlClient;
using ProtoVinylEksamenGruppe6.Model;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.PortableExecutable;
using System.Collections.Immutable;

namespace ProtoVinylEksamenGruppe6.Services
{
    public class MedieRepoDB : IMedieRepoDB
    {

        public Medie CreateMedie(Medie newMedie)
        {
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Vinyl_Medie values (@titel,@kunstner,@år,@genre,@stand,@pris,@type,@vinyltype,@reserveret)", conn);
            command.Parameters.AddWithValue("@titel", newMedie.Titel);
            command.Parameters.AddWithValue("@kunstner", newMedie.Kunstner);
            command.Parameters.AddWithValue("@år", newMedie.År);
            command.Parameters.AddWithValue("@genre", newMedie.Genre);
            command.Parameters.AddWithValue("@stand", newMedie.Stand);
            command.Parameters.AddWithValue("@pris", newMedie.Pris);
            command.Parameters.AddWithValue("@type", newMedie.Type);
            command.Parameters.AddWithValue("@vinyltype", newMedie.VinylType);
            command.Parameters.AddWithValue("@reserveret", 0);


            int r = command.ExecuteNonQuery();
            if (r == 0)
            {
                throw new ArgumentException("Nul rækker ændret. " + newMedie + " er ikke oprettet.");
            }
            conn.Close();
            return newMedie;
        }
        
        public Medie Update(Medie opdateretMedie)
        {
            SqlConnection connection = new SqlConnection(Secret.ConnectionString);
            connection.Open();

            SqlCommand cmd =
                new SqlCommand(
                    "UPDATE Vinyl_Medie SET Kunstner = @kunstner, Titel = @titel, År = @år, Genre = @genre, Stand = @stand, Pris = @pris, Type = @type, VinylType = @vinyltype WHERE Medie_ID = @id",
                    connection);
            cmd.Parameters.AddWithValue("@Id", opdateretMedie.Id);
            cmd.Parameters.AddWithValue("@kunstner", opdateretMedie.Kunstner);
            cmd.Parameters.AddWithValue("@titel", opdateretMedie.Titel);
            cmd.Parameters.AddWithValue("@år", opdateretMedie.År);
            cmd.Parameters.AddWithValue("@genre", opdateretMedie.Genre);
            cmd.Parameters.AddWithValue("@stand", opdateretMedie.Stand);
            cmd.Parameters.AddWithValue("@pris", opdateretMedie.Pris);
            cmd.Parameters.AddWithValue("@type", opdateretMedie.Type);
            if (opdateretMedie.VinylType != null)
            {
                cmd.Parameters.AddWithValue("@vinyltype", opdateretMedie.VinylType);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Vinyltype", " ");
            }

            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                throw new ArgumentException("Nul rækker ændret. Medie med ID " + "x" + " blev ikke ændret.");
            }
            if (rowsAffected > 1)
            {
                throw new ArgumentException("du har fucked hele databasen");
            }

            connection.Close();
            return opdateretMedie;
        }

        public void DeleteById(int id)
        {
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Vinyl_Medie WHERE medie_ID = @id", conn);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            conn.Close();
        }

        public Medie ReadMedie(SqlDataReader reader)
        {
            {
                Medie medie = new Medie();
                medie.Id = reader.GetInt32(0);
                medie.Titel = reader.GetString(1);
                medie.Kunstner = reader.GetString(2);
                medie.År = reader.GetInt32(3);
                medie.Genre = reader.GetString(4).Trim();
                medie.Stand = reader.GetString(5).Trim();
                medie.Pris = reader.GetInt32(6);
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
            Medie medie = null;
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT vm.medie_ID, vm.titel, vm.kunstner, vm.år, vg.Genre, vs.stand, vm.pris, vm.type, vm.vinyltype, vm.reserveret FROM dbo.Vinyl_Medie vm INNER JOIN  dbo.Vinyl_Genre vg ON vm.genre = vg.Id INNER JOIN dbo.Vinyl_Stand vs ON vm.stand = vs.Id WHERE Medie_ID=@Id", conn);
            command.Parameters.AddWithValue("@Id", id);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                medie = ReadMedie(reader);
            }
            conn.Close();
            return medie;
        }

        public List<Medie> GetAll()
        {
            List<Medie> medier = new List<Medie>();
            SqlConnection conn = new SqlConnection(Secret.ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("SELECT vm.medie_ID, vm.titel, vm.kunstner, vm.år, vg.Genre, vs.stand, vm.pris, vm.type, vm.vinyltype, vm.reserveret FROM dbo.Vinyl_Medie vm INNER JOIN  dbo.Vinyl_Genre vg ON vm.genre = vg.Id INNER JOIN dbo.Vinyl_Stand vs ON vm.stand = vs.Id ORDER BY vm.kunstner", conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Medie medie = ReadMedie(reader);
                medier.Add(medie);
            }
            conn.Close();
            return medier;
        }

        //Sorteringsfunktioner;)
        public List<Medie> SorterEfterTitel(List<Medie> medier)
        {
            return medier.OrderBy(t => t.Titel).ToList();
        }
        public List<Medie> SorterEfterTitelDESC(List<Medie> medier)
        {
            return medier.OrderByDescending(t => t.Titel).ToList();
        }

        public List<Medie> SorterEfterKunstner(List<Medie> medier)
        {
            return medier.OrderBy(t => t.Kunstner).ToList();
        }
        public List<Medie> SorterEfterKunstnerDESC(List<Medie> medier)
        {
            return medier.OrderByDescending(t => t.Kunstner).ToList();
        }

        //Søgning

        public List<Medie> Search(string? query)
        {
            List<Medie> resMedier = new List<Medie>(GetAll());

            if (!string.IsNullOrEmpty(query))
            {
                resMedier = resMedier.FindAll(m =>
                    (m.Titel != null && m.Titel.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                    (m.Kunstner != null && m.Kunstner.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                    (m.Genre != null && m.Genre.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                    (m.Stand != null && m.Stand.Contains(query, StringComparison.OrdinalIgnoreCase))
                );
            }

            return resMedier;
        }


    }
}