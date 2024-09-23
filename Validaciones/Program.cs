using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Validación de Patente
        Console.WriteLine("Ingrese la patente del automóvil:");
        string patente = Console.ReadLine();

        if (ValidarPatente(patente))
        {
            Console.WriteLine("La patente es válida.");
        }
        else
        {
            Console.WriteLine("La patente es inválida.");
        }

        // Extracción de DNI desde el CUIL
        Console.WriteLine("Ingrese el CUIL en formato NN-NNNNNNNN-N:");
        string cuil = Console.ReadLine();

        string dni = ExtraerDNI(cuil);

        if (dni != null)
        {
            Console.WriteLine("El DNI extraído es: " + dni);
        }
        else
        {
            Console.WriteLine("El formato del CUIL es incorrecto.");
        }
    }

    // Validación de Patente usando Expresiones Regulares
    static bool ValidarPatente(string patente)
    {
        // Patente formato "AANNNAA" o "AAANNN"
        string patron = @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$|^[A-Z]{3}[0-9]{3}$";
        return Regex.IsMatch(patente, patron);
    }




    static string ExtraerDNI(string cuil)
    {
        // Validar que el CUIL tenga exactamente 13 caracteres y el formato correcto
        if (cuil.Length == 13 && cuil[2] == '-' && cuil[11] == '-')
        {
            // Verificar que los caracteres entre los guiones sean números
            if (EsNumero(cuil[3]) && EsNumero(cuil[4]) && EsNumero(cuil[5]) &&
                EsNumero(cuil[6]) && EsNumero(cuil[7]) && EsNumero(cuil[8]) &&
                EsNumero(cuil[9]) && EsNumero(cuil[10]))
            {
                // Extraer los 8 dígitos del DNI

                return cuil.Substring(3, 8);
            }
        }

        return null;
    }

    static bool EsNumero(char c)
    {
        return c >= '0' && c <= '9'; // Verifica si el carácter es un número
    }
}
