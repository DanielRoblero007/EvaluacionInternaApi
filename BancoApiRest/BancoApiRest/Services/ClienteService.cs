using BancoApiRest.Models;

namespace BancoApiRest.Services;

// Este servicio manejara las operaciones relacionadas con los clientes
public interface IClienteService
{
    Cliente InsertarCliente(Cliente cliente);
    Cliente ObtenerClientePorDpi(string dpi);
}

public class ClienteService : IClienteService
{
    // Simulación de la tabla Cliente en memoria
    private static readonly List<Cliente> _clientes = new List<Cliente>();
    private static int id = 1;

    // Método para insertar un nuevo cliente
    public Cliente InsertarCliente(Cliente cliente)
    {
        if (_clientes.Any(c => c.Cliente_DPI == cliente.Cliente_DPI))
        {

            throw new Exception("El DPI ya se encuentra registrado.");
        }

        cliente.Cliente_ID = id++;
        cliente.Cliente_FechaRegistro = DateTime.Now;
        _clientes.Add(cliente);
        return cliente;
    }

    // Método para obtener un cliente por su DPI
    public Cliente ObtenerClientePorDpi(string dpi)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Cliente_DPI == dpi);
        return cliente; 
    }
}