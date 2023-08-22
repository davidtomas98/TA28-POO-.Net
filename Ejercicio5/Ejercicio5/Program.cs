using System;

namespace Ejercicio5
{
    // Interfaz Entregable
    interface Entregable
    {
        void Entregar();
        void Devolver();
        bool IsEntregado();
    }

    // Clase Serie
    class Serie : Entregable
    {
        private string titulo;
        private int numeroTemporadas;
        private bool entregado;
        private string genero;
        private string creador;

        // Constructores

        public Serie()
        {
            this.titulo = "";
            this.numeroTemporadas = 3;
            this.entregado = false;
            this.genero = "";
            this.creador = "";
        }

        public Serie(string titulo, string creador)
        {
            this.titulo = titulo;
            this.numeroTemporadas = 3;
            this.entregado = false;
            this.genero = "";
            this.creador = creador;
        }

        public Serie(string titulo, int numeroTemporadas, string genero, string creador)
        {
            this.titulo = titulo;
            this.numeroTemporadas = numeroTemporadas;
            this.entregado = false;
            this.genero = genero;
            this.creador = creador;
        }

        // Implementación de la interfaz Entregable
        public void Entregar()
        {
            entregado = true;
        }

        public void Devolver()
        {
            entregado = false;
        }

        public bool IsEntregado()
        {
            return entregado;
        }

        // Métodos get y set
        public string GetTitulo()
        {
            return titulo;
        }

        public int GetNumeroTemporadas()
        {
            return numeroTemporadas;
        }

        public string GetGenero()
        {
            return genero;
        }

        public string GetCreador()
        {
            return creador;
        }

        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void SetNumeroTemporadas(int numeroTemporadas)
        {
            this.numeroTemporadas = numeroTemporadas;
        }

        public void SetGenero(string genero)
        {
            this.genero = genero;
        }

        public void SetCreador(string creador)
        {
            this.creador = creador;
        }

        // Sobrescritura del método ToString
        public override string ToString()
        {
            return "Serie [titulo=" + titulo + ", numeroTemporadas=" + numeroTemporadas + ", entregado=" + entregado + ", genero=" + genero + ", creador=" + creador + "]";
        }
    }

    // Clase Videojuego
    class Videojuego : Entregable
    {
        private string titulo;
        private int horasEstimadas;
        private bool entregado;
        private string genero;
        private string compañia;

        // Constructores

        public Videojuego()
        {
            this.titulo = "";
            this.horasEstimadas = 10;
            this.entregado = false;
            this.genero = "";
            this.compañia = "";
        }

        public Videojuego(string titulo, int horasEstimadas)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.entregado = false;
            this.genero = "";
            this.compañia = "";
        }

        public Videojuego(string titulo, int horasEstimadas, string genero, string compañia)
        {
            this.titulo = titulo;
            this.horasEstimadas = horasEstimadas;
            this.entregado = false;
            this.genero = genero;
            this.compañia = compañia;
        }

        // Implementación de la interfaz Entregable
        public void Entregar()
        {
            entregado = true;
        }

        public void Devolver()
        {
            entregado = false;
        }

        public bool IsEntregado()
        {
            return entregado;
        }

        // Métodos get y set
        public string GetTitulo()
        {
            return titulo;
        }

        public int GetHorasEstimadas()
        {
            return horasEstimadas;
        }

        public string GetGenero()
        {
            return genero;
        }

        public string GetCompañia()
        {
            return compañia;
        }

        public void SetTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public void SetHorasEstimadas(int horasEstimadas)
        {
            this.horasEstimadas = horasEstimadas;
        }

        public void SetGenero(string genero)
        {
            this.genero = genero;
        }

        public void SetCompañia(string compañia)
        {
            this.compañia = compañia;
        }

        // Sobrescritura del método ToString
        public override string ToString()
        {
            return "Videojuego [titulo=" + titulo + ", horasEstimadas=" + horasEstimadas + ", entregado=" + entregado + ", genero=" + genero + ", compañia=" + compañia + "]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Serie[] series = new Serie[5];
            Videojuego[] videojuegos = new Videojuego[5];

            // Crear objetos en cada posición
            series[0] = new Serie("Friends", 10, "Comedia", "David Crane");
            series[1] = new Serie("Breaking Bad", "Vince Gilligan");
            // Agregar más series según sea necesario...

            videojuegos[0] = new Videojuego("The Legend of Zelda: Breath of the Wild", 50, "Aventura", "Nintendo");
            videojuegos[1] = new Videojuego("Red Dead Redemption 2", 70, "Acción", "Rockstar Games");
            // Agregar más videojuegos según sea necesario...

            // Entregar algunos elementos
            series[0].Entregar();
            videojuegos[1].Entregar();

            // Contar y mostrar series y videojuegos entregados
            int seriesEntregadas = ContarEntregados(series);
            int videojuegosEntregados = ContarEntregados(videojuegos);

            Console.WriteLine($"Series entregadas: {seriesEntregadas}");
            Console.WriteLine($"Videojuegos entregados: {videojuegosEntregados}");

            // Encontrar serie con más temporadas y videojuego con más horas estimadas
            Serie serieMasTemporadas = EncontrarSerieMasTemporadas(series);
            Videojuego videojuegoMasHoras = EncontrarVideojuegoMasHoras(videojuegos);

            if (serieMasTemporadas != null)
            {
                Console.WriteLine($"Serie con más temporadas: {serieMasTemporadas}");
            }
            else
            {
                Console.WriteLine("No se encontraron series.");
            }

            if (videojuegoMasHoras != null)
            {
                Console.WriteLine($"Videojuego con más horas estimadas: {videojuegoMasHoras}");
            }
            else
            {
                Console.WriteLine("No se encontraron videojuegos.");
            }
        }

        // Método para contar objetos entregados
        static int ContarEntregados(Entregable[] objetos)
        {
            int count = 0;
            foreach (Entregable objeto in objetos)
            {
                if (objeto != null && objeto.IsEntregado())
                {
                    count++;
                }
            }
            return count;
        }

        // Método para encontrar la serie con más temporadas
        static Serie EncontrarSerieMasTemporadas(Serie[] series)
        {
            Serie serieMasTemporadas = null;
            int maxTemporadas = -1;

            foreach (Serie serie in series)
            {
                if (serie != null && serie.GetNumeroTemporadas() > maxTemporadas)
                {
                    maxTemporadas = serie.GetNumeroTemporadas();
                    serieMasTemporadas = serie;
                }
            }

            return serieMasTemporadas;
        }

        // Método para encontrar el videojuego con más horas estimadas
        static Videojuego EncontrarVideojuegoMasHoras(Videojuego[] videojuegos)
        {
            Videojuego videojuegoMasHoras = null;
            int maxHoras = -1;

            foreach (Videojuego videojuego in videojuegos)
            {
                if (videojuego != null && videojuego.GetHorasEstimadas() > maxHoras)
                {
                    maxHoras = videojuego.GetHorasEstimadas();
                    videojuegoMasHoras = videojuego;
                }
            }

            return videojuegoMasHoras;
        }
    }
}
