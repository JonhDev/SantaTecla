using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSantaTecla.Models
{
    public class Citas
    {
        public int NoCita { get; set; }
        public string Fecha { get; set; }
        public int IdPersonal { get; set; }
    }
}