using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        static public BindingList<Logiciel> GetListLogiciel()
        {
            BindingList<Logiciel> listeLogiciel = new BindingList<Logiciel>();

            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"SELECT l.CodeLogiciel as CodeLogiciel, l.Nom as Nom,
                                v.Millesime as Millesime, v.NumeroVersion as NumeroVersion, v.DateOuverture as DateOuverture, v.DateSortiePrevue as DateSortiePrevue,
                                r.NumeroRelease as NumeroRelease,
                                m.CodeModule as CodeModule, m.Libelle as Libelle
                                FROM jo.Logiciel l
                                INNER JOIN jo.Version v ON v.CodeLogiciel = l.CodeLogiciel
                                INNER JOIN jo.Module m ON m.CodeLogiciel = l.CodeLogiciel
                                INNER JOIN jo.Release r ON r.NumeroVersion = v.NumeroVersion
                                ORDER BY r.DateSetup DESC";
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
        static private void GetListLogicielFromReader(BindingList<Logiciel> listeLogiciel, SqlDataReader reader)
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
                    logiciel.ListeModules = new List<Module>();
                    listeLogiciel.Add(logiciel);
                }
                else
                    logiciel = listeLogiciel[listeLogiciel.Count - 1];

                #endregion

                #region Remplissage de la version

                // On remplit la version en cours du logiciel en cours

                Version version = new Version();
                version.Millesime = (short)reader["Millesime"];
                version.NumeroVersion = (float)reader["NumeroVersion"];
                version.DateOuverture = (DateTime)reader["DateOuverture"];
                version.DateSortiePrevue = (DateTime)reader["DateSortiePrevue"];
                version.LastNumeroRelease = (short)reader["NumeroRelease"];
                if (logiciel.ListeVersions.Count == 0 || !(logiciel.ListeVersions.Contains<Version>(version)))
                    logiciel.ListeVersions.Add(version);

                #endregion

                #region Remplissage du module

                // On remplit le module en cours du logiciel en cours

                Module module = new Module();
                module.CodeModule = (string)reader["CodeModule"];
                module.Libellé = (string)reader["Libelle"];
                if (logiciel.ListeModules.Count == 0 || !(logiciel.ListeModules.Contains<Module>(module)))
                    logiciel.ListeModules.Add(module);

                #endregion
            }
        }
    }
}
