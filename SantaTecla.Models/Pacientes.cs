
namespace SantaTecla.Models
{
    public class Pacientes
    {
        public int NSS { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public Internado Internado { get; set; }
        public Citas Citas { get; set; }
        public Historial Historial { get; set; }
        public Payment FormaDePago { get; set; }
    }

}