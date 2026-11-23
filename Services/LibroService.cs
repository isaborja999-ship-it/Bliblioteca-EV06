using Biblioteca_EV06.Models;

namespace Biblioteca_EV06.Services;

public class LibroService
{
    private readonly List<Libro> libros = new();

    public void AgregarLibro(Libro libro)
    {
        ArgumentNullException.ThrowIfNull(libro);
        libros.Add(libro);
    }

    public bool EliminarLibro(int id)
    {
        Libro? libro = libros.Find(item => item.Id == id);
        return libro is not null && libros.Remove(libro);
    }

    public IReadOnlyList<Libro> ObtenerTodos()
    {
        return libros.ToList();
    }

    public Libro? BuscarPorIsbn(string isbn)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(isbn);
        return libros.Find(libro => string.Equals(libro.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Libro> BuscarPorTitulo(string titulo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo);
        return libros
            .Where(libro => libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Libro> BuscarPorAutor(string autor)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(autor);
        return libros
            .Where(libro => libro.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Libro> OrdenarPorTitulo()
    {
        return libros.OrderBy(libro => libro.Titulo, StringComparer.OrdinalIgnoreCase).ToList();
    }
}
