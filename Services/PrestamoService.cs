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
}
