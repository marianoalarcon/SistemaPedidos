using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosProject
{
    class Ordenes
    {
        // Atributos.
        int id;
        string customerName;
        DateTime date;
        string description;
        List<Detalles> listaDetalles;
        double total;
        //Consutructor
        public Ordenes(int id, string customerName, DateTime date, string description, List<Detalles> listaDetalles)
        {
            this.id = id;
            this.customerName = customerName;
            this.date = date;
            this.description = description;
            this.listaDetalles = listaDetalles;
        }

        // Getters and Setters.
        public int Id { get => id; set => id = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Description { get => description; set => description = value; }

        // Metodo total.
        public void Total(double total)
        {
            foreach (Detalles detalle in listaDetalles)
            {
                total = total + detalle.SubTotal();
            }
            this.total = total;
        }
        public double Total()
        {
            return this.total;
        }

        public void guardarArchivo()
        {
            try
            {
                string path = @"C:\Users\Mariano\Desktop\SistemaPedidos\OrdenesDelDia.csv";
                using (StreamWriter archivo = new StreamWriter(path, append: true))
                {
                    archivo.Write(this.Id + ";");
                    archivo.Write(this.CustomerName + ";");
                    archivo.Write(this.Total() + ";\n");
                    archivo.Close();
                }

            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }

        }

    }
}
