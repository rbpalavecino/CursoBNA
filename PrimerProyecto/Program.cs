using System;

namespace PrimerProyecto
{
    class Program
    {
        static void Main(string[] args)
        {

            //!Los strings fijos, como ser los valores "longformat" y "shortformat" deberian ir declarados en constantes.
            if (args.Length > 1 || (args[0] != "longformat" && args[0] != "shortformat"))
            {

                //! Conviene imprimir el valor erroneo detectado, total lo tenemos a mano en args[0]
                Console.WriteLine("Error parametro inicial, debe ser unico y de los valores acordados en documentacion ");

            }
            else
            {
                //! Si hubiera 10 condiciones mas para vaalidar sobre la linea de entrada, anidarias 10 IFs mas?
                // quedaria poco legible y muy dificil de seguir. Ver Video de Condiciones de guarda que figura en el doc del Programa del Curso: https://www.youtube.com/watch?v=FVxS28oyLuw
                if (args.Length == 0 || args[0] == "longformat")
                {

                    String valorEntrada = "";
                    DateTime fecha;             //! Bien por el uso de DateTiem! 
                    DateTime hora;              //! Fecha y hora podrian guardarse en la misma variable
                    float temperatura = 0;      //! Bien! Es muy apropiado el uso de float. Por que lo usaste en lugar de "decimal" o "double"?
                    float humedad = 0;
                    Boolean entradaOK;
                    string estadoString;

                    do
                    {   //! Sigue creciendo el anidamiento de estrucutras...
                        Console.WriteLine("Ingresar informacion");
                        valorEntrada = Console.ReadLine();
                        if (valorEntrada.Length == 25)      //! Parametrizarlo en una constante
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
                                //! Si en vez de leer parte entera y decimal y luego concatenar, leo los 3 digitos de la 
                                // temperatura de una y luego lo divido por 10? lleva menos lineas y una opracion de division entera 
                                // tiene un costo computacional muchisimo menor, ademas de que tambien te ahorras un parseo a float
                                temperatura = float.Parse(tempent + "," + tempdec); 

                                //! Si usaba TryParse, me ahorraba el try catch
                            }
                            catch (Exception error)
                            {
                                //    Console.WriteLine("temperatura ingresada incorrecta");
                                Console.WriteLine(" Temperatura incorrecta: {0}", error.Message);
                                entradaOK = false;
                            }
                            try     //! En gral es un buen tip de legibilidad separar con una linea las estructuras de bloque (try/if/while, etc)
                            {
                                //! Mismo comentario que con la temperatura
                                humedad = float.Parse(hument + "," + humdec);

                            }
                            catch (Exception error)
                            {
                                //    Console.WriteLine("temperatura ingresada incorrecta");
                                Console.WriteLine(" Humedad incorrecta: {0}", error.Message);
                                entradaOK = false;

                            }

                            //! Muy bien por usar TryParseExact!. Fijate que podrias incluir la hora tambien en esta linea
                            if (!DateTime.TryParseExact(fec, formatFec, System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out fecha))
                            {
                                Console.WriteLine("fecha incorrecta {0}", fecha);
                                entradaOK = false;  //! Entiendo, si entradaOK es false, entonces el programa no debe continuar
                                                    //
                            }

                            if (!DateTime.TryParseExact(horastring, formatHora, System.Globalization.CultureInfo.InvariantCulture,
                                          System.Globalization.DateTimeStyles.None,
                                          out hora))
                            {
                                Console.WriteLine("hora incorrecta");
                                entradaOK = false;
                            }
                            if (codigo != "AC1C")       //! Ojo, el codigo puede ser cualquier combinacion de 4 caracteres, en principio no lo sabriamos validar.
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
                                    estadoString = "Estado Incorrecto"; //! Bien! si no es ningun estado conocido se falla y se envia el msje
                                    Console.WriteLine(estadoString);
                                    entradaOK = false;
                                    break;

                            }
                            if (entradaOK)  
                            {
                                //!! Aca ya hay 6 niveles de anidamiento = 6 condiciones que tiene que tener en mente el 
                                //lector del codigo para saber el contexto en el cual se puede llegar a esta parte. 
                                Console.WriteLine("Fecha del registro: {0}/{1}/{2} ", fecha.ToString("yyyy"), fecha.ToString("MM"), fecha.ToString("dd"));
                                Console.WriteLine("Hora del registro: {0}hs {1}min {2}seg ", hora.ToString("HH"), hora.ToString("MM"), hora.ToString("ss"));
                                //! Sugerencia: Considerar usar el operador "$", tal vez resulte mas comodo y legible
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

                                //!!!!! Otra vez todo lo mismo?? Pero si ya lo habias codeado para el otro caso
                                // podrias meter todo lo repetido en una funcion, o mejor, hacerlo solo una vez para cualquier caso
                                // y al final de todo, cuando ya tenes todo parseado, elegir como mostras los datos, en particular la linea de la fecha-hora

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
