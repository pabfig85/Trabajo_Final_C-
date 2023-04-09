using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaquinaDispensadora.Models;

namespace MaquinaDispensadora.Controllers {
    public class Dispensadora {
        public List<Consumable> Consumables {get; set;}
        public string Pago {get; set;}

        public Dispensadora() {
            this.Consumables = new List<Consumable>();

            Consumable cocacola = new Consumable();
            cocacola.Nombre = "Coca Cola";
            cocacola.Cantidad = 20;
            cocacola.Precio = 2000;

            Consumable papas = new Consumable();
            papas.Nombre = "Margarita";
            papas.Cantidad = 20;
            papas.Precio = 1500;

            this.Consumables.Add(cocacola);
            this.Consumables.Add(papas);
        }

        // Hacer modificar

        public int validarConsumable(string nombre) {
            int encontro = -1;
            
            for(int i = 0; i < this.Consumables.Count; i++) {
                if(this.Consumables[i].Nombre == nombre) {
                    encontro = i;
                }
            }

            return encontro;
        }

        public bool agregrarConsumable(Consumable consumable) {
            int enc = this.validarConsumable(consumable.Nombre);

            if(enc >= 0) {
                this.Consumables[enc].sumarCantidad(consumable.Cantidad);
            }

            else {
                this.Consumables.Add(consumable);
            }

            return true;
        }

        public bool eliminarConsumable(string nombre) {
            int enc = this.validarConsumable(nombre);

            if(enc >= 0) {
                this.Consumables.RemoveAt(enc);
                return true;
            }

            return false;
        }

        public int validarMonedas(string[] Monedas) {
            int total = 0;

            foreach(string item in Monedas) {
                try {
                    total += int.Parse(item);
                }

                catch(Exception e) {

                }
            }

            return total;
        }

        // 500 - 200 - 100 - 50
        public Consumable vender(string nombre) {
            int enc = this.validarConsumable(nombre);

            if(enc >= 0) {
                if(this.Consumables[enc].validarCantidad()) {
                    string[] monedas = this.Pago.Split('-');

                    int total = this.validarMonedas(monedas);

                    if(this.Consumables[enc].validarPrecio(total)) {
                        this.Consumables[enc].restarConsumable();

                        return this.Consumables[enc];
                    }
                }
            }

            return null;
        }

        public string listarConsumable() {
            string lista = "";

            foreach(Consumable item in this.Consumables) {
                lista += item.Nombre + " " + item.Cantidad + " " + item.Precio + "\n";
            }

            return lista;
        }
    }
}