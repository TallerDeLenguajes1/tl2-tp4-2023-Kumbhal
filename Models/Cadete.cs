using Pedidos;

namespace Cadetes
{
public class Cadete 
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;
        private int cantidadPedidos;

        public int CantidadPedidos { get => cantidadPedidos; set => cantidadPedidos = value; }

        public Cadete(int id, string nombre, string direccion, string telefono){
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public int GetIdCadete(){
            return id;
        }
        public int CantidadPedidosEntregados(){
            return cantidadPedidos;
        }
        public int JornalACobrar(){
            int jornal = CantidadPedidosEntregados() * 500;
            return jornal;
        }
        public void ListarInformacion(){
            Console.WriteLine("\nID: "+id);
            Console.WriteLine("\nNombre: "+nombre);
        }
    }   
}