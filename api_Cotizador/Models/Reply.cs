using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class Reply
    {
        public int Result { get; set; }
        public string Message { get; set; }      
        public int Total_Paquetes_Ingresados { get; set; }
        public int Paquetes_para_Recoleccion { get; set; }
        public int Paquetes_para_Entrega { get; set; }
        public int Paquetes_Sin_Covertura { get; set; }
        public float Precio_Total { get; set; }
        public List<PaqueteRespuesta> paquete { get; set; }
        

    }
}