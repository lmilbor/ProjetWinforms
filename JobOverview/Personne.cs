using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Personne
    {
        public string Login { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string CodeEquipe { get; set; }
        public string CodeMetier { get; set; }
        public List<TacheProd> ListeTacheProd { get; set; }
        public List<Tache> ListeTacheAnnexe { get; set; }
    }
}
