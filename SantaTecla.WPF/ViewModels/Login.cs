using SantaTecla.Models;
using SantaTecla.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SantaTecla.WPF.ViewModels
{
    public class Login
    {
        public async Task<int> AccessAsync(string user, string password)
        {
            SantaTeclaService service = new SantaTeclaService();
            string personal = await service.AuthUser(user, password);
            if (personal != null)
            {

                switch (personal)
                {
                    case "doctor":
                            return 10;
                        
                    case "dietetica":
                            return 4;
                      
                    case "enfermero":
                            return 7;
                     
                    case "recepcion":
                            return 1;
                        
                    case "cocina":
                            return 4;
                        
                    case "farmacia":
                            return 12;

                    case "administracion":
                        return 14;
                        
                }
            }

            return 0;
        }

    }
}
