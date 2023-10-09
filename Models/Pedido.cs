using System.ComponentModel;
using Clientes;
using Cadetes;

namespace Pedidos
{
public class Pedido
    {
        public enum Estados {
            Pendiente = 1,
            Entregado = 2
        }
        private int numero;
        private string? observaciones;
        private Estados estado;
        private Cliente? cliente;
        private int idCadete;
        public int Numero { get => numero;}
        public int IdCadete{ get => idCadete;}

        public Pedido(int numero, string observaciones, string nombre, string direccion, string telefono, string datosRefDireccion){
            this.numero =  numero;
            this.observaciones = observaciones;
            estado = Estados.Pendiente;
            cliente = new Cliente(nombre, direccion, telefono, datosRefDireccion);
        }
        public void AsignarCadete(int idCadeteAsignado){
            this.idCadete = idCadeteAsignado;
        }
        public void verDireccionCliente(){
            Console.WriteLine("La direccion del cliente: " + cliente!.Direccion + cliente.DatosRefDireccion);
        }
        public void verDatosCliente(){
            Console.WriteLine("\nNombre: " + cliente.Nombre);
            Console.WriteLine("\nTelefono: " + cliente.Telefono);
        } 
        public void CambiarEstado(){
            estado = Estados.Entregado;
        }
        public Estados getEstado(){
            return estado;
        }
    }
}

