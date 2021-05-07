using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reproductor.clases
{
    class Nodo
    {
        private object dato;
        private int pos;
        public Nodo adelante;
        public Nodo atras;

        public Nodo(object dato, int posi) {
            this.dato = dato;
            this.pos = posi;
            adelante = atras = null;
        }

        public object Dato { get => dato;  }
        public int Pos { get => pos; }
    }
}
