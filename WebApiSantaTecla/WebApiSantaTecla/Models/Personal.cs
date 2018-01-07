using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiSantaTecla.Models
{
    public class Personal
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Puesto { get; set; }
        public Login Login { get; set; }

    }

    class PersonalDbContext: DbContext
    {
        public DbSet<Personal> Personal { get; set; }
    }

    
}