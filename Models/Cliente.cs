namespace Clientes
{    
public class Cliente {
    private string? nombre;
    private string?  direccion;

    private string? telefono;
    private string? datosRefDireccion;


    public Cliente(string nombre, string direccion, string telefono, string datosRefDireccion){
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.DatosRefDireccion = datosRefDireccion; 
    }

        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public string? DatosRefDireccion { get => datosRefDireccion; set => datosRefDireccion = value; }
    }
}