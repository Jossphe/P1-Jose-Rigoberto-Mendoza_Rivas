class Producto
{
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string codigo, string descripcion, double precio, int cantidad)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        Precio = precio;
        Cantidad = cantidad;
    }
}

