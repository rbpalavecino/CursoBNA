using System;

namespace PrimerProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 1 || (args[0] != "longformat" && args[0] != "shortformat"))
            {
                Console.WriteLine("Error parametro inicial, debe ser unico y de los valores acordados en documentacion ");

            }
            else
            {
                if (args.Length == 0 || args[0] == "longformat")
                {

                    String valorEntrada = "";
                    DateTime fecha;
                    DateTime hora;
                    float temperatura = 0;
                    float humedad = 0;
                    Boolean entradaOK;
                    string estadoString;

                    do
                    {
                        Console.WriteLine("Ingresar informacion");
                        valorEntrada = Console.ReadLine();
                        if (valorEntrada.Length == 25)
                        {
                            entradaOK = true;
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
                                //    Console.WriteLine("temperatura ingresada incorrecta");
                                Console.WriteLine(" Temperatura incorrecta: {0}", error.Message);
                                entradaOK = false;
                            }
                            try
                            {
                                humedad = float.Parse(hument + "," + humdec);

                            }
                            catch (Exception error)
                            {
                                //    Console.WriteLine("temperatura ingresada incorrecta");
                                Console.WriteLine(" Humedad incorrecta: {0}", error.Message);
                                entradaOK = false;

                            }
                            if (!DateTime.TryParseExact(fec, formatFec, System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out fecha))
                            {
                                Console.WriteLine("fecha incorrecta {0}", fecha);
                                entradaOK = false;
                            }

                            if (!DateTime.TryParseExact(horastring, formatHora, System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out hora))
                            {
                                Console.WriteLine("hora incorrecta");
                                entradaOK = false;
                            }
                            if (codigo != "AC1C")
                            {
                                Console.WriteLine("Codigo Incorrecto");
                                entradaOK = false;
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
                                    entradaOK = false;
                                    break;

                            }
                            if (entradaOK)
                            {
                                Console.WriteLine("Fecha del registro: {0}/{1}/{2} ", fecha.ToString("yyyy"), fecha.ToString("MM"), fecha.ToString("dd"));
                                Console.WriteLine("Hora del registro: {0}hs {1}min {2}seg ", hora.ToString("HH"), hora.ToString("MM"), hora.ToString("ss"));
                                Console.WriteLine("Temperatura: {0}°", temperatura);
                                Console.WriteLine("Humedad: {0}% ", humedad);
                                Console.WriteLine("Codigo: “{0}” ", codigo);
                                Console.WriteLine(estadoString);

                            }
                        }
                        else
                        {
                            Console.WriteLine("Error al ingresar informacion, chequear documento funcional");
                            entradaOK = false;
                        }

                    } while (!entradaOK);

                }
                else
                {

                    if (args[0] == "shortformat")
                    {
                        String valorEntrada = "";
                        DateTime fecha;
                        DateTime hora;
                        float temperatura = 0;
                        float humedad = 0;
                        Boolean entradaOK;
                        string estadoString;

                        do
                        {
                            Console.WriteLine("Ingresar informacion");
                            valorEntrada = Console.ReadLine();
                            if (valorEntrada.Length == 25)
                            {
                                entradaOK = true;
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
                                    //    Console.WriteLine("temperatura ingresada incorrecta");
                                    Console.WriteLine(" Temperatura incorrecta: {0}", error.Message);
                                    entradaOK = false;
                                }
                                try
                                {
                                    humedad = float.Parse(hument + "," + humdec);

                                }
                                catch (Exception error)
                                {
                                    //    Console.WriteLine("temperatura ingresada incorrecta");
                                    Console.WriteLine(" Humedad incorrecta: {0}", error.Message);
                                    entradaOK = false;

                                }
                                if (!DateTime.TryParseExact(fec, formatFec, System.Globalization.CultureInfo.InvariantCulture,
                                             System.Globalization.DateTimeStyles.None,
                                              out fecha))
                                {
                                    Console.WriteLine("fecha incorrecta {0}", fecha);
                                    entradaOK = false;
                                }
                                if (!DateTime.TryParseExact(horastring, formatHora, System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out hora))
                                {
                                    Console.WriteLine("hora incorrecta");
                                    entradaOK = false;
                                }
                                if (codigo != "AC1C")
                                {
                                    Console.WriteLine("Codigo Incorrecto");
                                    entradaOK = false;
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
                                        entradaOK = false;
                                        break;

                                }
                                if (entradaOK)
                                {
                                    Console.WriteLine("Fecha/hora del registro: {0}/{1}/{2} {3}:{4}:{5}.{6}  ", fecha.ToString("yyyy"), fecha.ToString("MM"), fecha.ToString("dd")
                                    , hora.ToString("HH"), hora.ToString("MM"), hora.ToString("ss"), hora.ToString("fff"));
                                    Console.WriteLine("Temperatura: {0}°", temperatura);
                                    Console.WriteLine("Humedad: {0}% ", humedad);
                                    Console.WriteLine("Codigo: “{0}” ", codigo);
                                    Console.WriteLine(estadoString);

                                }
                            }
                            else
                            {
                                Console.WriteLine("Error al ingresar informacion, chequear documento funcional");
                                entradaOK = false;
                            }

                        } while (!entradaOK);

                    }

                }


            }
        }
    }
}
