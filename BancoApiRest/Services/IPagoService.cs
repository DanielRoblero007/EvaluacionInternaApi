public interface IPagoService
{
    Pago RealizarPago(Pago pago);
    List<Pago> ObtenerTodosLosPagos();
}
