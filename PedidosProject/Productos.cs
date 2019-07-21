using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosProject
{
    class Productos
    {
        // Atributos privados por defecto.
        int id;
        string productName;
        double price;

        // Getters and Setters.
        public int Id { get => id; set => id = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }



        public List<Productos> LecturaArchivoCargaEnLista()
        {
            List<Productos> ListaProductos = new List<Productos>();
            //LECTURA ARCHIVO Y CARGA EN LISTA
            string path = @"C:\Users\Mariano\Desktop\SistemaPedidos\Productos.csv";
            try
            {
                string[] informarcionJunta;
                string[] informacionSeparada;

                informarcionJunta = File.ReadAllLines(path);

                for (int i = 0; i < informarcionJunta.Count(); i++)
                {
                    informacionSeparada = informarcionJunta[i].Split(';');
                    Productos producto = ProductosProcesarArreglo(informacionSeparada);
                    ListaProductos.Add(producto);
                }
                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

            return ListaProductos;
        }

        public Productos ProductosProcesarArreglo(string[] informacionSeparada)

        {
            Productos productoArreglo = new Productos();
            // ID.
            productoArreglo.Id = int.Parse(informacionSeparada[0]);
            // Nombre producto.
            productoArreglo.ProductName = informacionSeparada[1];
            // Precio Producto.
            productoArreglo.Price = double.Parse(informacionSeparada[2]);

            return productoArreglo;
        }
        public void Mostrar()
        {
            List<Productos> ListaProductos = LecturaArchivoCargaEnLista();
            foreach (Productos producto in ListaProductos)
            {
                Console.WriteLine("Id Producto: {0}\tNombre Producto: {1}\tPrecio: {2}", producto.Id, producto.ProductName, producto.Price);
            }
        }



    }
}
