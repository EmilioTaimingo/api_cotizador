using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class PaqueteRespuesta
    {
        public int CodigoPostal { get; set; }
        public float Peso { get; set; }
        public string TipoSolicitud { get; set; }
        public string Tamano { get; set; }
        public float Precio { get; set; }
    }
}