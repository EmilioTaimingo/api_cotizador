using api_Cotizador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Context
{
    public class ValidaInformacion
    {
        public Reply Verifica_Informacion(List<Paquete> oPaquetes)
        {
            Reply reply = new Reply();

           
            int paquete = 1;
            //verificamos que los codigos postales esten correctos 
            foreach (var p in oPaquetes)
            {
                
                var cp = p.PastalCode;
                int i;
                if (!Int32.TryParse(cp.ToString(), out i))
                {
                    reply.Message = "El codigo postal debe contener minimo 4 digitos y maximo 5 digitos, revisa el paquete: " +paquete.ToString() ;
                    reply.Result = 401;
                    return reply;
                }
                if(cp.ToString().Length < 4|| cp.ToString().Length >5)
                {
                    reply.Message = "El codigo postal debe contener minimo 4 digitos y maximo 5 digitos, revisa el paquete: "+ paquete.ToString();
                    reply.Result = 401;
                    return reply;
                }
                paquete++;
            }

            paquete = 1;
            foreach (var p in oPaquetes)
            {
                var peso = p.Weight;
                float i;
                if (!float.TryParse(peso.ToString(), out i)|| peso==0)
                {
                    reply.Message = "Ingresa un peso mayor a 0. Revisa el paquete numero: "+paquete.ToString();
                    reply.Result = 402;
                    return reply;
                }
                paquete++;
            }

            paquete = 1;
            foreach (var p in oPaquetes)
            {

                var r = p.HasPichup;
                var recoleccion = r.ToString();
                
                
                if (recoleccion!="True"&&recoleccion!="False")
                {
                    reply.Message = "El valor de recoleccion es false = Recoleccion y  true = Entrega. Revisa el paquete numero: "+paquete.ToString();
                    reply.Result = 403;
                    return reply;
                }
             
                paquete++;
            }
            paquete= 1;
            foreach (var p in oPaquetes)
            {
                var r = p.PackageSize;
                r = r.Replace(" ", "");
                r = r.ToUpper();
                if (r!="CHICO"&& r != "MEDIANO"&& r != "GRANDE")
                {
                    reply.Message = "El tamaño ingresado debe ser CHICO, MEDIANO o GRANDE. Revisa el paquete numero: " + paquete.ToString();
                    reply.Result = 404;
                    return reply;
                }
                paquete++;
            }
           



            return reply;
        }

    }
}