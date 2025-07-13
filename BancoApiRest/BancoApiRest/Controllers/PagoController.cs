using BancoApiRest.Models;
using BancoApiRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace BancoApiRest.Controllers;

[ApiController]
[Route("[controller]")]
// Este controlador maneja las operaciones relacionadas con los pagos
public class PagoController : ControllerBase
{
    private readonly IPagoService _pagoService;
    private readonly IBitacoraService _bitacoraService;

    // Constructor que recibe las dependencias de los servicios
    public PagoController(IPagoService pagoService, IBitacoraService bitacoraService)
    {
        _pagoService = pagoService;
        _bitacoraService = bitacoraService;
    }

    // Endpoint para realizar un pago
    [HttpPost]
    public IActionResult PostPago([FromBody] Pago nuevoPago)
    {
        if (nuevoPago == null)
        {
            return BadRequest("Datos del pago no pueden ser nulos.");
        }

        var pagoRealizado = _pagoService.RealizarPago(nuevoPago);
        _bitacoraService.Registrar($"Se ha creado el pago, monto de: {pagoRealizado.Pago_Monto} Cuenta origen: {pagoRealizado.Cuenta_ID_Origen} Cuenta Destino; {pagoRealizado.Pago_CuentaDestino}");

        return Ok(pagoRealizado);
    }
}