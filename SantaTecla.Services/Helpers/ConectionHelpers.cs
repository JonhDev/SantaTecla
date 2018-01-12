using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaTecla.Services.Helpers
{
    public static class ConectionHelpers
    {
        public static string MainURL { get; set; } = "http://localhost:64519/api/";
        public static string MedicamentosURL { get; set; } = "Medicamentos/";
        public static string PacientesURL { get; set; } = "Pacientes/";
        public static string PersonalURL { get; set; } = "Personal/";
    }
}
