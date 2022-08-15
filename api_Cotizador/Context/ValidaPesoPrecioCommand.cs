using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api_Cotizador.Models;

namespace api_Cotizador.Context
{
    public class ValidaPesoPrecioCommand
    {
        // agregamos los precios en listas que se cambiaran en algun momento por 
        // consultas a la base de datos 

        public List<PaqueteVerificado> Obtener_Precio(List<PaqueteVerificado> oPVerificados)
        {
            int p1=0,p2=0,p3 = 0,p4 = 0;

            // agregamos a que categoria de peso pertenece el paquete 
           for(int i = 0; i < oPVerificados.Count; i++)
            {
                if(oPVerificados[i].Cobertura == true)
                {
                    if (oPVerificados[i].Peso >= 0.1 && oPVerificados[i].Peso<2.1)
                    {
                        oPVerificados[i].Categoria_Peso = 1;
                        p1++;
                    }
                      else if (oPVerificados[i].Peso >= 2.1 && oPVerificados[i].Peso < 5.1)
                        {
                            oPVerificados[i].Categoria_Peso = 2;
                            p2++;
                        }
                            else if (oPVerificados[i].Peso >= 5.1 && oPVerificados[i].Peso < 10.1)
                            {
                                oPVerificados[i].Categoria_Peso = 3;
                             p3++;
                            }
                           //verificar que pasa con los paquetes que exeden del peso mayor de 20kg
                            else if (oPVerificados[i].Peso >= 10.1 && oPVerificados[i].Peso < 1000)
                            {
                                oPVerificados[i].Categoria_Peso = 4;
                            p4++;
                            }
                }
            }
            //verificamos cuantos paquetes de cada peso se tienen
            var paq = 0;
            foreach (var p in oPVerificados)
            {

                if (p.Categoria_Peso == 1)
                {
                    if (p1 >= 1 && p1 < 501)
                    {
                        oPVerificados[paq].Categoria_Precio = 1;
                    }
                    else
                     if (p1 >= 501 && p1 < 2501)
                    {
                        oPVerificados[paq].Categoria_Precio = 2;
                    }
                    else
                     if (p1 >= 2501 && p1 < 5001)
                    {
                        oPVerificados[paq].Categoria_Precio = 3;
                    }
                    else
                     if (p1 >= 5001 && p1 < 1000000)
                    {
                        oPVerificados[paq].Categoria_Precio = 4;
                    }
                }
                    else
                       if (p.Categoria_Peso == 2)
                {
                    if (p2 >= 1 && p2 < 501)
                    {
                        oPVerificados[paq].Categoria_Precio = 1;
                    }
                    else
                     if (p2 >= 501 && p2 < 2501)
                    {
                        oPVerificados[paq].Categoria_Precio = 2;
                    }
                    else
                     if (p2 >= 2501 && p2 < 5001)
                    {
                        oPVerificados[paq].Categoria_Precio = 3;
                    }
                    else
                     if (p2 >= 5001 && p2 < 1000000)
                    {
                        oPVerificados[paq].Categoria_Precio = 4;
                    }
                }
                           else
                              if (p.Categoria_Peso == 3)
                {
                    if (p3 >= 1 && p3 < 501)
                    {
                        oPVerificados[paq].Categoria_Precio = 1;
                    }
                    else
                     if (p3 >= 501 && p3 < 2501)
                    {
                        oPVerificados[paq].Categoria_Precio = 2;
                    }
                    else
                     if (p3 >= 2501 && p3 < 5001)
                    {
                        oPVerificados[paq].Categoria_Precio = 3;
                    }
                    else
                     if (p3 >= 5001 && p3 < 1000000)
                    {
                        oPVerificados[paq].Categoria_Precio = 4;
                    }
                }
                                  else
                                     if (p.Categoria_Peso == 4)
                {
                    if (p4 >= 0 && p4 <= 500)
                    {
                        oPVerificados[paq].Categoria_Precio = 1;
                    }
                    else
                     if (p4 >= 501 && p4 <= 2500)
                    {
                        oPVerificados[paq].Categoria_Precio = 2;
                    }
                    else
                     if (p4 >= 2501 && p4 <= 5000)
                    {
                        oPVerificados[paq].Categoria_Precio = 3;
                    }
                    else
                     if (p4 >= 5001 && p4 <= 1000000)
                    {
                        oPVerificados[paq].Categoria_Precio = 4;
                    }
                }
                paq++;
            }

            // obtenemos el precio para cada uno de los paquetes 
            paq = 0;

            foreach (var p in oPVerificados)
            {
                if(p.Categoria_Peso==1)
                {
                    if(p.Categoria_Precio==1)
                    {
                        oPVerificados[paq].PrecioPaquete = 60.0f;
                    }else
                        if (p.Categoria_Precio == 2)
                    {
                        oPVerificados[paq].PrecioPaquete = 55.0f;
                    }
                    else
                        if (p.Categoria_Precio == 3)
                    {
                        oPVerificados[paq].PrecioPaquete = 53.0f;
                    }
                    else
                        if (p.Categoria_Precio == 4)
                    {
                        oPVerificados[paq].PrecioPaquete = 51.0f;
                    }
                }               
                   else
                      if (p.Categoria_Peso == 2)
                 {
                    if (p.Categoria_Precio == 1)
                    {
                        oPVerificados[paq].PrecioPaquete = 65.0f;
                    }
                    else
                        if (p.Categoria_Precio == 2)
                    {
                        oPVerificados[paq].PrecioPaquete = 60.0f;
                    }
                    else
                        if (p.Categoria_Precio == 3)
                    {
                        oPVerificados[paq].PrecioPaquete = 58.0f;
                    }
                    else
                        if (p.Categoria_Precio == 4)
                    {
                        oPVerificados[paq].PrecioPaquete = 56.0f;
                    }

                }               
                          else
                             if (p.Categoria_Peso == 3)
                        {
                            if (p.Categoria_Precio == 1)
                            {
                                oPVerificados[paq].PrecioPaquete = 70.0f;
                            }
                            else
                                if (p.Categoria_Precio == 2)
                            {
                                oPVerificados[paq].PrecioPaquete = 65.0f;
                            }
                            else
                                if (p.Categoria_Precio == 3)
                            {
                                oPVerificados[paq].PrecioPaquete = 63.0f;
                            }
                            else
                                if (p.Categoria_Precio == 4)
                            {
                                oPVerificados[paq].PrecioPaquete = 61.0f;
                            }

                        }
                                 else
                                    if (p.Categoria_Peso == 4)
                            {
                                if (p.Categoria_Precio == 1)
                                {
                                    oPVerificados[paq].PrecioPaquete = 75.0f;
                                }
                                else
                                    if (p.Categoria_Precio == 2)
                                {
                                    oPVerificados[paq].PrecioPaquete = 70.0f;
                                }
                                else
                                    if (p.Categoria_Precio == 3)
                                {
                                    oPVerificados[paq].PrecioPaquete = 68.0f;
                                }
                                else
                                    if (p.Categoria_Precio == 4)
                                {
                                    oPVerificados[paq].PrecioPaquete = 66.0f;
                                }

                }
                paq++;

            }
            //regresamos la lista con el precio, sin contar todabia el costo por recoleccion 
            return oPVerificados;

        }

            


