using System;                  
using System.Collections.Generic;

class Biblioteca
{
    private Dictionary<string, (string Autor, string Genero)> libros;

    public Biblioteca()
    {
        libros = new Dictionary<string, (string, string)>();
    }

    public void AgregarLibro(string titulo, string autor, string genero)
    {
        if (libros.ContainsKey(titulo))
        {
            Console.WriteLine("El libro ya está registrado.");
        }
        else
        {
            libros[titulo] = (autor, genero);
            Console.WriteLine($"Libro '{titulo}' agregado correctamente.");
        }
    }

    public void EliminarLibro(string titulo)
    {
        if (libros.Remove(titulo))
        {
            Console.WriteLine($"Libro '{titulo}' eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("El libro no existe en la biblioteca.");
        }
    }

    public void BuscarLibro(string titulo)
    {
        if (libros.TryGetValue(titulo, out var datos))
        {
            Console.WriteLine($"Información del libro '{titulo}': Autor: {datos.Autor}, Género: {datos.Genero}");
        }
        else
        {
            Console.WriteLine("El libro no se encuentra en la biblioteca.");
        }
    }

    public void MostrarLibros()
    {
        if (libros.Count > 0)
        {
            Console.WriteLine("Libros en la biblioteca:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"- {libro.Key} | Autor: {libro.Value.Autor} | Género: {libro.Value.Genero}");
            }
        }
        else
        {
            Console.WriteLine("No hay libros registrados.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido al sistema de biblioteca.");

        Biblioteca biblioteca = new Biblioteca();

        while (true)
        {
            Console.WriteLine("\nMenú Biblioteca:");
            Console.WriteLine("1. Agregar libro");
            Console.WriteLine("2. Eliminar libro");
            Console.WriteLine("3. Buscar libro");
            Console.WriteLine("4. Mostrar libros");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string autor = Console.ReadLine();
                    Console.Write("Ingrese el género del libro: ");
                    string genero = Console.ReadLine();
                    biblioteca.AgregarLibro(titulo, autor, genero);
                    break;
                case "2":
                    Console.Write("Ingrese el título del libro a eliminar: ");
                    titulo = Console.ReadLine();
                    biblioteca.EliminarLibro(titulo);
                    break;
                case "3":
                    Console.Write("Ingrese el título del libro a buscar: ");
                    titulo = Console.ReadLine();
                    biblioteca.BuscarLibro(titulo);
                    break;
                case "4":
                    biblioteca.MostrarLibros();
                    break;
                case "5":
                    Console.WriteLine("Saliendo del sistema de biblioteca.");
                    return;
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    break;
            }
        }
    }
}
