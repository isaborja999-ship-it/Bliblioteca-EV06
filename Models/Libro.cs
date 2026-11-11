namespace Biblioteca_EV06.Models;

public class Libro
{
    public int Id { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public int AnioPublicacion { get; set; }
    public bool Disponible { get; set; } = true;

    public Libro()
    {
    }

    public Libro(
        int id,
        string isbn,
        string titulo,
        string autor,
        string categoria,
        int anioPublicacion,
        bool disponible = true)
    {
        Id = id;
        Isbn = isbn;
        Titulo = titulo;
        Autor = autor;
        Categoria = categoria;
        AnioPublicacion = anioPublicacion;
        Disponible = disponible;
    }

    public string ResumenCorto()
    {
        return $"Libro #{Id}: {Titulo} - {Autor} ({AnioPublicacion})";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\nISBN: {Isbn}\nTítulo: {Titulo}\nAutor: {Autor}\n" +
               $"Categoría: {Categoria}\nAño de publicación: {AnioPublicacion}\n" +
               $"Disponible: {(Disponible ? "Sí" : "No")}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
