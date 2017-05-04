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
        static public List<Personne> GetListePersonne()
        {
            var listePersonne = new List<Personne>();
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
                                   left outer join jo.Logiciel L on V.CodeLogiciel = L.CodeLogiciel 
                                   Order by 1";

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

        static public List<Personne> GetListePersonneFromReader(List<Personne> listePersonne, SqlDataReader reader)
        {
            while (reader.Read())
            {
                string loginPersonne = (string)reader["Login"];
                Personne personne = new Personne();

                if (listePersonne.Count == 0 || listePersonne[listePersonne.Count - 1].Login != loginPersonne)
                {
                    personne.Login = (string)reader["Login"];
                    personne.Nom = (string)reader["Nom"];
                    personne.Prenom = (string)reader["Prenom"];
                    personne.ListeTacheProd = new List<TacheProd>();
                    personne.ListeTacheAnnexe = new List<Tache>();
                    listePersonne.Add(personne);
                }
                else
                    personne = listePersonne[listePersonne.Count - 1];

                bool estAnnexe = (bool)reader["EstAnnexe"];
                var tache = new Tache();


                tache.IdTache = (Guid)reader["IdTache"];
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
            return listePersonne;
        }

        //public static List<Activité> GetListeActivite()
        //{

        //}
    }
}
