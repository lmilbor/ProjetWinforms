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
        [TestMethod]
        public void TestMethodeGetListePersonne()
        {
            string nom = "LECLERCQ";
           BindingList<Personne> listePersonne = DALTache.GetListePersonne();
            foreach (var p in listePersonne)
            {
                if (p.Nom == nom)
                    Assert.AreEqual(nom, p.Nom);
            }
        }
    }
}
