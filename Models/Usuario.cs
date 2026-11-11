namespace Biblioteca_EV06.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Documento { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string Contacto { get; set; } = string.Empty;
    public bool Activo { get; set; } = true;

    public Usuario()
    {
    }

    public Usuario(int id, string documento, string nombre, string contacto, bool activo = true)
    {
        Id = id;
        Documento = documento;
        Nombre = nombre;
        Contacto = contacto;
        Activo = activo;
    }

    public string ResumenCorto()
    {
        return $"Usuario #{Id}: {Nombre} ({Documento})";
    }

    public string DetalleCompleto()
    {
        return $"ID: {Id}\nDocumento: {Documento}\nNombre: {Nombre}\n" +
               $"Contacto: {Contacto}\nActivo: {(Activo ? "Sí" : "No")}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
