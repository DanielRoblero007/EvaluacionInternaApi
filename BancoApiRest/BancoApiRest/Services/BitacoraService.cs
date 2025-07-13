namespace BancoApiRest.Services;

// Este servicio manejara la bitacora de acciones realizadas
public interface IBitacoraService
{
    void Registrar(string accion);
    List<string> ObtenerRegistros();
}

public class BitacoraService : IBitacoraService
{
    private readonly List<string> _registros = new List<string>();
    // Método para registrar una acción en la bitácora
    public void Registrar(string accion)
    {
        string registro = $"{DateTime.Now:G}: {accion}";
        _registros.Add(registro);
        Console.WriteLine(registro);
    }
    // Método para obtener los registros de la bitácora
    public List<string> ObtenerRegistros()
    {
        return _registros;
    }
}