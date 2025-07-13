using BancoApiRest.Models;
using BancoApiRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApiRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagoController : ControllerBase
{
    // Este controlador maneja las operaciones relacionadas con los pagos
    private readonly IPagoService _pagoService;
    private readonly IBitacoraService _bitacoraService;

    // Constructor que recibe las dependencias de los servicios
    public PagoController(IPagoService pagoService, IBitacoraService bitacoraService)
    {
        _pagoService = pagoService;
        _bitacoraService = bitacoraService;
    }

    // Endpoint para obtener todos los pagos
    [HttpGet]
    public IActionResult GetPagos()
    {
        try
        {
            var pagos = _pagoService.ObtenerPagos();
            _bitacoraService.Registrar("Consulta de todos los pagos realizada.");
            return Ok(pagos);
        }
        catch (Exception ex)
        {
            _bitacoraService.Registrar($"Error al obtener pagos: {ex.Message}");// Registro del error en la bitácora
            return StatusCode(500, new { mensaje = "Ocurrió un error al obtener los pagos.", detalle = ex.Message });
        }
    }

    // Endpoint para crear un nuevo pago
    [HttpPost]
    public IActionResult PostPago([FromBody] Pago nuevoPago)
    {
        // Validación del modelo recibido
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Validación de campos obligatorios
            var pagoRealizado = _pagoService.InsertarPago(nuevoPago);
            _bitacoraService.Registrar($"Se creó un nuevo pago por el monto de {pagoRealizado.Pago_Monto}");

            return Ok(new { mensaje = "Pago realizado exitosamente." });
        }
        // Manejo de excepciones
        catch (Exception ex)
        {
            _bitacoraService.Registrar($"Error al procesar pago: {ex.Message}");// Registro del error en la bitácora
            return StatusCode(500, new { mensaje = "Ocurrió un error al procesar el pago.", detalle = ex.Message });
        }
    }
}