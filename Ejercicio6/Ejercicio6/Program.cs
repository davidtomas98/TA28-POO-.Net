using System;

namespace Ejercicio6
{
    class Libro
    {
        // Atributos
        private string ISBN;
        private string Titulo;
        private string Autor;
        private int NumPaginas;

        // Constructor
        public Libro(string isbn, string titulo, string autor, int numPaginas)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            NumPaginas = numPaginas;
        }

        // Métodos get y set
        public string GetISBN()
        {
            return ISBN;
        }

        public void SetISBN(string isbn)
        {
            ISBN = isbn;
        }

        public string GetTitulo()
        {
            return Titulo;
        }

        public void SetTitulo(string titulo)
        {
            Titulo = titulo;
        }

        public string GetAutor()
        {
            return Autor;
        }

        public void SetAutor(string autor)
        {
            Autor = autor;
        }

        public int GetNumPaginas()
        {
            return NumPaginas;
        }

        public void SetNumPaginas(int numPaginas)
        {
            NumPaginas = numPaginas;
        }

        // Método toString()
        public override string ToString()
        {
            return $"El libro con ISBN {ISBN} creado por {Autor} tiene {NumPaginas} páginas.";
        }
    }

    class Program
    {
        // Método para encontrar el libro con más páginas
        static Libro EncontrarLibroConMasPaginas(Libro[] libros)
        {
            Libro libroMasPaginas = null;
            int maxPaginas = -1;

            foreach (Libro libro in libros)
            {
                if (libro.GetNumPaginas() > maxPaginas)
                {
                    maxPaginas = libro.GetNumPaginas();
                    libroMasPaginas = libro;
                }
            }

            return libroMasPaginas;
        }

        static void Main(string[] args)
        {
            // Crear objetos Libro con ejemplos de libros famosos
            Libro libro1 = new Libro("978-8478884459", "Harry Potter y la piedra filosofal", "J.K. Rowling", 336);
            Libro libro2 = new Libro("978-8478885180", "Harry Potter y la cámara secreta", "J.K. Rowling", 288);
            Libro libro3 = new Libro("978-8498387079", "Harry Potter y el prisionero de Azkaban", "J.K. Rowling", 480);
            Libro libro4 = new Libro("978-8498386942", "Harry Potter y el cáliz de fuego", "J.K. Rowling", 736);
            Libro libro5 = new Libro("978-8445000288", "El Hobbit", "J.R.R. Tolkien", 304);

            // Mostrar información de los libros
            Console.WriteLine(libro1);
            Console.WriteLine(libro2);
            Console.WriteLine(libro3);
            Console.WriteLine(libro4);
            Console.WriteLine(libro5);

            // Encontrar el libro con más páginas
            Libro[] libros = { libro1, libro2, libro3, libro4, libro5 };
            Libro libroConMasPaginas = EncontrarLibroConMasPaginas(libros);
            if (libroConMasPaginas != null)
            {
                Console.WriteLine($"El libro con más páginas es: {libroConMasPaginas.GetTitulo()} ({libroConMasPaginas.GetNumPaginas()} páginas).");
            }
            else
            {
                Console.WriteLine("No se encontraron libros.");
            }
        }
    }
}
