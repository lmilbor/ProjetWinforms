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
        /// Retourne la liste de logiciel depuis la base de données.
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
        /// Création et remplissage d'une table mémoire à partir d'une liste de version en vue d'un ajout dans la base de donnée.
        /// </summary>
        /// <param name="listeVersion">La liste de version à ajouter.</param>
        /// <returns></returns>
        static private DataTable GetDataTableForVersion(List<Version> listeVersion)
        {
            // Créaton d'une table mémoire
            DataTable table = new DataTable();

            // Création des colonnes Nom et Prenom de type chaîne et ajout à la table (les champs ne sont jamais null si remplit depuis l'application).
            table.Columns.Add(new DataColumn("CodeLogiciel", typeof(string)));

            table.Columns.Add(new DataColumn("DateOuverture", typeof(DateTime)));

            table.Columns.Add(new DataColumn("DateSortiePrevue", typeof(DateTime)));

            table.Columns.Add(new DataColumn("Millesime", typeof(short)));

            table.Columns.Add(new DataColumn("NumeroVersion", typeof(float)));

            // Chargement de la liste des personnes dans la table mémoire
            foreach (var version in listeVersion)
            {
                // Création d'une ligne de table
                DataRow ligne = table.NewRow();

                #region Remplissage de la ligne

                // Aucune des valeurs ne peut être null dans la base de donnée et on les remplis toujours dans l'application,
                // il n'y a donc aucun test à faire.

                ligne["CodeLogiciel"] = version.CodeLogiciel;
                ligne["CodeLogiciel"] = version.CodeLogiciel;
                ligne["DateOuverture"] = version.DateOuverture;
                ligne["DateSortiePrevue"] = version.DateSortiePrevue;
                ligne["Millesime"] = version.Millesime;
                ligne["NumeroVersion"] = version.NumeroVersion;
                
                #endregion

                // Ajout de la ligne dans la table
                table.Rows.Add(ligne);
            }

            return table;
        }
        /// <summary>
        /// Insert une nouvelle version dans la base de donnée.
        /// </summary>
        /// <param name="version">La version à ajouter.</param>
        static public void InsertVersion(List<Version> listeVersion)
        {
            var listProduit = new BindingList<Version>();
            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"INSERT jo.Version (CodeLogiciel, DateOuverture, DateSortiePrevue, Millesime, NumeroVersion)
                                SELECT CodeLogiciel, DateOuverture, DateSortiePrevue, Millesime, NumeroVersion FROM @table";

            var param = new SqlParameter("@table", SqlDbType.Structured);
            DataTable tableVersion = GetDataTableForVersion(listeVersion);
            param.TypeName = "TypeTableVersion";
            param.Value = tableVersion;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                //on initialise la transaction
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(sqlQuery, connect, tran);
                    command.Parameters.Add(param);
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
        /// Création et remplissage d'une table mémoire à partir d'une liste de version en vu d'une suppression dans la base de donnée.
        /// </summary>
        /// <param name="listeVersion">La liste de version d'ou récupérer les NumeroVersion et CodeLogiciel.</param>
        /// <returns></returns>
        static private DataTable GetDataTableForIDsVersion(List<Version> listeVersion)
        {
            // Créaton d'une table mémoire
            DataTable table = new DataTable();

            // Création des colonnes Nom et Prenom de type chaîne et ajout à la table (les champs ne sont jamais null si remplit depuis l'application).
            table.Columns.Add(new DataColumn("CodeLogiciel", typeof(string)));

            table.Columns.Add(new DataColumn("NumeroVersion", typeof(float)));

            // Chargement de la liste des personnes dans la table mémoire
            foreach (var version in listeVersion)
            {
                // Création d'une ligne de table
                DataRow ligne = table.NewRow();

                #region Remplissage de la ligne

                // Aucune des valeurs ne peut être null dans la base de donnée et on les remplis toujours dans l'application,
                // il n'y a donc aucun test à faire.

                ligne["CodeLogiciel"] = version.CodeLogiciel;
                ligne["NumeroVersion"] = version.NumeroVersion;

                #endregion

                // Ajout de la ligne dans la table
                table.Rows.Add(ligne);
            }

            return table;
        }
        /// <summary>
        /// Supprime une version de la base de donnée.
        /// </summary>
        /// <param name="version">version à supprimer.</param>
        static public void RemoveVersion(List<Version> listeVersion)
        {
            var listProduit = new BindingList<Version>();
            var connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string sqlQuery = @"DELETE jo.Version
                                FROM jo.Version v
                                INNER JOIN @TableIDsVersion tv on tv.CodeLogiciel = v.CodeLogiciel
                                WHERE v.NumeroVersion = tv.NumeroVersion";

            var param = new SqlParameter("@TableIDsVersion", SqlDbType.Structured);
            DataTable tableIDsVersion = GetDataTableForIDsVersion(listeVersion);
            param.TypeName = "TypeTableIDsVersion";
            param.Value = tableIDsVersion;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                //on initialise la transaction
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(sqlQuery, connect, tran);
                    command.Parameters.Add(param);
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
