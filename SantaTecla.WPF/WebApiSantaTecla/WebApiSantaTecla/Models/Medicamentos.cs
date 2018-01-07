using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSantaTecla.Models
{
    public class Medicamentos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
    }
}