using System;
using System.Collections.Generic;
using System.Collections;

namespace PrimerProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            String valorEntrada = "";
          //  String[] arrayValores = null;
            DateTime fecha;
            DateTime hora;
            float temperatura = 0;
            float humedad = 0;
            Boolean imprimirOK = false;
            Boolean errorEntrada = false;
            string estadoString;
            int n = 0;
            List<Info> listaDatos = new List<Info>();
            
           
            do
                {
                    Console.WriteLine("Ingresar informacion");
                    valorEntrada = Console.ReadLine();
                    n += 1;
                //while (valorEntrada.Length > 0)
                if (valorEntrada == "")
                {

                    // imprimir      
                    //  Console.WriteLine("Fecha del registro: {0}/{1}/{2} ", fecha.ToString("yyyy"), fecha.ToString("MM"), fecha.ToString("dd"));
                    //  Console.WriteLine("Hora del registro: {0}hs {1}min {2}seg ", hora.ToString("HH"), hora.ToString("MM"), hora.ToString("ss"));
                    //  Console.WriteLine("Temperatura: {0}°", temperatura);
                    //  Console.WriteLine("Humedad: {0}% ", humedad);
                    //  Console.WriteLine("Codigo: “{0}” ", codigo);
                    //  Console.WriteLine(estadoString);
                    if (listaDatos.Count > 0)
                    {
                        foreach (Info aInfo in listaDatos)
                        {
                            Console.WriteLine(aInfo.GetFechaHora());
                            Console.WriteLine(aInfo.GetTemperatura());
                            Console.WriteLine(aInfo.GetHumedad());
                            Console.WriteLine(aInfo.GetCodigo());
                            Console.WriteLine(aInfo.GetEstado());
                            Console.WriteLine("**********************");
                        }                       
                        imprimirOK = true;
                    }
                    else { Console.WriteLine("no ingreso ningun valor"); }
                }
                else {

                    if (valorEntrada.Length == 25)
                    {
                        // agregar datos y pedir datos
                        errorEntrada = false;
                        imprimirOK = false;
                        String fec = valorEntrada.Substring(0, 8);
                        string[] formatFec = { "yyyyMMdd" };
                        string[] formatHora = { "HHMMss" };
                        String horastring = valorEntrada.Substring(8, 6);
                        String tempent = valorEntrada.Substring(14, 2);
                        String tempdec = valorEntrada.Substring(16, 1);
                        String hument = valorEntrada.Substring(17, 2);
                        String humdec = valorEntrada.Substring(19, 1);
                        String codigo = valorEntrada.Substring(20, 4);
                        String estado = valorEntrada.Substring(24, 1);

                        try
                        {
                            temperatura = float.Parse(tempent + "," + tempdec);
                        }
                        catch (Exception error)
                        {                            
                            Console.WriteLine(" Temperatura incorrecta: {0}", error.Message);
                            errorEntrada = true;
                        }
                        try
                        {
                            humedad = float.Parse(hument + "," + humdec);
                        }
                        catch (Exception error)
                        {                            
                            Console.WriteLine(" Humedad incorrecta: {0}", error.Message);
                            errorEntrada = true;
                        }
                        if (!DateTime.TryParseExact(fec, formatFec, System.Globalization.CultureInfo.InvariantCulture,
                                      System.Globalization.DateTimeStyles.None,
                                      out fecha))
                        {
                            Console.WriteLine("fecha incorrecta {0}", fecha);
                            errorEntrada = true;
                        }

                        if (!DateTime.TryParseExact(horastring, formatHora, System.Globalization.CultureInfo.InvariantCulture,
                                      System.Globalization.DateTimeStyles.None,
                                      out hora))
                        {
                            Console.WriteLine("hora incorrecta");
                            errorEntrada = true;
                        }
                        if (codigo != "AC1C")
                        {
                            Console.WriteLine("Codigo Incorrecto");
                            errorEntrada = true;
                        }
                        switch (estado)
                        {
                            case "0":
                                estadoString = "Activo : NO";
                                break;
                            case "1":
                                estadoString = "Activo : SI";
                                break;
                            default:
                                estadoString = "Estado Incorrecto";
                                Console.WriteLine(estadoString);
                                errorEntrada = true;
                                break;
                        }
                        // *
                        if (!errorEntrada)
                        {
                            string campo1 = "Fecha/Hora del Registro : " + fecha.ToString("yyyy") + "/" + fecha.ToString("MM") + "/" + fecha.ToString("dd") + " " +
                                    hora.ToString("HH") + ":" + hora.ToString("MM") + ":" + hora.ToString("ss") + "." + hora.ToString("fff");
                            string campo2 = "Temperatura : " + temperatura.ToString() + "°";
                            string campo3 = "Humedad : " + humedad.ToString() + "%";
                            string campo4 = "Codigo : “" + codigo.ToString() + "”";
                            string campo5 = estadoString;
                            Info datos = new Info(campo1, campo2, campo3, campo4, campo5);
                            //unaClase[n].AgregarDatos(campo1, campo2, campo3, campo4, campo5);
                            listaDatos.Add(datos);
                        }
                    }
                    else {
                        // error pedir datos
                        imprimirOK = false;
                        Console.WriteLine("Valor ingresado incorrecto");
                    }
                }
            } while (!imprimirOK);           
        }       
    }
}
