using Pilas_Stack_.Clases;
using Pilas_Stack_.Clases.Ejercicios;
using Pilas_Stack_.Clases.Pilas;
using System;
using System.Text.RegularExpressions;

namespace Pilas_Stack_
{
    class Program
    {

        static void EjemploPilaLinea()
        {
            PilaLineal pila;
            int x = 0;
            int CLAVE = -1;

            Console.WriteLine("Ingrese números y para terminar -1");
            try
            {
                pila = new PilaLineal();
                do
                {
                    if (x != -1)
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        pila.insertar(x);

                    }

                } while (x != CLAVE);

                Console.WriteLine("Estos son los elementos de la pila");

                while (!pila.PilaVacia())
                {
                    x = (int)pila.quitar();
                    Console.WriteLine($"Elemento: {x}");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("Error = " + error.Message);
            }

        }//end Ejemplo 1

        static void palindromo()
        {
            PilaLineal pilaChar;
            bool esPalindromo;
            String pal;

            try
            {
                pilaChar = new PilaLineal();
                Console.WriteLine("Teclee una palabra para ver si es palindromo ");
                pal = Console.ReadLine();

                //creamos la pila de los chars
                for(int i = 0; i<pal.Length;)
                {
                    Char c;
                    c = pal[i++];
                    pilaChar.insertar(c);
                }
                //comrpueba si es palindromo
                esPalindromo = true;
                for(int j = 0; esPalindromo && !pilaChar.PilaVacia();)
                {
                    Char c;
                    c = (char)pilaChar.quitarChar();
                    esPalindromo = (pal[j] == c); //evalua si la pos es igual
                    j++;
                }
                pilaChar.LimpiarPila();
                if (esPalindromo)
                {
                    Console.WriteLine($"la palabra {pal} es palindromo");
                }
                else
                {
                    Console.WriteLine($"la palabra {pal} no es palindromo");
                }
            }
            catch(Exception error)
            {
                Console.WriteLine($"Ups, hay un error " + error.Message);
            }
        }// end palindromo

        static void EjemploPila()
        {
            PilaLista pl = new PilaLista();
            pl.insertar(1);
            pl.insertar(5);
            pl.insertar(16);
            pl.insertar(217);
            pl.insertar(41);
            pl.insertar(19);

            var xx = pl.quitar();
            int pau;
            pau = 0;
        }

        static void Ejercicios()
        {
            int i = 0;

            do
            {

                Console.WriteLine("1. Ejercicio Palíndromo ");
                Console.WriteLine("2. Evaluar expreciones PilaLineal ");
                Console.WriteLine("3. Evaluar expresiones PilaLista ");
                Console.WriteLine("4. Evaluar Expresiones Pila Lista doblemente enlazada");
                i = int.Parse(Console.ReadLine());

                Console.WriteLine();
                if (i == 1) { new ClsEjercicios().palindromoNuevo(); }
                if(i == 2) { new ClsEjercicioArray().expresiones(); }
                if(i == 3) { new ClsEjercicioList().expresiones(); }
                if(i == 4) { new ClsEjercicios().expresiones(); }
                Console.WriteLine();
            } while (i != -1);
        }

       
        

        static void Main(string[] args)
        {
            ///Console.WriteLine("Hello World!");

            //EjemploPilaLinea();
            //palindromo();
            //EjemploPila();
            //new ClsEjercicios().palindromoNuevo();
            // new ClsEjercicios().expresiones();
            Ejercicios();
        }
    }
}
