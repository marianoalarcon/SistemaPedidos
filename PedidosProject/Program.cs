using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Ordenes> ListaOrdenes = CargarOrden();
                foreach (Ordenes orden in ListaOrdenes)
                {
                    orden.guardarArchivo();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }            
                                 
            Console.ReadKey();

        }

        public static List<Detalles> CargaListaDetalles()
        {
            int opcion = 0;

            int idDetalles;
            idDetalles = 1;

            List<Detalles> ListaDetalles = new List<Detalles>();
            do
            {
                Console.WriteLine("Seleccione un producto desea comprar de acuerdo a la Id correspondiente\n");
                Productos producto = new Productos();
                producto.Mostrar();
                List<Productos> ListaProductos = producto.LecturaArchivoCargaEnLista();


                int productId;
                productId = int.Parse(Console.ReadLine());
                Console.WriteLine("Indique la cantidad de productos que desea comprar");
                int quantity;
                quantity = int.Parse(Console.ReadLine());


                int idOrden;
                idOrden = 1;

                string productName = ListaProductos.Find(product => product.Id == productId).ProductName;

                Detalles detalle = new Detalles(idDetalles, idOrden, productId, quantity, ListaProductos, productName);

                detalle.SubTotal(0);

                ListaDetalles.Add(detalle);

                

                Console.WriteLine("Precione (1) para continuar comprando o (0) para terminar ");
                opcion = int.Parse(Console.ReadLine());

                idDetalles++;
            } while (opcion != 0);

            return ListaDetalles;
        }
        public static void MostrarListaDetalles(List<Detalles> ListaDetalles)
        {
            foreach (Detalles det in ListaDetalles)
            {
                Console.WriteLine("IdDetalle: {0}  Detalle {1}\tCantidad: {2}  SubTotal: {3}\n", det.Id,
                   det.Description, det.Quantity, det.SubTotal());
            }
        }
        public static List<Ordenes> CargarOrden()
        {
            List<Ordenes> ListaOrdenes = new List<Ordenes>();
            int finalizarPedidos = 0;
            int idOrden=1;
            do
            {
                List<Detalles> ListaDetalles = new List<Detalles>();
                ListaDetalles = CargaListaDetalles();

                DateTime localDate = DateTime.Now;
                Console.WriteLine("Ingrese el nombre del Cliente");
                string customerName;
                customerName = Console.ReadLine();
                Ordenes orden = new Ordenes(idOrden, customerName, localDate, "Descripcion", ListaDetalles);

                MostrarOrden(orden);
                MostrarListaDetalles(ListaDetalles);

                orden.Total(0);
                ListaOrdenes.Add(orden);

                Console.WriteLine("El MONTO TOTAL ES $: {0} \n", orden.Total());
                Console.WriteLine("\n**** TICKET **** TICKET ******  TICKET ****** TICKET********* ******  TICKET ******\n");

                Console.WriteLine("Si desea continuar agregando ordenes precione 1 \n De lo contrario 0 para finalizar");
                finalizarPedidos = int.Parse(Console.ReadLine());
                idOrden++;
            } while (finalizarPedidos != 0);

            return ListaOrdenes;
        }

        public static void MostrarOrden(Ordenes orden)
        {
            Console.WriteLine("\n**** TICKET **** TICKET ******  TICKET ****** TICKET********* ******  TICKET ******\n");
            Console.WriteLine("Id Orden: {0}\tFecha: {1}\t Nombre Cliente: {2}",orden.Id,orden.Date,orden.CustomerName);
        }


    }
}

