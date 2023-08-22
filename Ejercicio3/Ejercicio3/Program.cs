using System;

namespace Ejercicio3
{
    class Password
    {
        private const int LongitudPorDefecto = 8; // Longitud por defecto de las contraseñas
        private const string CaracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";

        private int longitud;
        private string contraseña;

        // Constructor por defecto que genera una contraseña aleatoria
        public Password()
        {
            this.longitud = LongitudPorDefecto;
            this.contraseña = GenerarPassword(longitud);
        }

        // Constructor que recibe la longitud y genera una contraseña aleatoria
        public Password(int longitud)
        {
            this.longitud = longitud;
            this.contraseña = GenerarPassword(longitud);
        }

        // Verifica si la contraseña es fuerte
        public bool EsFuerte()
        {
            int mayusculas = 0;
            int minusculas = 0;
            int numeros = 0;

            // Contar el número de mayúsculas, minúsculas y números en la contraseña
            foreach (char c in contraseña)
            {
                if (char.IsUpper(c))
                {
                    mayusculas++;
                }
                else if (char.IsLower(c))
                {
                    minusculas++;
                }
                else if (char.IsDigit(c))
                {
                    numeros++;
                }
            }

            // Verificar si cumple con los requisitos de fortaleza
            return mayusculas > 2 && minusculas > 1 && numeros > 5;
        }

        // Genera una nueva contraseña aleatoria
        public void GenerarPassword()
        {
            contraseña = GenerarPassword(longitud);
        }

        // Obtiene la contraseña actual
        public string GetContraseña()
        {
            return contraseña;
        }

        // Obtiene la longitud actual
        public int GetLongitud()
        {
            return longitud;
        }

        // Cambia la longitud de la contraseña
        public void SetLongitud(int longitud)
        {
            this.longitud = longitud;
        }

        // Genera una contraseña aleatoria con la longitud especificada
        private string GenerarPassword(int longitud)
        {
            Random random = new Random();
            char[] password = new char[longitud];

            // Generar cada carácter de la contraseña aleatoriamente
            for (int i = 0; i < longitud; i++)
            {
                password[i] = CaracteresPermitidos[random.Next(CaracteresPermitidos.Length)];
            }

            return new string(password);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Ingrese la cantidad de contraseñas a generar: ");
            int cantidadContraseñas = int.Parse(Console.ReadLine());

            Password[] contraseñas = new Password[cantidadContraseñas];
            bool[] contraseñasFuertes = new bool[cantidadContraseñas];

            // Crear contraseñas y verificar su fortaleza
            for (int i = 0; i < cantidadContraseñas; i++)
            {
                Console.Write($"Ingrese la longitud para la contraseña {i + 1}: ");
                int longitud = int.Parse(Console.ReadLine());

                contraseñas[i] = new Password(longitud);
                contraseñasFuertes[i] = contraseñas[i].EsFuerte();
            }

            // Mostrar resultados
            Console.WriteLine("\nResultados:");
            for (int i = 0; i < cantidadContraseñas; i++)
            {
                Console.WriteLine($"{contraseñas[i].GetContraseña()} {contraseñasFuertes[i]}");
            }
        }
    }
}
