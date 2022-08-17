using api_Cotizador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using api_Cotizador.Context;

namespace api_Cotizador.Controllers
{
    public class PricingQuoteController:ApiController
    {
        public Reply Post([FromBody] List<Paquete> oPaquetes)
        {
            ZonasCommand oZona = new ZonasCommand();
            List<PaqueteVerificado> oPVerificados = new List<PaqueteVerificado>();
            //verificamos la informacion ingresada antes de trabajar con ella
            ValidaInformacion oV = new ValidaInformacion();
            var respuesta = oV.Verifica_Informacion(oPaquetes);
            if(respuesta.Message!=null)
            {
                return respuesta;
            }

            Reply Result = new Reply();
            //validamos que el paquete se encuentre donde hay cobertura 
            //si tiene cobertura ponemos Cobertura en true
            try
            {
                foreach (var p in oPaquetes)
                {
                    var l = oZona.Valida_Codigo(p.PastalCode.ToString());
                    var opv = new PaqueteVerificado
                    {
                        CodigoPostal = p.PastalCode,
                        Peso = p.Weight,
                        Recoleccion = p.HasPichup,
                        Tamano = p.PackageSize,
                    };
                    oPVerificados.Add(opv);
                    if (l == true)
                    {
                        oPVerificados[oPVerificados.Count - 1].Cobertura = true;
                    }
                    else
                    {
                        oPVerificados[oPVerificados.Count - 1].Cobertura = false;
                    }

                }
            }
            catch(Exception e)
            {
                Result.Message = "Incorrect data";
                Result.Result = 401;
            }
            

            ValidaPesoPrecioCommand oPrecio = new ValidaPesoPrecioCommand();
            // obtenemos la lista de los paquetes con su debido costo 
            var lista= oPrecio.Obtener_Precio(oPVerificados);

            //contabilizamos cuantos paquetes son de recoleccion, tomando en cuenta 
            //el peso y la cantidad de paquetes a recolectar 
            //si la cantidad de paquetes a recolectar es menor 35 paquetes el pres
            int paq = 0;
            float pTRecoleccion = 0.0f;//precio total para recoleccion 
            float pTEntrega = 0.0f;//precio total para la entrega
            float ppRecoleccion = 0.0f;// suma del precio de con los paquetes a recolectar
            int pRecoleccion = 0, pEntrega = 0, pSCovertura = 0;
            List<PaqueteRespuesta> oPRespuesta = new List<PaqueteRespuesta>();
            
            foreach (var p in lista)
            {
                if (p.Recoleccion==0&& p.Cobertura==true)//si es recoleccion sumamos el precio a recoleccion
                {
                    // verificamos el precio de la recoleccion
                    if (p.Categoria_Precio == 1)
                    {
                        pTRecoleccion = pTRecoleccion + 10.0f;
                        pRecoleccion++;// incremetamos los paquetes a recolectar
                        ppRecoleccion = ppRecoleccion + p.PrecioPaquete;
                    }
                    else
                        if (p.Categoria_Precio == 2)
                    {
                        pTRecoleccion = pTRecoleccion + 8.0f;
                        pRecoleccion++;//incrementamos los paquetes a recolectar
                        ppRecoleccion = ppRecoleccion + p.PrecioPaquete;
                    }
                    else
                        if (p.Categoria_Precio == 3)
                    {
                        pTRecoleccion = pTRecoleccion + 5.0f;
                        pRecoleccion++;//incrementamos los paquetes a recolectar
                        ppRecoleccion = ppRecoleccion + p.PrecioPaquete;
                    }
                    else
                        if (p.Categoria_Precio == 4)
                    {
                        pTRecoleccion = pTRecoleccion + 4.0f;
                        pRecoleccion++;//incrementamos los paquetes a recolectar 
                        ppRecoleccion = ppRecoleccion + p.PrecioPaquete;
                    }
                }
                if(p.Recoleccion==1&&p.Cobertura==true)//si es entrega sumamos el precio a entrega 
                {
                    pTEntrega = pTEntrega + p.PrecioPaquete;
                    pEntrega++;//incrementamos los paquetes a entregar
                }
                if(p.Cobertura==false)// si no hay cobertura sumamos a los paquetes sin covertura 
                {
                    pSCovertura++;//incrementamos los paquetes que no tienen covertura 
                }

                PaqueteRespuesta pr = new PaqueteRespuesta();
                //almacenamos el paquete en la lista que devolveremos  
                pr.PackageSize =p.Tamano;
                pr.PastalCode = p.CodigoPostal;
                if(p.Cobertura==true)
                {
                    if(p.Recoleccion==0)
                    {
                        pr.HasPichup = "No";
                    }
                    if(p.Recoleccion == 1)
                    {
                        pr.HasPichup = "Yes";
                    }

                }
                else
                {
                    pr.HasPichup= "No delivery coverage";
                }
                pr.Weight = p.Peso;
                pr.PackageSize = p.Tamano;
                pr.Price = p.PrecioPaquete;
                oPRespuesta.Add(pr);    
                paq++;
            }

            //preparamos la informacion que vamos a retornar


            if (pTRecoleccion<350.0f)
            {
                Result.TotalPrice = pTEntrega + 350.0f+ppRecoleccion;
            }
            else
            {
                Result.TotalPrice = pTEntrega + pTRecoleccion+ppRecoleccion;
            }
            Result.Message = "Ok";
            Result.Result = 200;
            Result.NumberOfPackages = oPRespuesta.Count;
            Result.Package = oPRespuesta;
            Result.PackagesWithoutCoverage = pSCovertura;
            Result.DeliveryPackages= pEntrega;
            Result.PickUpPackages= pRecoleccion;
          
            return Result;
        }

       

    }
}