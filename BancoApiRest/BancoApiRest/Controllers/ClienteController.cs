using BancoApiRest.Models;
using BancoApiRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    // Este controlador maneja las operaciones relacionadas con los clientes
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
        // Validación del DPI
        try
        {
            var cliente = _clienteService.ObtenerClientePorDpi(dpi);
            if (cliente == null)
            {
                _bitacoraService.Registrar($"Se ha intentado realizar una busqueda del cliente, DPI no existe: {dpi}");
                return NotFound(new { mensaje = "Cliente no encontrado." });
            }
            // Registro de la consulta exitosa
            _bitacoraService.Registrar($"Consulta de cliente exitosa para DPI: {dpi}");
            return Ok(cliente);
        }
        // Manejo de excepciones
        catch (Exception ex)
        {
            // Registro del error en la bitácora
            _bitacoraService.Registrar($"Error al obtener cliente: {ex.Message}");
            return StatusCode(500, new { mensaje = "Ocurrió un error al obtener el cliente.", detalle = ex.Message });
        }
    }

    // Endpoint para crear un nuevo cliente
    [HttpPost]
    // Este método maneja la creación de un nuevo cliente
    public IActionResult PostCliente([FromBody] Cliente nuevoCliente)
    {
        // Validación del modelo recibido
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Validación de campos obligatorios
            var clienteCreado = _clienteService.InsertarCliente(nuevoCliente);
            // Registro de la creación exitosa en la bitácora
            _bitacoraService.Registrar($"Se creó un nuevo cliente con DPI: {clienteCreado.Cliente_DPI}");
            // Respuesta exitosa
            return Ok(new { mensaje = "Cliente creado exitosamente." });
        }
        // Manejo de excepciones
        catch (Exception ex)
        {
            // Registro del error en la bitácora
            _bitacoraService.Registrar($"Error al crear cliente: {ex.Message}");
            if (ex.Message.Contains("DPI ya se encuentra registrado"))
            {
                return Conflict(new { mensaje = ex.Message });
            }
            return StatusCode(500, new { mensaje = "Ocurrió un error al crear el cliente.", detalle = ex.Message });
        }
    }
}