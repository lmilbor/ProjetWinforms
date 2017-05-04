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
            string queryString = @"Select P.Login, P.Nom, P.Prenom, T.IdTache, T.Libelle, T.Annexe As EstAnnexe, A.Libelle As LibelleActivite, 
                                   T.Description, TP.Numero, TP.DureePrevue, TP.DureeRestanteEstimee, 
                                   M.Libelle As Module, L.Nom As Logiciel, V.NumeroVersion
                                   from jo.Personne P
                                   inner join jo.Tache T on T.Login = P.Login
                                   left outer join jo.TacheProd TP on TP.IdTache = T.IdTache
                                   left outer join jo.Version V on TP.NumeroVersion = V.NumeroVersion
                                   left outer join jo.Activite A on T.CodeActivite = A.CodeActivite
                                   left outer join jo.Module M on TP.CodeModule = M.CodeModule
                                   left outer join jo.Logiciel L on V.CodeLogiciel = L.CodeLogiciel ";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetListePersonneFromReader(listePersonne, reader);
                }
            }
            return listePersonne;
        }

        static public void GetListePersonneFromReader(List<Personne> listePersonne, SqlDataReader reader)
        {
            while (reader.Read())
            {
                string loginPersonne = (string)reader["Login"];
                Personne personne = null;

                if (listePersonne.Count == 0 || listePersonne[listePersonne.Count - 1].Login != loginPersonne)
                {
                    personne.Login = (string)reader["Login"];
                    personne.Nom = (string)reader["Nom"];
                    personne.Prenom = (string)reader["Prenom"];
                    personne.ListeTacheProd = new List<TacheProd>();
                    personne.ListeTacheAnnexe = new List<Tache>();
                }
                else
                    personne = listePersonne[listePersonne.Count - 1];

                bool estAnnexe = (bool)reader["EstAnnexe"];
                var tache = new Tache();


                tache.IdTache = (string)reader["IdTache"];
                tache.Libelle = (string)reader["Libelle"];
                tache.EstAnnexe = (bool)reader["EstAnnexe"];
                tache.Description = (string)reader["Description"];

                if (!estAnnexe)
                {
                    ((TacheProd)tache).Numero = (int)reader["Numero"];
                    ((TacheProd)tache).DureePrevue = (float)reader["DureePrevue"];
                    ((TacheProd)tache).DureeRestanteEstimee = (float)reader["DureeRestanteEstimee"];
                    ((TacheProd)tache).Version.NumeroVersion = (float)reader["Version"];
                    ((TacheProd)tache).Logiciel.Nom = (string)reader["Logiciel"];
                    ((TacheProd)tache).Module.Libellé = (string)reader["Module"];

                    personne.ListeTacheProd.Add((TacheProd)tache);
                }
                else
                    personne.ListeTacheAnnexe.Add(tache);

            }
        }
    }
}
