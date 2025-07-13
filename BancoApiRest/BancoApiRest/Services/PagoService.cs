using BancoApiRest.Models;

namespace BancoApiRest.Services;
// Este servicio manejara las operaciones relacionadas con los pagos
public interface IPagoService
{
    Pago InsertarPago(Pago pago);
    List<Pago> ObtenerPagos();
}

public class PagoService : IPagoService
{
    // Simulación de la tabla Pago en memoria
    private static readonly List<Pago> _pagos = new List<Pago>();
    private static int id = 1;

    // Método para insertar un nuevo pago
    public Pago InsertarPago(Pago pago)
    {
        pago.Pago_ID = id++;
        pago.Pago_Fecha = DateTime.Now;
        _pagos.Add(pago);
        return pago;
    }

    // Método para obtener todos los pagos
    public List<Pago> ObtenerPagos()
    {
        return _pagos;
    }
}

