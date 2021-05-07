using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas_Stack_.Clases
{
    class PilaLineal
    {
        private static int TAMPILA = 49;
        private int cima;
        private Object[] listaPila;

        public PilaLineal()
        {
            cima = -1; // condición de pila Vacía.
            listaPila = new Object[TAMPILA];
        }
        //Operaciones que modifican la pila
        public bool pilaLLena()
        {
            return cima == TAMPILA - 1;
        }
        public void insertar(Object elemento)
        {
            if (pilaLLena())
            {
                throw new Exception("Desbordamiento de pila Stack Overflow");
            }
            //incrementar puntero cima y vamos a insertar el elemento
            cima++;
            listaPila[cima] = elemento;
        }//end insertar

        public bool PilaVacia()
        {
            return cima == -1;
        }
        
        //retorna un tipo char
        public Object quitarChar()
        {
            char aux;
            if (PilaVacia())
            {
                throw new Exception("Pila vacia, no hay data");
            }
            aux = (char)listaPila[cima];
            cima--;
            return aux;
        }

        //extraer elemento de la pila (pop)
        public Object quitar()
        {
            int aux;
            if (PilaVacia())
            {
                throw new Exception("La pila está vacía, no se puede sacar");
            }
            // guardar el elemnto en la cima
            aux = (int)listaPila[cima];
            // decrementar el valor de cima y retornar elemento
            cima--;
            return aux;
        }//end quitar

        public void LimpiarPila()
        {
            cima = -1;
        } // end limpiarPila

        // operación de acceso a la pila

        public Object cimaPila()
        {
            if (PilaVacia()) { 
                throw new Exception("Pila Vacia"); 
            }
            return listaPila[cima];
        }

    }
}
