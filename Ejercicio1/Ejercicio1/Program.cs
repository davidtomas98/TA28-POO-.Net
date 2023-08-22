using System;

namespace Ejercici1
{
    class Cuenta
    {
        private string titular;
        private double cantidad;

        // Constructor sin cantidad inicial
        public Cuenta(string titular)
        {
            this.titular = titular;
            this.cantidad = 0;
        }

        // Constructor con cantidad inicial
        public Cuenta(string titular, double cantidad)
        {
            this.titular = titular;
            this.cantidad = cantidad;
        }

        // Propiedades para acceder a los atributos
        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        // Representación en cadena de la cuenta
        public override string ToString()
        {
            return $"Titular: {titular}, Cantidad: {cantidad}";
        }

        // Método para ingresar dinero a la cuenta
        public void Ingresar(double cantidad)
        {
            if (cantidad > 0)
            {
                this.cantidad += cantidad;
            }
        }

        // Método para retirar dinero de la cuenta
        public void Retirar(double cantidad)
        {
            if (cantidad > 0)
            {
                if (this.cantidad - cantidad >= 0)
                {
                    this.cantidad -= cantidad;
                }
                else
                {
                    this.cantidad = 0;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear cuentas utilizando los constructores
            Cuenta cuenta1 = new Cuenta("David Tomàs");
            Cuenta cuenta2 = new Cuenta("Adria Vergés", 1000);

            Console.WriteLine(cuenta1); // Mostrar información de la cuenta1
            Console.WriteLine(cuenta2); // Mostrar información de la cuenta2

            cuenta1.Ingresar(500); // Ingresar 500 a la cuenta1
            cuenta2.Retirar(200); // Retirar 200 de la cuenta2

            Console.WriteLine(cuenta1); // Mostrar información actualizada de la cuenta1
            Console.WriteLine(cuenta2); // Mostrar información actualizada de la cuenta2
        }
    }
}
