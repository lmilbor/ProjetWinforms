using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Tache
    {
        public string UniqueIdentifier { get; set; }
        public string Libelle { get; set; }

        //Si Annexe = 0, il s'agit d'une tache de production, 
        //sinon il s'agit d'une tache annexe
        public bool EstAnnexe { get; set; }
        public string LibelleActivite { get; set; }
        public string Description { get; set; }
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
