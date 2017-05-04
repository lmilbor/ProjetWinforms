using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Logiciel : IEquatable<Logiciel>
    {
        public string CodeLogiciel { get; set; }
        public string Nom { get; set; }
        public List<Version> ListeVersions { get; set; }
        public List<Module> ListeModules { get; set; }

        bool IEquatable<Logiciel>.Equals(Logiciel other)
        {
            if (other == null) return false;
            if (CodeLogiciel == other.CodeLogiciel) return true;
            return false;
        }
    }
}
