using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    public class Version : IEquatable<Version>
    {
        public string CodeLogiciel { get; set; }
        public float NumeroVersion { get; set; }
        public short Millesime { get; set; }
        public DateTime DateOuverture { get; set; }
        public DateTime DateSortiePrevue { get; set; }
        public short LastNumeroRelease { get; set; }

        bool IEquatable<Version>.Equals(Version other)
        {
            if (other == null) return false;
            if (NumeroVersion == other.NumeroVersion) return true;
            return false;
        }
    }
}
