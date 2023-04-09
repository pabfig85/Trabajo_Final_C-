using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaDispensadora.Models;
using MaquinaDispensadora.Controllers;

namespace MaquinaDispensadora {
    class Programa {
        static void Main(string[] args) {
            Dispensadora dispensadora = new Dispensadora();

            while(true) {
                Console.WriteLine("Bienvenidos a la maquina dispensadora de Andres");

                Console.WriteLine(dispensadora.listarConsumable());

                Console.WriteLine("Escribo que usuario eres: proveedor o cliente");

                string usuario = Console.ReadLine();

                if(usuario == "proveedor") {
                    Console.WriteLine("1. Agregar producto");
                    Console.WriteLine("2. Eliminar producto");
                    Console.WriteLine("3. Comprar producto");
                }

                else {
                    Console.WriteLine("3. Comprar producto");
                }

                string opcion = Console.ReadLine();

                switch(opcion) {
                    case "1":
                        Consumable consumable = new Consumable();

                        Console.Write("Nombre ");
                        consumable.Nombre = Console.ReadLine();

                        Console.Write("Cantidad ");
                        consumable.Cantidad = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Precio ");
                        consumable.Precio = Convert.ToInt32(Console.ReadLine());

                        dispensadora.agregrarConsumable(consumable);

                        break;

                    case "2":
                        Console.Write("Nombre ");
                        string nombre = Console.ReadLine();

                        dispensadora.eliminarConsumable(nombre);

                        break;

                    case "3":
                        Console.Write("Nombre ");
                        string nombre_venta = Console.ReadLine();

                        Console.Write("Monedas solo de (500-200-100-50) ");
                        dispensadora.Pago = Console.ReadLine();

                        Consumable c_comprado = dispensadora.vender(nombre_venta);

                        if (c_comprado == null) {
                            Console.WriteLine("No se puedo sacar el prodcuto");
                        }

                        else {
                            Console.WriteLine("Su producto es {0} y la devuelta es {1}", c_comprado.Nombre, c_comprado.Devuelta);
                        }

                        break;
                }
                Console.WriteLine("Desea continuar si/no");

                if(Console.ReadLine() == "no") {
                    break;
                }
            }
        }
    }
}