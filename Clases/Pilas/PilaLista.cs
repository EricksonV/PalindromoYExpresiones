using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas_Stack_.Clases
{
    class PilaLista
    {
        private int cima;
        private List<Object> listaPila;

        public PilaLista()
        {
            cima = -1;
            listaPila = new List<object>();
        }
        public void insertar(Object elemento)
        {
            cima++;
            listaPila.Add(elemento);
        }
        public Object quitar()
        {
            Object aux;
            if (PilaVacia()) { throw new Exception("Pila Vacia"); }
            aux = listaPila.ElementAt(cima);
            listaPila.RemoveAt(cima);
            cima--;
            return aux;
        }
        public Object cimaPila()
        {
            if (PilaVacia()) { throw new Exception("Pila Vacia"); }
            return listaPila.ElementAt(cima);
        }
        public bool PilaVacia()
        {
            return cima == -1;
        }
        public void limpiarPila()
        {
            while (!PilaVacia())
            {
                quitar();
            }
        }
    }
}
