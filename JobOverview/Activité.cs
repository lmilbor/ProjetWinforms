using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Activité : IEquatable<Activité>
    {
        public string CodeActivite { get; set; }
        public string Libelle { get; set; }
        public bool EstAnnexe { get; set; }

        bool IEquatable<Activité>.Equals(Activité other)
        {
            if (other == null) return false;
            if (other.CodeActivite == this.CodeActivite) return true;
            else return false;
        }
    }
}
