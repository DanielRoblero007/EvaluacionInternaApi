using BancoApiRest.Models;
using BancoApiRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApiRest.Controllers;

[ApiController]
[Route("[controller]")]

public class ClienteController : ControllerBase
{
    // Inyecta los servicios necesarios para manejar clientes y bitacora
    private readonly IClienteService _clienteService;
    private readonly IBitacoraService _bitacoraService;

    // Constructor que recibe las dependencias de los servicios
    public ClienteController(IClienteService clienteService, IBitacoraService bitacoraService)
    {
        _clienteService = clienteService;
        _bitacoraService = bitacoraService;
    }
    // Endpoint para obtener un cliente por su DPI
    [HttpGet("{dpi}")]
    public IActionResult GetCliente(string dpi)
    {
        var cliente = _clienteService.ObtenerClientePorDpi(dpi);
        if (cliente == null)
        {
            _bitacoraService.Registrar($"Se ha intentado buscar el DPI del cliente sin exito.: {dpi}");
            return NotFound("Cliente no encontrado.");
        }

        _bitacoraService.Registrar($"Exito en la consulta DPI: {dpi}");
        return Ok(cliente);
    }
    // Endpoint para crear un nuevo cliente
    [HttpPost]
    public IActionResult PostCliente([FromBody] Cliente nuevoCliente)
    {
        if (nuevoCliente == null)
        {
            return BadRequest("Los datos del CLiente no pueden ser nulos.");
        }

        try
        {
            var clienteCreado = _clienteService.CrearCliente(nuevoCliente);
            _bitacoraService.Registrar($"Se creó un nuevo cliente con DPI: {clienteCreado.Cliente_DPI} y Nombre: {clienteCreado.Cliente_Nombre}");
            return CreatedAtAction(nameof(GetCliente), new { dpi = clienteCreado.Cliente_DPI }, clienteCreado);
        }
        catch (ArgumentException ex)
        {
            _bitacoraService.Registrar($"Error al crear cliente: {ex.Message}");
            return Conflict(ex.Message);
        }
    }
}