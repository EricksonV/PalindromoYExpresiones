using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilas_Stack_.Clases.Ejercicios
{
    class ClsEjercicioList
    {
        public void expresiones()
        {

            Console.Write("Ingrese la expresión a evaluar: ");
            string expresion = Console.ReadLine();


            string mensaje = comprobación(expresion);
            if (mensaje.Equals("Correcto"))
            {
                string posfija = convertidor(expresion);

                PilaLista pilalist = new PilaLista();

                for (int i = 0; i < posfija.Length; i++)
                {
                    char letra = posfija[i];
                    if (!operador(letra))
                    {
                        double num = double.Parse(letra + "");
                        pilalist.insertar(num);
                    }
                    else
                    {
                        double num2 = (double)pilalist.quitar();
                        double num1 = (double)pilalist.quitar();
                        double result = operar(letra, num1, num2);
                        pilalist.insertar(result);
                    }
                }
                Console.WriteLine($"El resultado es: {pilalist.cimaPila()}");
            }
            else
            {
                Console.WriteLine(comprobación(expresion));
            }



        }

        private string convertidor(string infija)
        {
            string devuelta = "";
            PilaLista pila = new PilaLista();

            for (int i = 0; i < infija.Length; i++)
            {
                char letra = infija[i];
                if (operador(letra))
                {
                    if (pila.PilaVacia())
                    {
                        pila.insertar(letra);
                    }
                    else
                    {
                        if (letra != ')')
                        {
                            if (prioridadExpre(letra) > prioridadPila(pila.cimaPila()))
                            {
                                pila.insertar(letra);

                            }
                            else
                            {
                                devuelta += pila.quitar();
                                pila.insertar(letra);
                            }
                        }
                        else
                        {
                            devuelta += pila.quitar();
                            pila.quitar();
                        }
                    }
                }
                else
                {
                    devuelta += letra;
                }
            }
            while (!pila.PilaVacia())
            {
                devuelta += pila.quitar();
            }
            return devuelta;
        }
        private bool operador(char a) //confirma operadores
        {
            return a.Equals('^') || a.Equals('*') || a.Equals('/') || a.Equals('-') || a.Equals('+') || a.Equals('(') || a.Equals(')');
        }
        private int prioridadExpre(char operador)
        {
            if (operador == '^') { return 4; }
            if (operador == '/' || operador == '*') { return 2; }
            if (operador == '+' || operador == '-') { return 1; }
            if (operador == '(') { return 5; }
            return 0;
        }
        private int prioridadPila(object operador)
        {
            if (operador.Equals('^')) { return 3; }
            if (operador.Equals('/') || operador.Equals('*')) { return 2; }
            if (operador.Equals('+') || operador.Equals('-')) { return 1; }
            if (operador.Equals('(')) { return 0; }
            return 0;
        }
        private double operar(char letra, double num1, double num2)
        {
            if (letra == '*') { return num1 * num2; }
            if (letra == '/') { return num1 / num2; }
            if (letra == '-') { return num1 - num2; }
            if (letra == '+') { return num1 + num2; }
            if (letra == '^') { return Math.Pow(num1, num2); }
            return 0;

        }
        private string comprobación(string dato)
        {

            int num = dato.Length;
            return (operador(dato[num - 1])) ? "Error en la sintaxis" : "Correcto";
        }

    }
}

