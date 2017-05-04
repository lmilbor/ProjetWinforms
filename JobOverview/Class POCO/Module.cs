using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Module : IEquatable<Module>
    {
        public string CodeModule { get; set; }
        public string Libellé { get; set; }

        bool IEquatable<Module>.Equals(Module other)
        {
            if (other == null) return false;
            if (CodeModule == other.CodeModule) return true;
            return false;
        }
    }
}
