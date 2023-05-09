using System;

namespace Evidencia1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Jorge Eduardo Sosa Rodriguez AL02954769
            //Jesus Arturo Martinez Navarro AL02964388

            //Declaramos las variables que usaremos. 
            int numero, Columna, Fila, ContarPasos;
            //Pedimos las columnas y filas que tendra la matriz
            do
            {
                Console.WriteLine("Introduzca las columnas y filas que tendra la matriz");
                Console.WriteLine("Columnas: ");
                Columna = int.Parse(Console.ReadLine());
                Console.WriteLine("Filas: ");
                Fila = int.Parse(Console.ReadLine());
                //Si la matriz aumenta las 16 posiciones, se le menciona al usuario y volvemos a pedir los valores de fila y columna.
                if (Fila * Columna >= 16)
                    Console.WriteLine("No se permite una matriz con 16 elementos o mas");
            } while (Fila * Columna >= 16);

            //Creamos la matriz con los valores dados por el usuario anteriormente. 
            int[,] matriz = new int[Fila, Columna];

            //Pedimos los valores que tendra la matriz
            Console.WriteLine("Introduzca los valores que tendra la matriz");
            Console.WriteLine("los valores deben de estar entre 200 y 600");
            for (int i = 0; i < Fila; i++)
            {
                for (int j = 0; j < Columna; j++)
                {
                    Console.WriteLine("Fila: " + (i + 1) + ", Columna: " + (j + 1));
                    do
                    {
                        Console.WriteLine("Valor " + (j + 1));
                        numero = int.Parse(Console.ReadLine());
                        //En dado caso que no cumpla la regla, se dice que no es posible el valor y se pide de nuevo.
                        if (numero <= 200 || numero >= 600)
                        {
                            Console.WriteLine("Solo valores que esten entre 200 y 600");
                        }
                        //En caso de que si, lo guardamos. 
                        else
                        {
                            matriz[i, j] = numero;
                        }
                    } while (numero <= 200 || numero >= 600);
                }
            }
            //Hacemos uso del metodo Collatz con cada valor de la matriz
            Console.WriteLine("Pasos que tomo finalizar cada valor de la matriz");
            for (int i = 0; i < Fila; i++)
            {
                for (int j = 0; j < Columna; j++)
                {
                    //Declaramos el valor de numero para sacarlo de la matriz, al igual que el pasos a 0
                    numero = matriz[i, j];
                    ContarPasos = 0;
                    //Mientras que no llegue al uno, seguiremos el ciclo.
                    while (numero != 1)
                    {
                        //Si es par,lo dividimos entre dos y aumentamos pasos.
                        if (numero % 2 == 0)
                        {
                            numero /= 2;
                            ContarPasos++;
                        }
                        //Si no es par, lo multiplicamos por 3 y sumamos uno, nuevamente aumentamos pasos.
                        if (numero % 2 == 1 && numero != 1)
                        {
                            numero = (numero * 3) + 1;
                            ContarPasos++;
                        }
                    }
                    //Avisamos cuantos pasos pasaron para llegar a 1.
                    Console.WriteLine("La posicion [" + i + "] [" + j + "] de la matriz con el valor '"
                    + matriz[i, j] + "' concluyo con un total de " + ContarPasos + " pasos.");
                }
            }
        }
    }
}

