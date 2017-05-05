using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    static public class TempData
    {
        #region Propriétés publiques
        static public BindingList<Personne> ListePersonne { get; set; }
        static public BindingList<Logiciel> ListeLogiciel { get; set; }
        static public BindingList<Activité> ListeActivite { get; set; }
        static public BindingList<Module> ListeModule { get; set; }
        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Retourne la liste des tache de production propre à une personne.
        /// </summary>
        /// <param name="personne">Personne dont on veut la liste de tache.</param>
        /// <returns></returns>
        static public List<TacheProd> GetListeTacheProd(Personne personne)
        {
            return ListePersonne.Where(p => p.Equals(personne)).FirstOrDefault().ListeTacheProd.ToList();
        }
        /// <summary>
        /// Retourne la liste des tache de production propre à une personne.
        /// </summary>
        /// <param name="login">Login de la personne dont on veut la liste de tache.</param>
        /// <returns></returns>
        static public List<TacheProd> GetListeTacheProd(string login)
        {
            return ListePersonne.Where(p => p.Login == login).FirstOrDefault().ListeTacheProd.ToList();
        }
        #endregion
    }
}
