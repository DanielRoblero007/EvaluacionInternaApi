namespace BancoApiRest.Models;

public class Cliente
{
    public int Cliente_ID { get; set; }
    public string Cliente_Nombre { get; set; }
    public string Cliente_Apellido { get; set; }
    public string Cliente_DPI { get; set; }
    public string Cliente_Direccion { get; set; }
    public string Cliente_Telefono { get; set; }
    public string Cliente_Email { get; set; }
    public DateTime Cliente_FechaNacimiento { get; set; }
    public DateTime Cliente_FechaRegistro { get; set; }
}