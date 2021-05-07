using Pilas_Stack_.Clases.Pilas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pilas_Stack_.Clases.Ejercicios
{
    class ClsEjercicios
    {
        /// EJERCICIOS
        /// EJERCICIO 1 PALINDROMO VALIDO, SIN TILDES NI ESPACIOS
        public void palindromoNuevo()
        {
            PilaListaDoble pilaChar;
            bool esPalindromo;
            string palabra;

            try
            {
                pilaChar = new PilaListaDoble();
                Console.WriteLine("Teclee una palabra para ver si es palindromo ");
                palabra = Console.ReadLine();

                //Eliminamos los acentos
                string acentos = Regex.Replace(palabra.Normalize(System.Text.NormalizationForm.FormD),
                    @"[^a-zA-Z]", "");
                //Eliminar las mayusculas
                string pal = acentos.ToLower();

                //creamos la pila de los chars
                for (int i = 0; i < pal.Length;)
                {
                    Char c;
                    c = pal[i++];
                    pilaChar.insertar(c);
                }
                //comrpueba si es palindromo
                esPalindromo = true;
                for (int j = 0; esPalindromo && !pilaChar.PilaVacia(); j++)
                {
                    Char c;
                    c = (char)pilaChar.quitar();
                    esPalindromo = pal[j] == c; //evalua si la pos es igual
                }
                pilaChar.limpiarPila();
                if (esPalindromo)
                {
                    Console.WriteLine($"la palabra {palabra} es palindromo");
                }
                else
                {
                    Console.WriteLine($"la palabra {palabra} no es palindromo");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Ups, hay un error " + error.Message);
            }
        }// end palindromo

       
        /// Ejercicio 2 Expresiones matemáticas
        public void expresiones()
        {
            
            Console.Write("Ingrese la expresión a evaluar: ");
            string expresion = Console.ReadLine();

            
            string mensaje = comprobación(expresion);
            if (mensaje.Equals("Correcto"))
            {
                string posfija = convertidor(expresion);

                PilaListaDoble pilalist = new PilaListaDoble();

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
            PilaListaDoble pila = new PilaListaDoble();

            for(int i = 0; i<infija.Length; i++)
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
                        if(letra != ')')
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
            if(operador == '^') { return 4; }
            if (operador == '/' || operador == '*') { return 2; }
            if (operador == '+' || operador == '-') { return 1; }
            if (operador == '(') { return 5; }
            return 0;
        }
        private int prioridadPila(object operador)
        {
            if (operador.Equals('^')) { return 3; }
            if (operador.Equals('/') || operador.Equals('*')) { return 2; }
            if (operador.Equals( '+') || operador.Equals('-')) { return 1; }
            if (operador.Equals('(')) { return 0; }
            return 0;
        }
        private double operar(char letra, double num1, double num2)
        {
            if(letra == '*') { return num1 * num2; }
            if(letra == '/') { return num1 / num2; }
            if (letra == '-') { return num1 - num2; }
            if (letra == '+') { return num1 + num2; }
            if (letra == '^') { return Math.Pow(num1,num2); }
            return 0;

        }
        private string comprobación(string dato)
        {

            int num = dato.Length;
            return (operador(dato[num-1])) ? "Error en la sintaxis" : "Correcto"; 
        }

    }
}
