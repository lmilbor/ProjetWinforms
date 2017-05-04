using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                                LEFT OUTER JOIN jo.Release r ON r.NumeroVersion = v.NumeroVersion
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
                    logiciel.ListeVersions = new BindingList<Version>();
                    logiciel.ListeModules = new BindingList<Module>();
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
                if (reader["NumeroRelease"] != DBNull.Value)
                    version.LastNumeroRelease = (short)reader["NumeroRelease"]; 
                version.CodeLogiciel = (string)reader["CodeLogiciel"];
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
        /// <summary>
        /// Insert une nouvelle version dans la base de donnée.
        /// </summary>
        /// <param name="version">La version à ajouter.</param>
        static public void InsertVersion(Version version)
        {
            var listProduit = new BindingList<Version>();
            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"INSERT jo.Version (CodeLogiciel, DateOuverture, DateSortiePrevue, Millesime, NumeroVersion) VALUES
                                (@CodeLogiciel, @DateOuverture, @DateSortiePrevue, @Millesime, @NumeroVersion)";

            #region Définition des paramètres
            var codeLogiciel = new SqlParameter("@CodeLogiciel", DbType.String);
            var dateOuverture = new SqlParameter("@DateOuverture", DbType.DateTime);
            var dateSortiePrevue = new SqlParameter("@DateSortiePrevue", DbType.DateTime);
            var millesime = new SqlParameter("@Millesime", DbType.Int16);
            var numeroVersion = new SqlParameter("@NumeroVersion", DbType.Double);

            codeLogiciel.Value = version.CodeLogiciel;
            dateOuverture.Value = version.DateOuverture;
            dateSortiePrevue.Value = version.DateSortiePrevue;
            millesime.Value = version.Millesime;
            numeroVersion.Value = version.NumeroVersion;
            #endregion

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                //on initialise la transaction
                SqlTransaction tran = connect.BeginTransaction();

                #region Ajout des paramètres
                var command = new SqlCommand(sqlQuery, connect, tran);
                command.Parameters.Add(codeLogiciel);
                command.Parameters.Add(dateOuverture);
                command.Parameters.Add(dateSortiePrevue);
                command.Parameters.Add(millesime);
                command.Parameters.Add(numeroVersion);
                #endregion

                try
                {
                    command.ExecuteNonQuery();
                    // si tout se passe bien on commit la transaction
                    tran.Commit();
                }
                catch (Exception)
                {
                    // si un problème survient, on rollback
                    tran.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// Supprime une version de la base de donnée.
        /// </summary>
        /// <param name="version">version à supprimer.</param>
        static public void RemoveVersion(Version version)
        {
            var listProduit = new BindingList<Version>();
            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"DELETE jo.Version
                                FROM jo.Version
                                WHERE jo.Version.NumeroVersion = @NumeroVersion AND jo.Version.CodeLogiciel = @CodeLogiciel";

            #region Définition des paramètres
            var codeLogiciel = new SqlParameter("@CodeLogiciel", DbType.String);
            var numeroVersion = new SqlParameter("@NumeroVersion", DbType.Double);

            codeLogiciel.Value = version.CodeLogiciel;
            numeroVersion.Value = version.NumeroVersion;
            #endregion

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                //on initialise la transaction
                SqlTransaction tran = connect.BeginTransaction();

                #region Ajout des paramètres
                var command = new SqlCommand(sqlQuery, connect, tran);
                command.Parameters.Add(codeLogiciel);
                command.Parameters.Add(numeroVersion);
                #endregion

                try
                {
                    command.ExecuteNonQuery();
                    // si tout se passe bien on commit la transaction
                    tran.Commit();
                }
                catch (Exception)
                {
                    // si un problème survient, on rollback
                    tran.Rollback();
                    throw;
                }
            }
        }
    }
}
