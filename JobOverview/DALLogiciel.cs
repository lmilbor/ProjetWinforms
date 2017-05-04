using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    static public class DALLogiciel
    {
        /// <summary>
        /// Retourne la liste de logiciel dpuis la base de donnée.
        /// </summary>
        /// <returns></returns>
        static public List<Logiciel> GetListLogiciel()
        {
            List<Logiciel> listeLogiciel = new List<Logiciel>();

            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"SELECT l.CodeLogiciel as CodeLogiciel, l.Nom as Nom, v.Millesime as Millesime,
                                v.NumeroVersion as NumeroVersion, m.CodeModule as CodeModule, m.Libelle as Libelle
                                FROM jo.Logiciel l
                                INNER JOIN jo.Version v ON v.CodeLogiciel = l.CodeLogiciel
                                INNER JOIN jo.Module m ON m.CodeLogiciel = l.CodeLogiciel";
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(sqlQuery, connect);
                connect.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetListLogicielFromReader(listeLogiciel, reader);
                }
            }

            return listeLogiciel;
        }

        /// <summary>
        /// Remplit la liste de logiciel avec les données récupérées par le reader.
        /// </summary>
        /// <param name="listeLogiciel">La liste de logiciel à remplir.</param>
        /// <param name="reader">Le reader servant à remplir la liste</param>
        static private void GetListLogicielFromReader(List<Logiciel> listeLogiciel, SqlDataReader reader)
        {
            while (reader.Read())
            {
                #region Remplissage du logiciel

                string codeLogiciel = (string)reader["CodeLogiciel"];

                Logiciel logiciel = null;

                // On remplit le logiciel en cours

                if (listeLogiciel.Count == 0 || listeLogiciel[listeLogiciel.Count - 1].CodeLogiciel != codeLogiciel)
                {
                    logiciel = new Logiciel();
                    logiciel.CodeLogiciel = (string)reader["CodeLogiciel"];
                    logiciel.Nom = (string)reader["Nom"];
                    logiciel.ListeVersions = new List<Version>();
                    listeLogiciel.Add(logiciel);
                }
                else
                    logiciel = listeLogiciel[listeLogiciel.Count - 1];

                #endregion

                #region Remplissage de la version

                // On remplit la version en cours du logiciel en cours

                float numeroVersion = (float)reader["NumeroVersion"];

                Version version = null;

                if (logiciel.ListeVersions.Count == 0 ||
                    logiciel.ListeVersions[logiciel.ListeVersions.Count - 1].NumeroVersion != numeroVersion)
                {
                    version = new Version();
                    version.Millesime = (short)reader["Millesime"];
                    version.NumeroVersion = (float)reader["NumeroVersion"];
                    version.ListeModules = new List<Module>();
                    logiciel.ListeVersions.Add(version);
                }
                else
                    version = logiciel.ListeVersions[logiciel.ListeVersions.Count - 1];

                #endregion

                #region Remplissage du module

                // On remplit le module en cours de la version en cours

                Module module = new Module();
                module.CodeModule = (string)reader["CodeModule"];
                module.Libellé = (string)reader["Libelle"];
                version.ListeModules.Add(module);

                #endregion
            }
        }
    }
}
