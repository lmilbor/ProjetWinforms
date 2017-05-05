using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
    static public class TempData
    {
        static public BindingList<Personne> ListePersonne { get; set; }
        static public BindingList<Logiciel> ListeLogiciel { get; set; }
        static public BindingList<Activité> ListeActivite { get; set; }
    }
}
