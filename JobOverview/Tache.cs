using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Tache : IEquatable<Tache>
    {
        public Guid IdTache { get; set; }
        public string Libelle { get; set; }
        public string Login { get; set; }

        //Si Annexe = 0, il s'agit d'une tache de production, 
        //sinon il s'agit d'une tache annexe
        public bool EstAnnexe { get; set; }
        public Activité Activite { get; set; }
        public string Description { get; set; }

        bool IEquatable<Tache>.Equals(Tache other)
        {
            if (other == null) return false;
            if (other.IdTache == this.IdTache) return true;
            else return false;
        }
    }

    public class TacheProd : Tache
    {
        public int Numero { get; set; }
        public float DureePrevue { get; set; }
        public float DureeRestanteEstimee { get; set; }
        public Module Module { get; set; }
        public Version Version { get; set; }
        public Logiciel Logiciel { get; set; }
    }
}
