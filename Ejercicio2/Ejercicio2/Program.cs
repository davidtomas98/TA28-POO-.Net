using System;

namespace Ejercicio2
{
    class Persona
    {
        private const char SexoPorDefecto = 'H'; // Sexo por defecto para corrección
        private const double PesoIdealBajo = 20; // Límite inferior para peso ideal
        private const double PesoIdealAlto = 25; // Límite superior para peso ideal

        private string nombre;
        private int edad;
        private char sexo;
        private double peso;
        private double altura;
        private string dni;

        // Constructor por defecto
        public Persona()
        {
            this.nombre = "";
            this.edad = 0;
            this.sexo = SexoPorDefecto;
            this.peso = 0;
            this.altura = 0;
            this.dni = GenerarDNI();
        }

        // Constructor con nombre, edad y sexo
        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = ComprobarSexo(sexo);
            this.peso = 0;
            this.altura = 0;
            this.dni = GenerarDNI();
        }

        // Constructor con todos los atributos
        public Persona(string nombre, int edad, char sexo, double peso, double altura)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = ComprobarSexo(sexo);
            this.peso = peso;
            this.altura = altura;
            this.dni = GenerarDNI();
        }

        // Método para comprobar si el sexo es válido y corregirlo si no lo es
        private char ComprobarSexo(char sexo)
        {
            if (sexo == 'H' || sexo == 'M')
            {
                return sexo;
            }
            return SexoPorDefecto; // Si no es válido, asignar sexo por defecto
        }

        // Genera un DNI aleatorio y calcula la letra correspondiente
        private string GenerarDNI()
        {
            Random random = new Random();
            int numeroDNI = random.Next(10000000, 99999999);
            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            char letraDNI = letras[numeroDNI % 23];
            return $"{numeroDNI}-{letraDNI}";
        }

        // Calcula el índice de masa corporal (IMC) y devuelve una categoría
        public int CalcularIMC()
        {
            double imc = peso / (altura * altura);
            if (imc < PesoIdealBajo)
            {
                return -1; // Bajo peso
            }
            else if (imc >= PesoIdealBajo && imc <= PesoIdealAlto)
            {
                return 0; // Peso ideal
            }
            else
            {
                return 1; // Sobrepeso
            }
        }

        // Verifica si la persona es mayor de edad
        public bool EsMayorDeEdad()
        {
            return edad >= 18;
        }

        // Genera una representación en cadena de la información de la persona
        public override string ToString()
        {
            return $"Nombre: {nombre}\nEdad: {edad}\nDNI: {dni}\nSexo: {sexo}\nPeso: {peso} kg\nAltura: {altura} m";
        }

        // Métodos set para los atributos
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public void SetEdad(int edad)
        {
            this.edad = edad;
        }

        public void SetSexo(char sexo)
        {
            this.sexo = ComprobarSexo(sexo);
        }

        public void SetPeso(double peso)
        {
            this.peso = peso;
        }

        public void SetAltura(double altura)
        {
            this.altura = altura;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Solicitar datos de la primera persona al usuario
            Console.WriteLine("Ingrese los datos de la primera persona:");
            Console.Write("Nombre: ");
            string nombre1 = Console.ReadLine();
            Console.Write("Edad: ");
            int edad1 = int.Parse(Console.ReadLine());
            Console.Write("Sexo (H/M): ");
            char sexo1 = char.ToUpper(Console.ReadLine()[0]);
            Console.Write("Peso (kg): ");
            double peso1 = double.Parse(Console.ReadLine());
            Console.Write("Altura (m): ");
            double altura1 = double.Parse(Console.ReadLine());

            // Crear objeto de persona usando el constructor con todos los atributos
            Persona persona1 = new Persona(nombre1, edad1, sexo1, peso1, altura1);

            // Crear objeto de persona con datos predeterminados y establecer peso y altura
            Persona persona2 = new Persona("Oriol", 28, 'M');
            persona2.SetPeso(60);
            persona2.SetAltura(1.65);

            // Crear objeto de persona con valores predeterminados
            Persona persona3 = new Persona();

            // Comprobar peso y edad para cada persona y mostrar información
            Console.WriteLine("\nInformación de la primera persona:");
            int resultadoIMC1 = persona1.CalcularIMC();
            Console.WriteLine($"Estado de peso: {(resultadoIMC1 == -1 ? "Bajo peso" : resultadoIMC1 == 0 ? "Peso ideal" : "Sobrepeso")}");
            Console.WriteLine($"Mayor de edad: {persona1.EsMayorDeEdad()}");
            Console.WriteLine(persona1);

            Console.WriteLine("\nInformación de la segunda persona:");
            int resultadoIMC2 = persona2.CalcularIMC();
            Console.WriteLine($"Estado de peso: {(resultadoIMC2 == -1 ? "Bajo peso" : resultadoIMC2 == 0 ? "Peso ideal" : "Sobrepeso")}");
            Console.WriteLine($"Mayor de edad: {persona2.EsMayorDeEdad()}");
            Console.WriteLine(persona2);

            Console.WriteLine("\nInformación de la tercera persona:");
            int resultadoIMC3 = persona3.CalcularIMC();
            Console.WriteLine($"Estado de peso: {(resultadoIMC3 == -1 ? "Bajo peso" : resultadoIMC3 == 0 ? "Peso ideal" : "Sobrepeso")}");
            Console.WriteLine($"Mayor de edad: {persona3.EsMayorDeEdad()}");
            Console.WriteLine(persona3);
        }
    }
}
