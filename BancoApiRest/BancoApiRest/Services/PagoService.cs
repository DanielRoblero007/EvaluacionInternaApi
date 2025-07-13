using BancoApiRest.Models;

namespace BancoApiRest.Services;
// Este servicio manejara las operaciones relacionadas con los pagos
public interface IPagoService
{
    Pago RealizarPago(Pago pago);
}

public class PagoService : IPagoService
{
    // Simulación de la tabla Pago en memoria
    private static readonly List<Pago> _pagos = new List<Pago>();
    private static int _nextId = 1;

    // Método para realizar un pago
    public Pago RealizarPago(Pago pago)
    {
        pago.Pago_ID = _nextId++;
        pago.Pago_Fecha = DateTime.Now;
        _pagos.Add(pago);
        return pago;
    }
}