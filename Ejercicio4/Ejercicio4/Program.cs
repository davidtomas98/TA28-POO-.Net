using System;

namespace Ejercicio4
{
    class Electrodomestico
    {
        // Constantes para valores por defecto
        private const string ColorPorDefecto = "blanco";
        private const char ConsumoEnergeticoPorDefecto = 'F';
        private const double PrecioBasePorDefecto = 100;
        private const double PesoPorDefecto = 5;

        // Atributos
        private double precioBase;
        private string color;
        private char consumoEnergetico;
        private double peso;

        // Constructor por defecto
        public Electrodomestico()
        {
            this.precioBase = PrecioBasePorDefecto;
            this.color = ColorPorDefecto;
            this.consumoEnergetico = ConsumoEnergeticoPorDefecto;
            this.peso = PesoPorDefecto;
        }

        // Constructor con precio y peso, el resto por defecto
        public Electrodomestico(double precioBase, double peso)
        {
            this.precioBase = precioBase;
            this.color = ColorPorDefecto;
            this.consumoEnergetico = ConsumoEnergeticoPorDefecto;
            this.peso = peso;
        }

        // Constructor con todos los atributos
        public Electrodomestico(double precioBase, string color, char consumoEnergetico, double peso)
        {
            this.precioBase = precioBase;
            this.color = ComprobarColor(color);
            this.consumoEnergetico = ComprobarConsumoEnergetico(consumoEnergetico);
            this.peso = peso;
        }

        // Métodos get para los atributos
        public double GetPrecioBase()
        {
            return precioBase;
        }

        public string GetColor()
        {
            return color;
        }

        public char GetConsumoEnergetico()
        {
            return consumoEnergetico;
        }

        public double GetPeso()
        {
            return peso;
        }

        // Comprobar y ajustar la letra del consumo energético
        private char ComprobarConsumoEnergetico(char letra)
        {
            if (letra >= 'A' && letra <= 'F')
            {
                return letra;
            }
            return ConsumoEnergeticoPorDefecto;
        }

        // Comprobar y ajustar el color
        private string ComprobarColor(string color)
        {
            color = color.ToLower();
            if (color == "blanco" || color == "negro" || color == "rojo" || color == "azul" || color == "gris")
            {
                return color;
            }
            return ColorPorDefecto;
        }

        // Calcular el precio final según el consumo energético y el peso
        public virtual double PrecioFinal()
        {
            double aumentoConsumo = 0;
            double aumentoPeso = 0;

            switch (consumoEnergetico)
            {
                case 'A':
                    aumentoConsumo = 100;
                    break;
                case 'B':
                    aumentoConsumo = 80;
                    break;
                case 'C':
                    aumentoConsumo = 60;
                    break;
                case 'D':
                    aumentoConsumo = 50;
                    break;
                case 'E':
                    aumentoConsumo = 30;
                    break;
                case 'F':
                    aumentoConsumo = 10;
                    break;
            }

            if (peso >= 0 && peso < 19)
            {
                aumentoPeso = 10;
            }
            else if (peso >= 19 && peso < 49)
            {
                aumentoPeso = 50;
            }
            else if (peso >= 50 && peso <= 79)
            {
                aumentoPeso = 80;
            }
            else if (peso >= 80)
            {
                aumentoPeso = 100;
            }

            return precioBase + aumentoConsumo + aumentoPeso;
        }
    }

    class Lavadora : Electrodomestico
    {
        // Constante para carga por defecto
        private const double CargaPorDefecto = 5;

        // Atributo adicional
        private double carga;

        // Constructor por defecto
        public Lavadora() : base()
        {
            this.carga = CargaPorDefecto;
        }

        // Constructor con precio y peso, el resto por defecto
        public Lavadora(double precioBase, double peso) : base(precioBase, peso)
        {
            this.carga = CargaPorDefecto;
        }

        // Constructor con carga y atributos heredados
        public Lavadora(double precioBase, string color, char consumoEnergetico, double peso, double carga) : base(precioBase, color, consumoEnergetico, peso)
        {
            this.carga = carga;
        }

        // Método get para carga
        public double GetCarga()
        {
            return carga;
        }

        // Calcular el precio final según la carga
        public override double PrecioFinal()
        {
            double precioFinal = base.PrecioFinal();

            if (carga > 30)
            {
                precioFinal += 50;
            }

            return precioFinal;
        }
    }

    class Television : Electrodomestico
    {
        // Constantes para resolución y sintonizador TDT por defecto
        private const double ResolucionPorDefecto = 20;
        private const bool SintonizadorTDTPorDefecto = false;

        // Atributos adicionales
        private double resolucion;
        private bool sintonizadorTDT;

        // Constructor por defecto
        public Television() : base()
        {
            this.resolucion = ResolucionPorDefecto;
            this.sintonizadorTDT = SintonizadorTDTPorDefecto;
        }

        // Constructor con precio y peso, el resto por defecto
        public Television(double precioBase, double peso) : base(precioBase, peso)
        {
            this.resolucion = ResolucionPorDefecto;
            this.sintonizadorTDT = SintonizadorTDTPorDefecto;
        }

        // Constructor con resolución, sintonizador TDT y atributos heredados
        public Television(double precioBase, string color, char consumoEnergetico, double peso, double resolucion, bool sintonizadorTDT) : base(precioBase, color, consumoEnergetico, peso)
        {
            this.resolucion = resolucion;
            this.sintonizadorTDT = sintonizadorTDT;
        }

        // Método get para resolución
        public double GetResolucion()
        {
            return resolucion;
        }

        // Método para comprobar si tiene sintonizador TDT
        public bool TieneSintonizadorTDT()
        {
            return sintonizadorTDT;
        }

        // Calcular el precio final según la resolución y el sintonizador TDT
        public override double PrecioFinal()
        {
            double precioFinal = base.PrecioFinal();

            if (resolucion > 40)
            {
                precioFinal *= 1.3;
            }

            if (sintonizadorTDT)
            {
                precioFinal += 50;
            }

            return precioFinal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Electrodomestico[] electrodomesticos = new Electrodomestico[10];

            // Asignar electrodomésticos a cada posición
            electrodomesticos[0] = new Lavadora(200, "rojo", 'B', 15, 10);
            electrodomesticos[1] = new Television(300, "negro", 'A', 25, 45, true);
            // Agregar más electrodomésticos según sea necesario...

            // Calcular y mostrar los precios finales
            double totalElectrodomesticos = 0;
            double totalLavadoras = 0;
            double totalTelevisiones = 0;

            foreach (Electrodomestico electrodomestico in electrodomesticos)
            {
                if (electrodomestico != null)
                {
                    if (electrodomestico is Lavadora)
                    {
                        totalLavadoras += electrodomestico.PrecioFinal();
                    }
                    else if (electrodomestico is Television)
                    {
                        totalTelevisiones += electrodomestico.PrecioFinal();
                    }

                    totalElectrodomesticos += electrodomestico.PrecioFinal();
                }
            }

            Console.WriteLine($"Precio total electrodomésticos: {totalElectrodomesticos}");
            Console.WriteLine($"Precio total lavadoras: {totalLavadoras}");
            Console.WriteLine($"Precio total televisiones: {totalTelevisiones}");
        }
    }
}
