using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Version
    {
        public float NumeroVersion { get; set; }
        public short Millesime { get; set; }
        public List<Module> ListeModules { get; set; }
        public short LastNumeroRelease { get; set; }
    }
}
