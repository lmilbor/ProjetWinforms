using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace JobOverview
{
    static public class DALTache
    {
        /// <summary>
        /// Retourne la liste des personnes depuis la base de données.
        /// </summary>
        /// <returns></returns>
        static public BindingList<Personne> GetListePersonne()
        {
            var listePersonne = new BindingList<Personne>();
            // Création d'un string pour stocker la chaine de connection
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            // Création d'un string pour stocker la requete SQL
            string queryString = @"Select P.Login, P.Nom, P.Prenom, T.IdTache, T.Libelle, T.Annexe As EstAnnexe, A.Libelle As LibelleActivite, 
                                   T.Description, TP.Numero, TP.DureePrevue, TP.DureeRestanteEstimee, 
                                   M.Libelle As Module, L.CodeLogiciel As Logiciel, V.NumeroVersion
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
                // Instanciation de la commande grace à la chaine de connexion et la requête SQL
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetListePersonneFromReader(listePersonne, reader);
                }
            }
            return listePersonne;
        }

        /// <summary>
        /// Remplit la liste de personne avec les données récupérées par le reader.
        /// </summary>
        /// <param name="listePersonne"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        static private BindingList<Personne> GetListePersonneFromReader(BindingList<Personne> listePersonne, SqlDataReader reader)
        {
            while (reader.Read())
            {
                // Stock le login de la personne traitée
                string loginPersonne = (string)reader["Login"];
                Personne personne = new Personne();

                // Si la liste est vide ou que la dernière personne entré est la même que celle traité 
                if (listePersonne.Count == 0 || listePersonne[listePersonne.Count - 1].Login != loginPersonne)
                {
                    // Création d'une nouvelle instance Personne
                    personne.Login = (string)reader["Login"];
                    personne.Nom = (string)reader["Nom"];
                    personne.Prenom = (string)reader["Prenom"];
                    personne.ListeTacheProd = new List<TacheProd>();
                    personne.ListeTacheAnnexe = new List<Tache>();
                    listePersonne.Add(personne);
                }
                else
                    // Sinon, on reprend la dernière personne créée
                    personne = listePersonne[listePersonne.Count - 1];

                // Stock le booléen decrivant le type de tache
                bool estAnnexe = (bool)reader["EstAnnexe"];

                // Création d'une nouvelle tache
                var tache = new Tache();
                tache.IdTache = (Guid)reader["IdTache"];
                tache.Libelle = (string)reader["Libelle"];
                tache.EstAnnexe = (bool)reader["EstAnnexe"];
                if (reader["Description"] != DBNull.Value)
                    tache.Description = (string)reader["Description"];
                else
                    tache.Description = null;

                // Si c'est une tache de production
                if (!estAnnexe)
                {
                    TacheProd tacheProd = new TacheProd();
                    tacheProd.Activite = new Activité();
                    tacheProd.Logiciel = new Logiciel();
                    tacheProd.Module = new Module();
                    tacheProd.Version = new Version();

                    // On remplis les valeurs avec celles déjà obtenue en tant que Tache.
                    tacheProd.IdTache = tache.IdTache;
                    tacheProd.Libelle = tache.Libelle;
                    tache.EstAnnexe = tache.EstAnnexe;
                    tacheProd.Description = tache.Description;

                    // Transtypage de la tache en tache de production
                    tacheProd.Numero = (int)reader["Numero"];
                    tacheProd.DureePrevue = (float)reader["DureePrevue"];
                    tacheProd.DureeRestanteEstimee = (float)reader["DureeRestanteEstimee"];
                    tacheProd.Version.NumeroVersion = (float)reader["NumeroVersion"];
                    tacheProd.Logiciel.CodeLogiciel = (string)reader["Logiciel"];
                    tacheProd.Module.Libellé = (string)reader["Module"];

                    personne.ListeTacheProd.Add(tacheProd);
                }
                else
                    personne.ListeTacheAnnexe.Add(tache);
            }
            return listePersonne;
        }

        /// <summary>
        /// Retourne la liste des activités depuis la base de données.
        /// </summary>
        /// <returns></returns>
        static public BindingList<Activité> GetListeActivite()
        {
            var listeActivite = new BindingList<Activité>();
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string queryString = @"select * from jo.Activite";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetListeActiviteFromDataReader(listeActivite, reader);
                }
            }
            return listeActivite;
        }

        /// <summary>
        /// Remplit la liste des activités avec les données récupérées par le reader.
        /// </summary>
        /// <param name="ListeActivite"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        static private BindingList<Activité> GetListeActiviteFromDataReader(BindingList<Activité> ListeActivite, SqlDataReader reader)
        {
            while (reader.Read())
            {
                var activ = new Activité();
                activ.CodeActivite = (string)reader["CodeActivite"];
                activ.Libelle = (string)reader["Libelle"];
                activ.EstAnnexe = (bool)reader["Annexe"];
                ListeActivite.Add(activ);
            }
            return ListeActivite;
        }

        /// <summary>
        /// Retourne la liste des modules depuis la base de données.
        /// </summary>
        /// <returns></returns>
        static public BindingList<Module> GetListeModule()
        {
            var listeModule = new BindingList<Module>();
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;
            string queryString = @"select * from jo.Module";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    GetListeModuleFromDataReader(listeModule, reader);
                }
            }
            return listeModule;
        }

        /// <summary>
        /// Remplit la liste des modules avec les données récupérées par le reader.
        /// </summary>
        /// <param name="ListeModule"></param>
        /// <param name="reader"></param>
        /// <returns></returns>
        static private BindingList<Module> GetListeModuleFromDataReader(BindingList<Module> ListeModule, SqlDataReader reader)
        {
            while (reader.Read())
            {
                var module = new Module();
                module.CodeModule = (string)reader["CodeModule"];
                module.Libellé = (string)reader["Libelle"];
                ListeModule.Add(module);
            }
            return ListeModule;
        }

        public static void InsertTache(List<Tache> ListeTache)
        {
            //Création d'une chaine de connection
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;

            //Création de string correspondant aux requêtes SQL
            string queryString2 = @"INSERT jo.Tache(Libelle, Annexe, CodeActivite, Login, Description)
                                   SELECT Libelle, EstAnnexe, CodeActivite, Login, Description FROM @Tache";

            //Création du paramètre de la requete SQL
            var param2 = new SqlParameter("@Tache", SqlDbType.Structured);

            //Appelle de la méthode gérant la création de la table intermédiaire

            DataTable tableTache = InsertTacheWithDatatable(ListeTache);
            param2.TypeName = "TypeTableTache";
            param2.Value = tableTache;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command2 = new SqlCommand(queryString2, connect, tran);
                    command2.Parameters.Add(param2);
                    command2.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        public static void InsertTache(List<TacheProd> ListeTache)
        {
            //Création d'une chaine de connection
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;

            //Création de string correspondant aux requêtes SQL
            string queryString2 = @"INSERT jo.Tache(IdTache, Libelle, Annexe, CodeActivite, Login, Description)
                                   SELECT IdTache, Libelle, EstAnnexe, CodeActivite, Login, Description FROM @Tache";

            //Création du paramètre de la requete SQL
            var param2 = new SqlParameter("@Tache", SqlDbType.Structured);

            //Appelle de la méthode gérant la création de la table intermédiaire

            DataTable tableTache = InsertTacheWithDatatable(ListeTache);
            param2.TypeName = "TypeTableTache";
            param2.Value = tableTache;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command2 = new SqlCommand(queryString2, connect, tran);
                    command2.Parameters.Add(param2);
                    command2.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }
        public static void InsertTacheProd(List<TacheProd> ListeTacheProd)
        {
            //Création d'une chaine de connection
            string connectString = Properties.Settings.Default.ConnectionStringJobOverview;

            //Création de string correspondant aux requêtes SQL

            string queryString1 = @"INSERT jo.TacheProd(IdTache, DureePrevue, DureeRestanteEstimee,
                                   CodeModule, CodeLogicieModule, NumeroVersion, CodeLogicielVersion)
                                   SELECT IdTache, DureePrevue, DureeRestanteEstimee, CodeModule, 
                                   CodeLogicielModule, NumeroVersion, CodeLogicielVersion FROM @TacheProd";

            // On insert d'abord la tacheProd sous form de tache.
            InsertTache(ListeTacheProd);

            //Création du paramètre de la requete SQL
            var param1 = new SqlParameter("@TacheProd", SqlDbType.Structured);

            //Appelle de la méthode gérant la création de la table intermédiaire
            DataTable tableProd = InsertTacheProdWithDatatable(ListeTacheProd);
            param1.TypeName = "TypeTableTacheProd";
            param1.Value = tableProd;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command1 = new SqlCommand(queryString1, connect, tran);
                    command1.Parameters.Add(param1);
                    command1.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Création de la table temporaire TacheProd
        /// </summary>
        /// <param name="ListeTacheProd"></param>
        /// <returns></returns>
        private static DataTable InsertTacheProdWithDatatable(List<TacheProd> ListeTacheProd)
        {
            //Création d'une table mémoire
            DataTable table = new DataTable();

            #region Création des différentes colonnes
            //Colonne IdTache
            var colNom = new DataColumn("IdTache", typeof(Guid));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Durée Prévue
            colNom = new DataColumn("DureePrevue", typeof(float));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Durée Restante Estimée
            colNom = new DataColumn("DureeRestanteEstimee", typeof(float));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Module
            colNom = new DataColumn("CodeModule", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            colNom = new DataColumn("CodeLogicielModule", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Version
            colNom = new DataColumn("NumeroVersion", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            colNom = new DataColumn("CodeLogicielVersion", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);
            #endregion

            foreach (var p in ListeTacheProd)
            {
                //Création de chaque ligne de la table, si la valeur est null
                //alors on écrit une valeur null dans la table de type SQL
                DataRow ligne = table.NewRow();
                ligne["IdTache"] = p.IdTache;
                ligne["DureePrevue"] = p.DureePrevue;
                ligne["DureeRestanteEstimee"] = p.DureeRestanteEstimee;
                ligne["CodeModule"] = p.Module.CodeModule;
                ligne["CodeLogicielModule"] = p.Logiciel.CodeLogiciel;
                ligne["NumeroVersion"] = p.Version.NumeroVersion;
                ligne["CodeLogicielVersion"] = p.Logiciel.CodeLogiciel;

                //Ajout de ligne dans la table
                table.Rows.Add(ligne);
            }
            return table;
        }
        /// <summary>
        /// Création de la table temporaire @Tache
        /// </summary>
        /// <param name="ListeTacheProd"></param>
        /// <returns></returns>
        private static DataTable InsertTacheWithDatatable(List<Tache> ListeTache)
        {
            //Création d'une table mémoire
            DataTable table = new DataTable();

            #region Création des différentes colonnes

            //Colone IdTache
            var colNom = new DataColumn("IdTache", typeof(Guid));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Libelle
            colNom = new DataColumn("Libelle", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne EstAnnexe
            colNom = new DataColumn("EstAnnexe", typeof(bool));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Activité
            colNom = new DataColumn("CodeActivite", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Login
            colNom = new DataColumn("Login", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);
            #endregion

            //Colonne Description
            table.Columns.Add(new DataColumn("Description", typeof(string)));

            foreach (var p in ListeTache)
            {
                //Création de chaque ligne de la table, si la valeur est null
                //alors on écrit une valeur null dans la table de type SQL
                DataRow ligne = table.NewRow();
                ligne["IdTache"] = p.IdTache;
                ligne["Libelle"] = p.Libelle;
                ligne["EstAnnexe"] = p.EstAnnexe;
                ligne["CodeActivite"] = p.Activite.CodeActivite;
                ligne["Login"] = p.Login;
                if (p.Description != null) ligne["Description"] = p.Description;
                else ligne["Description"] = DBNull.Value;

                //Ajout de ligne dans la table
                table.Rows.Add(ligne);
            }
            return table;
        }
        /// <summary>
        /// Création de la table temporaire @Tache
        /// </summary>
        /// <param name="ListeTacheProd"></param>
        /// <returns></returns>
        private static DataTable InsertTacheWithDatatable(List<TacheProd> ListeTache)
        {
            //Création d'une table mémoire
            DataTable table = new DataTable();

            #region Création des différentes colonnes

            //Colone IdTache
            var colNom = new DataColumn("IdTache", typeof(Guid));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Libelle
            colNom = new DataColumn("Libelle", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne EstAnnexe
            colNom = new DataColumn("EstAnnexe", typeof(bool));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Activité
            colNom = new DataColumn("CodeActivite", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);

            //Colonne Login
            colNom = new DataColumn("Login", typeof(string));
            colNom.AllowDBNull = false;
            table.Columns.Add(colNom);
            #endregion

            //Colonne Description
            table.Columns.Add(new DataColumn("Description", typeof(string)));

            foreach (var p in ListeTache)
            {
                //Création de chaque ligne de la table, si la valeur est null
                //alors on écrit une valeur null dans la table de type SQL
                DataRow ligne = table.NewRow();
                ligne["IdTache"] = p.IdTache;
                ligne["Libelle"] = p.Libelle;
                ligne["EstAnnexe"] = p.EstAnnexe;
                ligne["CodeActivite"] = p.Activite.CodeActivite;
                ligne["Login"] = p.Login;
                if (p.Description != null) ligne["Description"] = p.Description;
                else ligne["Description"] = DBNull.Value;

                //Ajout de ligne dans la table
                table.Rows.Add(ligne);
            }
            return table;
        }

    }
}
