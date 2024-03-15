using System;
using System.Collections.Generic;

namespace VentaProductos
{

    class Program
    {
        static List<Producto> listaProductos = new List<Producto>();

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                MostrarMenu();
                while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción válida.");
                    MostrarMenu();
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarProducto();
                        break;
                    case 2:
                        VenderProducto();
                        break;
                    case 3:
                        ListarProductos();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                }

            } while (opcion != 4);
        }

        static void MostrarMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("############################################################");
            Console.WriteLine("     |-------UNIVERSIDAD DOCTOR ANDRES BELLO-------|");
            Console.WriteLine("     |-----FACULTAD DE TECNOLOGIA E IMNOVACION-----|");
            Console.WriteLine("     |--------PROGRAMACION lll, parcial 1----------|");
            Console.WriteLine("     |---------JOSE RIGOBERTO MENDOZA RIVAS--------|");
            Console.WriteLine("############################################################");
            Console.WriteLine(" ");
            Console.WriteLine("MENU DE OPCIONES");
            Console.WriteLine("1. REGISTRAR PRODUCTO");
            Console.WriteLine("2. VENDER PRODUCTO");
            Console.WriteLine("3. LISTAR LOS PRODUCTOS");
            Console.WriteLine("4. SALIR");
            Console.Write("Seleccione una opción: ");
            Console.WriteLine(" ");
        }

        static void RegistrarProducto()
        {
            Console.WriteLine("REGISTRAR PRODUCTO");
            Console.Write("Ingrese el código de producto: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese la descripción del producto: ");
            string descripcion = Console.ReadLine();

            double precio;
            do
            {
                Console.Write("Ingrese el precio del producto: ");
            } while (!double.TryParse(Console.ReadLine(), out precio) || precio < 0);

            int cantidad;
            do
            {
                Console.Write("Ingrese la cantidad del producto: ");
            } while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 0);

            listaProductos.Add(new Producto(codigo, descripcion, precio, cantidad));
            Console.WriteLine("Producto registrado satisfactoriamente");
        }

        static void VenderProducto()
        {
            Console.WriteLine("VENDER PRODUCTO");
            Console.Write("Ingrese el código del producto: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese la cantidad a vender: ");
            int cantidadVender;
            while (!int.TryParse(Console.ReadLine(), out cantidadVender) || cantidadVender <= 0)
            {
                Console.WriteLine("Cantidad inválida. Por favor, ingrese una cantidad válida.");
                Console.Write("Ingrese la cantidad a vender: ");
            }

            Producto producto = listaProductos.Find(prod => prod.Codigo == codigo);
            if (producto == null)
            {
                Console.WriteLine("No se encontró el producto solicitado.");
                return;
            }

            if (producto.Cantidad == 0)
            {
                Console.WriteLine("No hay existencias de este producto.");
                return;
            }

            if (cantidadVender > producto.Cantidad)
            {
                Console.WriteLine("No hay suficientes existencias de este producto.");
                return;
            }

            producto.Cantidad -= cantidadVender;
            Console.WriteLine("Venta realizada satisfactoriamente.");
        }

        static void ListarProductos()
        {
            Console.WriteLine("LISTAR LOS PRODUCTOS");
            Console.WriteLine("Codigo | Descripcion | Precio | Cantidad");
            foreach (var producto in listaProductos)
            {
                Console.WriteLine($"{producto.Codigo} | {producto.Descripcion} | {producto.Precio.ToString("0.00")} | {producto.Cantidad}");
            }
        }
    }
}

