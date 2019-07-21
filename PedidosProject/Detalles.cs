using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosProject
{
    class Detalles
    {
        // Atributos.
        int id;
        int ordenId;
        int productoId;
        int quantity;
        string description;
        List<Productos> listaProductos;
        double subTotal;

        public Detalles(int id, int ordenId, int productoId, int quantity, List<Productos> listaProductos, string description)
        {
            this.id = id;
            this.ordenId = ordenId;
            this.productoId = productoId;
            this.quantity = quantity;
            this.listaProductos = listaProductos;
            this.description = description;
        }

        // Getters and Setters.
        public int Id { get => id; set => id = value; }
        public int OrdenId { get => ordenId; set => ordenId = value; }
        public int ProductoId { get => productoId; set => productoId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Description { get => description; set => description = value; }

        //public double SubTotal { get => this.subTotal(); }

        //public List<Productos> ListaProductos { get => listaProductos; set => listaProductos = value; }



        // Metodo subTotal.

        public void SubTotal(double subTotal)
        {
            double price;
            //double subTotal;
            price = (double) listaProductos.Find(product => product.Id == ProductoId).Price;
            subTotal = price * Quantity;
            //Console.WriteLine(subTotal);
            this.subTotal = subTotal;
        }
        public double SubTotal()
        {
            return this.subTotal;
        }


    }
}
