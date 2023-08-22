using System;

namespace Ejercicio8
{
    class Persona
    {
        protected string nombre;
        protected int edad;
        protected char sexo;

        public Persona(string nombre, int edad, char sexo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.sexo = sexo;
        }

        public virtual bool EstaDisponible()
        {
            return true;
        }

        public override string ToString()
        {
            return $"{nombre} ({sexo})";
        }
    }

    class Estudiante : Persona
    {
        private double calificacion;

        public Estudiante(string nombre, int edad, char sexo, double calificacion)
            : base(nombre, edad, sexo)
        {
            this.calificacion = calificacion;
        }

        public override bool EstaDisponible()
        {
            Random random = new Random();
            return random.NextDouble() > 0.5;
        }

        public double GetCalificacion()
        {
            return calificacion;
        }
    }

    class Profesor : Persona
    {
        private string materia;

        public Profesor(string nombre, int edad, char sexo, string materia)
            : base(nombre, edad, sexo)
        {
            this.materia = materia;
        }

        public override bool EstaDisponible()
        {
            Random random = new Random();
            return random.NextDouble() > 0.2;
        }

        public string GetMateria()
        {
            return materia;
        }
    }

    class Aula
    {
        private int id;
        private int capacidadMaxima;
        private string materia;
        private Profesor profesor;
        private Estudiante[] estudiantes;

        public Aula(int id, int capacidadMaxima, string materia, Profesor profesor, Estudiante[] estudiantes)
        {
            this.id = id;
            this.capacidadMaxima = capacidadMaxima;
            this.materia = materia;
            this.profesor = profesor;
            this.estudiantes = estudiantes;
        }

        public bool PuedeDarClase()
        {
            int alumnosPresentes = 0;

            // Contar el número de estudiantes presentes en el aula
            foreach (Estudiante estudiante in estudiantes)
            {
                if (estudiante.EstaDisponible())
                {
                    alumnosPresentes++;
                }
            }

            // Verificar si se cumplen las condiciones para dar clase
            return profesor.EstaDisponible() && (alumnosPresentes > capacidadMaxima / 2) && profesor.GetMateria() == materia;
        }

        public int ContarEstudiantesAprobados()
        {
            int count = 0;
            foreach (Estudiante estudiante in estudiantes)
            {
                // Contar el número de estudiantes con calificación aprobatoria (>= 5.0)
                if (estudiante.GetCalificacion() >= 5.0)
                {
                    count++;
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear profesores y estudiantes
            Profesor profesorMatematicas = new Profesor("Pablo Pérez", 35, 'M', "matemáticas");
            Profesor profesorFilosofia = new Profesor("María Rodríguez", 42, 'F', "filosofía");
            Profesor profesorFisica = new Profesor("Ana Gómez", 40, 'F', "física");

            Estudiante estudiante1 = new Estudiante("David Tomàs", 18, 'M', 7.5);
            Estudiante estudiante2 = new Estudiante("Oriol López", 19, 'F', 4.2);
            Estudiante estudiante3 = new Estudiante("Ferran Martínez", 20, 'M', 6.8);
            Estudiante estudiante4 = new Estudiante("Pau Sánchez", 18, 'F', 8.1);
            Estudiante estudiante5 = new Estudiante("Pedro Fernández", 19, 'M', 3.9);

            Estudiante[] estudiantes = { estudiante1, estudiante2, estudiante3, estudiante4, estudiante5 };

            // Crear aulas con profesores y estudiantes
            Aula aulaMatematicas = new Aula(1, 5, "matemáticas", profesorMatematicas, estudiantes);
            Aula aulaFilosofia = new Aula(2, 5, "filosofía", profesorFilosofia, estudiantes);
            Aula aulaFisica = new Aula(3, 5, "física", profesorFisica, estudiantes);

            // Verificar si se puede dar clase en cada aula y mostrar resultados
            Console.WriteLine("Aula de Matemáticas:");
            if (aulaMatematicas.PuedeDarClase())
            {
                Console.WriteLine("Se puede dar clase en el aula de Matemáticas.");
                Console.WriteLine("Cantidad de estudiantes aprobados: " + aulaMatematicas.ContarEstudiantesAprobados());
            }
            else
            {
                Console.WriteLine("No se puede dar clase en el aula de Matemáticas.");
            }

            Console.WriteLine("\nAula de Filosofía:");
            if (aulaFilosofia.PuedeDarClase())
            {
                Console.WriteLine("Se puede dar clase en el aula de Filosofía.");
                Console.WriteLine("Cantidad de estudiantes aprobados: " + aulaFilosofia.ContarEstudiantesAprobados());
            }
            else
            {
                Console.WriteLine("No se puede dar clase en el aula de Filosofía.");
            }

            Console.WriteLine("\nAula de Física:");
            if (aulaFisica.PuedeDarClase())
            {
                Console.WriteLine("Se puede dar clase en el aula de Física.");
                Console.WriteLine("Cantidad de estudiantes aprobados: " + aulaFisica.ContarEstudiantesAprobados());
            }
            else
            {
                Console.WriteLine("No se puede dar clase en el aula de Física.");
            }
        }
    }
}
