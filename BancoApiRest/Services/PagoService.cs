{{ ... }}
    public Pago RealizarPago(Pago pago)
    {
        pago.Pago_ID = _nextId++;
        pago.Pago_Fecha = DateTime.Now;
        _pagos.Add(pago);
        return pago;
    }

    public List<Pago> ObtenerTodosLosPagos()
    {
        return _pagos;
    }
}
