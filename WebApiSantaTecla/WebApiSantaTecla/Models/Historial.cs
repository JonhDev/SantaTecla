using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSantaTecla.Models
{
    public class Historial
    {
        public int NoHistorial { get; set; }
        public string Antecendentes { get; set; }
        public string Contradicciones { get; set; }
    }
}