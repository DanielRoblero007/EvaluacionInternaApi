{{ ... }}
        _pagoService = pagoService;
        _bitacoraService = bitacoraService;
    }

    [HttpGet]
    public IActionResult GetPagos()
    {
        var pagos = _pagoService.ObtenerTodosLosPagos();
        _bitacoraService.Registrar("Se consultaron todos los pagos.");
        return Ok(pagos);
    }

    [HttpPost]
    public IActionResult PostPago([FromBody] Pago nuevoPago)
    {
{{ ... }}
