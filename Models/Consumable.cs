using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaDispensadora.Models {
    public class Consumable {
        public string Nombre {get; set;}
        public int Cantidad {get; set;}
        public int Precio {get; set;}
        public int Devuelta {get; set;}

        public void sumarCantidad(int cantidad) {
            this.Cantidad += cantidad;
        }

        public bool validarCantidad() {
            if(this.Cantidad > 0){
                return true;
            }

            return false;
        }

        public bool validarPrecio(int valor) {
            if(this.Precio <= valor) {
                this.Devuelta = valor - this.Precio;

                return true;
            }

            return false;
        }

        public void restarConsumable() {
            this.Cantidad--;
        }
    }
}