using Pedidos;

namespace Cadetes
{
public class Cadete 
    {
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete(int id, string nombre, string direccion, string telefono){
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
        public int GetIdCadete(){
            return Id;
        }
        public int CantidadPedidosEntregados(){
            return 0;
        }
        public int JornalACobrar(){
            int jornal = CantidadPedidosEntregados() * 500;
            return jornal;
        }
        public void ListarInformacion(){
            Console.WriteLine("\nID: "+Id);
            Console.WriteLine("\nNombre: "+Nombre);
        }
    }   
}