using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class Paquete
    {
        public int PastalCode { get; set; }
        public float Weight { get; set; }
        public bool HasPichup { get; set; }
        //se usara la misma nomenclatura 
        //0=recoleccion
        //1=entrega
        public string PackageSize { get; set; }
        //los tamaños seran chicos, medianos, grandes

    }
}