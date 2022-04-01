using System;

namespace PrimerProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            String valorEntrada = "";
            DateTime fecha;
            DateTime hora;
            float temperatura;
            float humedad;

            Console.WriteLine("Ingresar informacion");
            valorEntrada = Console.ReadLine();

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

                      
            DateTime.TryParseExact(fec, formatFec, System.Globalization.CultureInfo.InvariantCulture,
                          System.Globalization.DateTimeStyles.None,
                          out fecha);
            DateTime.TryParseExact(horastring, formatHora, System.Globalization.CultureInfo.InvariantCulture,
                          System.Globalization.DateTimeStyles.None,
                          out hora);

            temperatura = float.Parse(tempent + "," + tempdec);
            humedad = float.Parse(hument + "," + humdec);

            Console.WriteLine("Fecha del registro: {0}/{1}/{2} ", fecha.ToString("yyyy"), fecha.ToString("MM"), fecha.ToString("dd")) ;
            Console.WriteLine("Hora del registro: {0}hs {1}min {2}seg ", hora.ToString("HH"), hora.ToString("MM"), hora.ToString("ss"));
            Console.WriteLine("Temperatura: {0}°", temperatura);
            Console.WriteLine("Humedad: {0}% ", humedad);
            Console.WriteLine("Codigo: “{0}” ", codigo);
            if (estado == "0"){
                Console.WriteLine("Activo : NO");
            }
            else { Console.WriteLine("Activo : SI"); }
        }
    }
}
