using BancoApiRest.Models;

namespace BancoApiRest.Services;

// Este servicio manejara las operaciones relacionadas con los clientes
public interface IClienteService
{
    Cliente CrearCliente(Cliente cliente);
    Cliente ObtenerClientePorDpi(string dpi);
}

public class ClienteService : IClienteService
{
    // Simalara la tabla de clientes en listas
    private static readonly List<Cliente> _clientes = new List<Cliente>();
    private static int _nextId = 1;

    public Cliente CrearCliente(Cliente cliente)
    {
        // Validara si el DPI existe.
        if (_clientes.Any(c => c.Cliente_DPI == cliente.Cliente_DPI))
        {
            throw new ArgumentException("El DPI ya se encuentra registrado.");
        }
        // Asignara un ID unico al cliente y la fecha de registro
        cliente.Cliente_ID = _nextId++;
        cliente.Cliente_FechaRegistro = DateTime.Now;
        _clientes.Add(cliente);
        return cliente;
    }

    // Obtendra un cliente por su DPI
    public Cliente ObtenerClientePorDpi(string dpi)
    {
        return _clientes.FirstOrDefault(c => c.Cliente_DPI == dpi);
    }
}