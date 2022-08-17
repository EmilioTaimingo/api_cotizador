using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class PaqueteRespuesta
    {
        public int PastalCode { get; set; }
        public float Weight { get; set; }
        public string HasPichup { get; set; }
        public string PackageSize { get; set; }
        public float Price{ get; set; }
    }
}