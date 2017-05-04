using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Logiciel : IEquatable<Logiciel>
    {
        public string CodeLogiciel { get; set; }
        public string Nom { get; set; }
        public BindingList<Version> ListeVersions { get; set; }
        public BindingList<Module> ListeModules { get; set; }

        bool IEquatable<Logiciel>.Equals(Logiciel other)
        {
            if (other == null) return false;
            if (CodeLogiciel == other.CodeLogiciel) return true;
            return false;
        }
    }
}
