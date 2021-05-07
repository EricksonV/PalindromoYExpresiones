using Reproductor.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas_Stack_.Clases.Pilas
{
    class PilaListaDoble
    {
        private int cima;
        private ClsListaDoble listaPila;
        private Nodo nodo;

        public PilaListaDoble()
        {
            cima = -1;
            listaPila = new ClsListaDoble();
        }
        public void insertar(Object elemento)
        {
            cima++;
            listaPila.InsertarCabezaLista(elemento, cima);
            
        }
        public Object quitar()
        {
            Object aux;
            aux = null;
            if (PilaVacia()) { throw new Exception("Pila Vacia"); }
            aux = listaPila.ElementAt(cima);
            listaPila.eliminar(cima);
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

