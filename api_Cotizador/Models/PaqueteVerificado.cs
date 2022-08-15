using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class PaqueteVerificado
    {
        public int CodigoPostal { get; set; }
        public float Peso { get; set; }
        public int Recoleccion { get; set; }
        //se usara la misma nomenclatura 
        //0=recoleccion
        //1=entrega
        public string Tamano { get; set; }

        public bool Cobertura{get;set;}

        public int Categoria_Peso { get; set; }
        // 1= 0.1kg a 2.0kg
        // 2= 2.1kg a 5.0kg
        // 3= 5.1kg a 10.0kg
        // 4= 10.0kg a 20.0kg

        public int Categoria_Precio { get; set; }
        // 1=50 a 500 paquetes
        // 2=500 a 2500 paquetes
        // 3=2501 a 5000 paquetes
        // 4=5000 en adelante 
        public float PrecioPaquete { get; set; }

    }
}