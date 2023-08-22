using System;
using System.Collections.Generic;

namespace CineApp
{
    class Pelicula
    {
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public int EdadMinima { get; set; }
        public string Director { get; set; }
    }

    class Espectador
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Dinero { get; set; }
    }

    class Asiento
    {
        public char Fila { get; set; }
        public int Columna { get; set; }
        public bool Ocupado { get; set; }
    }

    class Cine
    {
        private Pelicula peliculaActual;
        private double precioEntrada;
        private List<Espectador> espectadores;
        private Asiento[,] asientos;

        public Cine(Pelicula pelicula, double precioEntrada)
        {
            this.peliculaActual = pelicula;
            this.precioEntrada = precioEntrada;
            espectadores = new List<Espectador>();
            asientos = new Asiento[8, 9];

            // Inicializar matriz de asientos
            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 9; columna++)
                {
                    asientos[fila, columna] = new Asiento { Fila = (char)('1' + fila), Columna = columna + 1, Ocupado = false };
                }
            }
        }

        public void AgregarEspectador(Espectador espectador)
        {
            if (espectador.Edad >= peliculaActual.EdadMinima && espectador.Dinero >= precioEntrada)
            {
                bool sentado = false;

                while (!sentado)
                {
                    // Generar asiento aleatorio
                    int filaAleatoria = new Random().Next(8);
                    int columnaAleatoria = new Random().Next(9);

                    // Verificar si el asiento está disponible
                    if (!asientos[filaAleatoria, columnaAleatoria].Ocupado)
                    {
                        asientos[filaAleatoria, columnaAleatoria].Ocupado = true;
                        espectadores.Add(espectador);
                        sentado = true;
                    }
                }
            }
        }

        public void MostrarEstadoSala()
        {
            Console.WriteLine("Estado de la sala:\n");

            // Mostrar estado de los asientos en la sala con símbolos de butacas
            for (int fila = 7; fila >= 0; fila--)
            {
                Console.Write($"{fila + 1} ");
                for (int columna = 0; columna < 9; columna++)
                {
                    if (asientos[fila, columna].Ocupado)
                    {
                        Console.Write("[X] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   A   B   C   D   E   F   G   H   I");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pelicula pelicula = new Pelicula
            {
                Titulo = "Les aventures de David",
                Duracion = 120,
                EdadMinima = 12,
                Director = "David Tomás"
            };

            Cine cine = new Cine(pelicula, 10.0);

            // Generar y agregar espectadores aleatoriamente
            for (int i = 0; i < 50; i++)
            {
                Espectador espectador = new Espectador
                {
                    Nombre = "Espectador" + i,
                    Edad = new Random().Next(5, 65),
                    Dinero = new Random().Next(0, 50)
                };

                cine.AgregarEspectador(espectador);
            }

            // Mostrar el estado de la sala con los asientos ocupados
            cine.MostrarEstadoSala();
        }
    }
}
