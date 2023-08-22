using System;

namespace Ejercicio7
{
    class Raices
    {
        // Atributos
        private double a;
        private double b;
        private double c;

        // Constructor
        public Raices(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Método para obtener el discriminante
        public double GetDiscriminante()
        {
            return (b * b) - (4 * a * c);
        }

        // Método para verificar si tiene dos soluciones
        public bool TieneRaices()
        {
            return GetDiscriminante() >= 0;
        }

        // Método para verificar si tiene una única solución
        public bool TieneRaiz()
        {
            return GetDiscriminante() == 0;
        }

        // Método para obtener las soluciones
        public void ObtenerRaices()
        {
            if (TieneRaices())
            {
                double raizDiscriminante = Math.Sqrt(GetDiscriminante());
                double x1 = (-b + raizDiscriminante) / (2 * a);
                double x2 = (-b - raizDiscriminante) / (2 * a);
                Console.WriteLine($"Solución 1: {x1}");
                Console.WriteLine($"Solución 2: {x2}");
            }
            else
            {
                Console.WriteLine("No existen soluciones reales.");
            }
        }

        // Método para obtener la única solución
        public void ObtenerRaiz()
        {
            if (TieneRaiz())
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Única solución: {x}");
            }
            else
            {
                Console.WriteLine("No existe una única solución.");
            }
        }

        // Método para calcular las soluciones
        public void Calcular()
        {
            if (TieneRaices())
            {
                ObtenerRaices();
            }
            else if (TieneRaiz())
            {
                ObtenerRaiz();
            }
            else
            {
                Console.WriteLine("No existen soluciones reales.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear objeto Raices con coeficientes a, b y c
            Raices ecuacion1 = new Raices(1, -3, 2);
            Raices ecuacion2 = new Raices(1, 0, -4);
            Raices ecuacion3 = new Raices(2, 4, 2);

            // Calcular y mostrar soluciones para cada ecuación
            Console.WriteLine("Ecuación 1:");
            ecuacion1.Calcular();

            Console.WriteLine("\nEcuación 2:");
            ecuacion2.Calcular();

            Console.WriteLine("\nEcuación 3:");
            ecuacion3.Calcular();
        }
    }
}
