using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaTecla.Models
{
    public class Payment
    {
        public PaymentOptions PaymentType { get; set; }
        public string NumTarjeta { get; set; }
        public string CVV { get; set; }
        public string Fecha { get; set; }
        public string Titular { get; set; }
    }



    public enum PaymentOptions
    {
        Tarjeta,
        Efectivo,
        Seguro
    }
}