using ProtoVinylEksamenGruppe6.Model;
using System.Text;

namespace ProtoVinylEksamenGruppe6.Services
{

    /// <summary>
    /// 
    /// </summary>
    public interface IMedieRepoDB
    {
        /// <summary>
        /// Opretter et nyt medie i databasen.
        /// </summary>
        /// <param name="newMedie">Det nye medieobjekt, som skal oprettes.</param>
        /// <returns>Returnerer det nyoprettede medieobjekt.</returns>
        Medie CreateMedie(Medie newMedie);


        /// <summary>
        /// Opdaterer et eksisterende medie i databasen.
        /// </summary>
        /// <param name="opdateretMedie">Det opdaterede medieobjekt.</param>
        /// <returns>Returnerer det opdaterede medieobjekt.</returns>
        Medie Update(Medie opdateretMedie);


        /// <summary>
        /// Sletter et medie fra databasen ved hjælp af mediets ID.
        /// </summary>
        /// <param name="id">ID'et på det medie som skal slettes.</param>
        /// <returns>Returnerer intet. Metoden sletter mediet fra databasen uden at returnerer nogen data.</returns>
        Medie DeleteById(int id);


        /// <summary>
        /// Henter et medie fra databasen ved hjælp af mediets ID.
        /// </summary>
        /// <param name="id">ID'et på det medie som skal hentes fra databasen.</param>
        /// <returns>Returnerer mediet med det specifikke ID.</returns>
        Medie GetById(int id);

        public List<Medie> GetAll();
        public List<Medie> SorterEfterTitel(List<Medie> medier);
        public List<Medie> SorterEfterTitelDESC(List<Medie> medier);
        public List<Medie> SorterEfterKunstner(List<Medie> medier);
        public List<Medie> SorterEfterKunstnerDESC(List<Medie> medier);
        public List<Medie> Search(string? query);



    }
}
