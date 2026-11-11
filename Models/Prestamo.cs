namespace Biblioteca_EV06.Models;

public class Prestamo
{
    public int Id { get; set; }
    public Libro Libro { get; set; } = new();
    public Usuario Usuario { get; set; } = new();
    public DateTime FechaPrestamo { get; set; } = DateTime.Today;
    public DateTime FechaVencimiento { get; set; } = DateTime.Today;
    public DateTime? FechaDevolucion { get; set; }
    public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

    public Prestamo()
    {
    }

    public Prestamo(
        int id,
        Libro libro,
        Usuario usuario,
        DateTime fechaPrestamo,
        DateTime fechaVencimiento,
        DateTime? fechaDevolucion = null,
        EstadoPrestamo estado = EstadoPrestamo.Activo)
    {
        Id = id;
        Libro = libro;
        Usuario = usuario;
        FechaPrestamo = fechaPrestamo;
        FechaVencimiento = fechaVencimiento;
        FechaDevolucion = fechaDevolucion;
        Estado = estado;
    }

    public bool EstaVencido()
    {
        return FechaDevolucion is null &&
               Estado != EstadoPrestamo.Devuelto &&
               FechaVencimiento.Date < DateTime.Today;
    }

    public int DiasTranscurridos()
    {
        DateTime fechaFinal = FechaDevolucion ?? DateTime.Today;
        return Math.Max(0, (fechaFinal.Date - FechaPrestamo.Date).Days);
    }

    public string ResumenCorto()
    {
        return $"Préstamo #{Id}: {Libro.Titulo} para {Usuario.Nombre} - {Estado}";
    }

    public string DetalleCompleto()
    {
        string fechaDevolucion = FechaDevolucion?.ToString("dd/MM/yyyy") ?? "Pendiente";
        return $"ID: {Id}\nLibro: {Libro.Titulo}\nUsuario: {Usuario.Nombre}\n" +
               $"Fecha de préstamo: {FechaPrestamo:dd/MM/yyyy}\n" +
               $"Fecha de vencimiento: {FechaVencimiento:dd/MM/yyyy}\n" +
               $"Fecha de devolución: {fechaDevolucion}\nEstado: {Estado}\n" +
               $"Vencido: {(EstaVencido() ? "Sí" : "No")}\n" +
               $"Días transcurridos: {DiasTranscurridos()}";
    }

    public override string ToString()
    {
        return ResumenCorto();
    }
}
