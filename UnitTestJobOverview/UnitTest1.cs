using System;
using JobOverview;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UnitTestJobOverview
{
    [TestClass]
    public class UnitTest1
    {
        public void ChaineDeConnexion()
        {
            FormConnexion.ConnectionTestUnitaire(@"Data Source=BGUILLAUMI17-DE\IP08R2;Initial Catalog=WinformsJobOverview;Integrated Security=True");
        }
        [TestMethod]
        public void TestMethodeGetListePersonne()
        {
            ChaineDeConnexion();
            string nom = string.Empty;
            string nomTest = "LECLERCQ";

            BindingList<Personne> listePersonne = DALTache.GetListePersonne();
            foreach (var p in listePersonne)
            {
                if (p.Nom == nomTest)
                    nom = p.Nom;
            }
            Assert.AreEqual(nomTest, nom);
        }

        [TestMethod]
        public void TestMethodeGetListeActivite()
        {
            ChaineDeConnexion();
            string libelle = string.Empty;
            string CodeActivitéTest = "APPUI_EQUIPE";
            string libelleTest = "Appui des personnes de l'équipe";
            BindingList<Activité> listeActivite = DALTache.GetListeActivite();
            foreach (var p in listeActivite)
            {
                if (p.CodeActivite == CodeActivitéTest)
                    libelle = p.Libelle;
            }
            Assert.AreEqual(libelleTest, libelle);
        }

        [TestMethod]
        public void TestMethodeGetListeModule()
        {
            ChaineDeConnexion();
            string libelle = string.Empty;
            string CodeModuleTest = "POLYMORPHISME";
            string libelleTest = "Polymorphisme génétique";
            BindingList<Module> listeModule = DALTache.GetListeModule();
            foreach (var p in listeModule)
            {
                if (p.CodeModule == CodeModuleTest)
                    libelle = p.Libellé;
            }
            Assert.AreEqual(libelleTest, libelle);
        }


        [TestMethod]
        public void TestMethodeGetListeLogiciel()
        {
            ChaineDeConnexion();
            string nom = string.Empty;
            string codeLogicielTest = "GENOMICA";
            string nomTest = "Genomica";

            BindingList<Logiciel> listeLogiciel = DALLogiciel.GetListLogiciel();
            foreach (var l in listeLogiciel)
            {
                if (l.CodeLogiciel == codeLogicielTest)
                    nom = l.Nom;
            }
            Assert.AreEqual(nom, nomTest);
        }
    }
}
