using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNTAMENTO
{
    internal class Program
    {
        static List<string> nombres = new List<string>();
        static List<int> cantidades = new List<int>();
        static List<double> precios = new List<double>();

        const double TIPO_CAMBIO = 3.5;

        static void Main(string[] args)
        {
            char continuar;
            do
            {
                Console.WriteLine("=== REGISTRO DE VENTAS ===");
                Console.Write("Ingrese el nombre del producto: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese la cantidad comprada: ");
                int cantidad = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el precio unitario (S/): ");
                double precio = double.Parse(Console.ReadLine());

                nombres.Add(nombre);
                cantidades.Add(cantidad);
                precios.Add(precio);

                Console.Write("¿Desea ingresar otro producto? (s/n): ");
                continuar = char.Parse(Console.ReadLine().ToUpper());
                Console.WriteLine();

            } while (continuar == 'S');

            double total = CalcularTotal();
            double descuento = CalcularDescuento(total);
            double totalConDescuento = total - descuento;
            double totalDolares = totalConDescuento / TIPO_CAMBIO;

            string productoMasVendido = ObtenerProductoMasVendido();
            string productoMasCaro = ObtenerProductoMasCaro();

            Console.WriteLine("===== RESUMEN DE COMPRA =====");
            Console.WriteLine($"Total antes del descuento: S/ {total:F2}");
            Console.WriteLine($"Total con descuento: S/ {totalConDescuento:F2}");
            Console.WriteLine($"Total en dólares: $ {totalDolares:F2}");
            Console.WriteLine($"Producto más vendido: {productoMasVendido}");
            Console.WriteLine($"Producto más caro: {productoMasCaro}");

            Console.WriteLine("\nGracias por su compra.");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        static double CalcularTotal()
        {
            double total = 0;
            for (int i = 0; i < cantidades.Count; i++)
            {
                total += cantidades[i] * precios[i];
            }
            return total;
        }

        static double CalcularDescuento(double total)
        {
            if (total >= 500)
                return total * 0.10;
            else if (total >= 200)
                return total * 0.05;
            else
                return 0;
        }

        static string ObtenerProductoMasVendido()
        {
            int indice = 0;
            int maxCantidad = cantidades[0];
            for (int i = 1; i < cantidades.Count; i++)
            {
                if (cantidades[i] > maxCantidad)
                {
                    maxCantidad = cantidades[i];
                    indice = i;
                }
            }
            return nombres[indice];
        }

        static string ObtenerProductoMasCaro()
        {
            int indice = 0;
            double maxPrecio = precios[0];
            for (int i = 1; i < precios.Count; i++)
            {
                if (precios[i] > maxPrecio)
                {
                    maxPrecio = precios[i];
                    indice = i;
                }
            }
            return nombres[indice];
        }
    }
}

