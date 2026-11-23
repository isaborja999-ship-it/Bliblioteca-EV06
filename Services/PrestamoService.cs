using Biblioteca_EV06.Models;

namespace Biblioteca_EV06.Services;

public class PrestamoService
{
    private readonly List<Prestamo> prestamos = new();

    public void AgregarPrestamo(Prestamo prestamo)
    {
        ArgumentNullException.ThrowIfNull(prestamo);
        prestamos.Add(prestamo);
    }

    public bool EliminarPrestamo(int id)
    {
        Prestamo? prestamo = prestamos.Find(item => item.Id == id);
        return prestamo is not null && prestamos.Remove(prestamo);
    }

    public IReadOnlyList<Prestamo> ObtenerTodos()
    {
        return prestamos.ToList();
    }

    public Prestamo? BuscarPorId(int id)
    {
        return prestamos.Find(prestamo => prestamo.Id == id);
    }

    public IReadOnlyList<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
    {
        return prestamos.Where(prestamo => prestamo.Estado == estado).ToList();
    }

    public IReadOnlyList<Prestamo> OrdenarPorFechaVencimiento()
    {
        return prestamos.OrderBy(prestamo => prestamo.FechaVencimiento).ToList();
    }

    public int TotalPrestamos()
    {
        return prestamos.Count;
    }

    public int TotalPrestamosActivos()
    {
        return prestamos.Count(prestamo =>
            prestamo.Estado == EstadoPrestamo.Activo &&
            prestamo.FechaDevolucion is null &&
            !prestamo.EstaVencido());
    }

    public int TotalPrestamosVencidos()
    {
        return prestamos.Count(prestamo =>
            prestamo.FechaDevolucion is null &&
            (prestamo.Estado == EstadoPrestamo.Vencido ||
             (prestamo.Estado == EstadoPrestamo.Activo && prestamo.EstaVencido())));
    }

    public int TotalPrestamosDevueltos()
    {
        return prestamos.Count(prestamo =>
            prestamo.Estado == EstadoPrestamo.Devuelto ||
            prestamo.FechaDevolucion is not null);
    }

    public double PromedioDiasPrestamo()
    {
        return prestamos.Count == 0
            ? 0
            : prestamos.Average(prestamo => prestamo.DiasTranscurridos());
    }
}
