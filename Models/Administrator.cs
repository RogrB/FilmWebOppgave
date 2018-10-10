using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models
{
    public class Administrator
    {
        public int id { get; set; }
        public string Brukernavn { get; set; }
        public string Passord { get; set; }
    }

    public class AdministratorDB
    {
        public int id { get; set; }
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public string Salt { get; set; }
    }
}