namespace BancoApiRest.Models;

public class Pago
{
    public int Pago_ID { get; set; }
    public int Cuenta_ID_Origen { get; set; }
    public string Pago_CuentaDestino { get; set; }
    public decimal Pago_Monto { get; set; }
    public DateTime Pago_Fecha { get; set; }
    public string Pago_Concepto { get; set; }
}