        public List<CategoriaPaquete> Lista_precios()
        {
            //llenamos la lista con las categorias existentes 

            List<CategoriaPaquete> lCategorias = new List<CategoriaPaquete>();

            // peso hasta 2.0kg
            CategoriaPaquete oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 0.1f,
                pesoMaximo = 2.0f,
                cantidadMinima = 50,
                cantidadMaxima = 500,
                precioPaquete = 60.0f,
                precioRecoleccion = 10.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 0.1f,
                pesoMaximo = 2.0f,
                cantidadMinima = 501,
                cantidadMaxima = 2500,
                precioPaquete = 55.0f,
                precioRecoleccion = 8.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 0.1f,
                pesoMaximo = 2.0f,
                cantidadMinima = 2501,
                cantidadMaxima = 5000,
                precioPaquete = 53.0f,
                precioRecoleccion = 5.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 0.1f,
                pesoMaximo = 2.0f,
                cantidadMinima = 5001,
                cantidadMaxima = 100000,
                precioPaquete = 51.0f,
                precioRecoleccion = 4.0f
            };
            lCategorias.Add(oCategoria);

            //peso de 2.1kg a 5.0kg****************************
            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 2.1f,
                pesoMaximo = 5.0f,
                cantidadMinima = 50,
                cantidadMaxima = 500,
                precioPaquete = 65.0f,
                precioRecoleccion = 10.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 2.1f,
                pesoMaximo = 5.0f,
                cantidadMinima = 501,
                cantidadMaxima = 2500,
                precioPaquete = 60.0f,
                precioRecoleccion = 8.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 2.1f,
                pesoMaximo = 5.0f,
                cantidadMinima = 2501,
                cantidadMaxima = 5000,
                precioPaquete = 58.0f,
                precioRecoleccion = 5.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 2.1f,
                pesoMaximo = 5.0f,
                cantidadMinima = 5001,
                cantidadMaxima = 100000,
                precioPaquete = 56.0f,
                precioRecoleccion = 4.0f
            };
            lCategorias.Add(oCategoria);

            //peso de 5.1kg a 10.0kg****************************
            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 5.1f,
                pesoMaximo = 10.0f,
                cantidadMinima = 50,
                cantidadMaxima = 500,
                precioPaquete = 70.0f,
                precioRecoleccion = 10.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 5.1f,
                pesoMaximo = 10.0f,
                cantidadMinima = 501,
                cantidadMaxima = 2500,
                precioPaquete = 65.0f,
                precioRecoleccion = 8.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 5.1f,
                pesoMaximo = 10.0f,
                cantidadMinima = 2501,
                cantidadMaxima = 5000,
                precioPaquete = 63.0f,
                precioRecoleccion = 5.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 5.1f,
                pesoMaximo = 10.0f,
                cantidadMinima = 5001,
                cantidadMaxima = 100000,
                precioPaquete = 61.0f,
                precioRecoleccion = 4.0f
            };
            lCategorias.Add(oCategoria);

            //peso de 10.1kg a 20.0kg****************************
            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 10.1f,
                pesoMaximo = 20.0f,
                cantidadMinima = 50,
                cantidadMaxima = 500,
                precioPaquete = 75.0f,
                precioRecoleccion = 10.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 10.1f,
                pesoMaximo = 20.0f,
                cantidadMinima = 501,
                cantidadMaxima = 2500,
                precioPaquete = 70.0f,
                precioRecoleccion = 8.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 10.1f,
                pesoMaximo = 20.0f,
                cantidadMinima = 2501,
                cantidadMaxima = 5000,
                precioPaquete = 68.0f,
                precioRecoleccion = 5.0f
            };
            lCategorias.Add(oCategoria);

            oCategoria = new CategoriaPaquete
            {
                pesoMinimo = 10.1f,
                pesoMaximo = 20.0f,
                cantidadMinima = 5001,
                cantidadMaxima = 100000,
                precioPaquete = 66.0f,
                precioRecoleccion = 4.0f
            };
            lCategorias.Add(oCategoria);

            return lCategorias;

        }

    }
}