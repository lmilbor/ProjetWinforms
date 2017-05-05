using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Personne : IEquatable<Personne>
    {
        public string Login { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<TacheProd> ListeTacheProd { get; set; }
        public List<Tache> ListeTacheAnnexe { get; set; }

        bool IEquatable<Personne>.Equals(Personne other)
        {
            if (other == null) return false;
            if (other.Login == this.Login) return true;
            else return false;
        }
    }
}
