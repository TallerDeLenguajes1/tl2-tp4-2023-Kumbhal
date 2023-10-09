using Cadetes;
using Pedidos;
using AccesoADato;

namespace Cadeterias
{
public class Cadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;
        public string? Nombre {get => nombre;}

        public Cadeteria(string nombre, string telefono){
            this.nombre = nombre;   
            this.telefono = telefono;  
            listadoCadetes = new List<Cadete>();
            listadoPedidos = new List<Pedido>();
        }
        public Cadeteria(){listadoCadetes = new List<Cadete>();listadoPedidos = new List<Pedido>();}
        private static Cadeteria cadeteriaSingleton;
        public static Cadeteria GetCadeteria()
        {
            if (cadeteriaSingleton == null)
            {
                cadeteriaSingleton = new Cadeteria();
                AccesoADatos CargarDatosCSV = new AccesoCSV();
                cadeteriaSingleton = CargarDatosCSV.CargarDatosCadeteria("Cadeteria.csv");
                cadeteriaSingleton.CargarListadoCadetes(CargarDatosCSV.CargarDatosCadete("Cadetes.csv"));
            }
            return cadeteriaSingleton;
        }
        public string? GetNombreCadeteria(){
            return nombre;
        }
        public List<Cadete> GetCadetes(){
            return listadoCadetes;
        }
        public List<Pedido> GetPedidos(){
            return listadoPedidos;
        }
        public int CantidadCadetes(){
            return listadoCadetes.Count();
        }
        private bool ListadoCadetesVacio(){
            return (CantidadCadetes() == 0);
        }
        public List<Pedido> MostrarPedidosCadete(int idCadete){
            List<Pedido> listadoPedidosCadete = listadoPedidos.FindAll(pedido => pedido.IdCadete == idCadete);
            if (listadoPedidosCadete != null){
                foreach (var pedido in listadoPedidosCadete){
                    Console.WriteLine("Id: "+pedido.Numero);
                    pedido.verDatosCliente();
                }
            }
            return listadoPedidosCadete;
        }
        public List<Cadete> CargarListadoCadetes(List<Cadete> listadoCadetesDatos){
            this.listadoCadetes = listadoCadetesDatos;
            return listadoCadetesDatos;
        }
        public Pedido CrearPedido(int numPedido, string? obsPedido, string? nombreCliente, string? direccionCliente, string? telefonoCliente, string?datosRef){
            Pedido nuevoPedido = new Pedido(numPedido, obsPedido, nombreCliente, direccionCliente, telefonoCliente, datosRef);
            return nuevoPedido;
        }
        public Pedido AddPedido(Pedido nuevoPedido){
            listadoPedidos.Add(nuevoPedido);
            return nuevoPedido;
        }
        public Pedido AsignarCadeteAPedido(int numPedido, int idCadete){
            Pedido pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == numPedido);
            if(!ListadoCadetesVacio()){
                    if (listadoPedidos != null){
                        pedidoBuscado.AsignarCadete(idCadete);
                    }else{
                        Console.WriteLine("No hay pedidos para asignar.");
                    }
            }else{
                Console.WriteLine("No hay cadetes registrados para asignar pedido. ");
            }
            return pedidoBuscado;
        }
        public bool CambiarEstadoPedido(int idPedido){
            Pedido pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == idPedido);
            if(pedidoBuscado != null){
                pedidoBuscado.CambiarEstado();
                return true;
            }
            return false;
        }
        public Cadete AgregarCadete(Cadete nuevoCadete){
            listadoCadetes?.Add(nuevoCadete);
            Console.WriteLine("Se agrego nuevo cadete");
            return nuevoCadete; 
        }
        public void listarCadetes(){
            foreach (var cadete in listadoCadetes){
                cadete.ListarInformacion();
            }
        }
        public Pedido ReasignarPedido(int idPedidBusc,int cadeteAsignado){
            Pedido pedidoBuscado;
            pedidoBuscado = listadoPedidos.Find(pedido => pedido.Numero == idPedidBusc);
            if(listadoCadetes != null){
                if (pedidoBuscado != null){
                    pedidoBuscado.AsignarCadete(cadeteAsignado);
                }else{
                    Console.WriteLine("Se produjo un error. ");
                }
            }else{
                Console.WriteLine("Se produjo un error. ");
            }
            return pedidoBuscado;
        }
        public void MostrarInforme(){
            int montoTotalJornada = 0;
            foreach (var cadete in listadoCadetes){
                cadete.ListarInformacion();
                Console.WriteLine("Jornal : "+cadete.JornalACobrar());
                Console.WriteLine("Total de pedidos enviados: " +cadete.CantidadPedidosEntregados());
                montoTotalJornada = cadete.JornalACobrar() + montoTotalJornada;
            }
            Console.WriteLine("Monto ganado: "+montoTotalJornada);
        }
        public void ListarInformacionCadeteria(){
            Console.WriteLine("\n=========="+this.nombre+"==========");
            Console.WriteLine("\nTelefono:"+this.telefono);
        }
        public void ListarPedidosPendientes(){
            foreach (var pedido in listadoPedidos){
                Console.WriteLine("\nID pedido:" + pedido.Numero);
                pedido.verDatosCliente();
            }
        }
    }      
}

    