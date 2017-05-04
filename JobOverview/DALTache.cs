using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    static public class DALTache
    {

        static public List<Personne> GetListePersonne(List<Personne> listePersonne)
        {
            listePersonne = null;
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string queryString = @"Select P.Login, P.Nom, P.Prenom, T.IdTache, T.Libelle, T.Annexe As EstAnnexe, 
                                   A.Libelle As LibelleActivite, T.Description, TP.Numero, TP.DureePrevue, TP.DureeRestanteEstimee, 
                                   TP.CodeModule As Module, TP.NumeroVersion As Version, TP.CodeLogicielVersion As Logiciel
                                   from jo.Personne P
                                   inner join jo.Tache T on T.Login = P.Login
                                   left outer join jo.TacheProd TP on TP.IdTache = T.IdTache
                                   left outer join jo.Version V on TP.NumeroVersion = V.NumeroVersion
                                   left outer join jo.Activite A on T.CodeActivite = A.CodeActivite";

            using(var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    GetListePersonneFromReader(reader);
                }
            }
            return listePersonne;

        }

        static public void GetListePersonneFromReader(SqlDataReader reader)
        {
            while (reader.Read())
            {
                var personne = new Personne();
                personne.Login = (string)reader["Login"];
                personne.Nom = (string)reader["Nom"];
                personne.Prenom = (string)reader["Prenom"];

                var tacheProd = new TacheProd();

                

    }
        }
    }
}
