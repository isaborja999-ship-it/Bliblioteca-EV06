using Biblioteca_EV06.Models;

namespace Biblioteca_EV06.Services;

public class UsuarioService
{
    private readonly List<Usuario> usuarios = new();

    public void AgregarUsuario(Usuario usuario)
    {
        ArgumentNullException.ThrowIfNull(usuario);
        usuarios.Add(usuario);
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? usuario = usuarios.Find(item => item.Id == id);
        return usuario is not null && usuarios.Remove(usuario);
    }

    public IReadOnlyList<Usuario> ObtenerTodos()
    {
        return usuarios.ToList();
    }

    public Usuario? BuscarPorDocumento(string documento)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(documento);
        return usuarios.Find(usuario =>
            string.Equals(usuario.Documento, documento, StringComparison.OrdinalIgnoreCase));
    }

    public IReadOnlyList<Usuario> BuscarPorNombre(string nombre)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(nombre);
        return usuarios
            .Where(usuario => usuario.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<Usuario> OrdenarPorNombre()
    {
        return usuarios.OrderBy(usuario => usuario.Nombre, StringComparer.OrdinalIgnoreCase).ToList();
    }

    public int TotalUsuarios()
    {
        return usuarios.Count;
    }

    public int TotalUsuariosActivos()
    {
        return usuarios.Count(usuario => usuario.Activo);
    }

    public int TotalUsuariosInactivos()
    {
        return usuarios.Count(usuario => !usuario.Activo);
    }
}
