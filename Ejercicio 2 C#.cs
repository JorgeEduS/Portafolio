using System;

namespace Evidencia2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Jorge Eduardo Sosa Rodriguez AL02954769
            // Jesus Arturo Martinez Navarro AL02964388

            //Declaramos las variables que utilizaremos para todo el programa. 
            int datos = 12, incognitas = 2, ren = incognitas, col = incognitas + 1;
            double x1Anibal = 0, x2Anibal = 0, x1Maria = 0, x2Maria = 0,
                xAnibal = 0, salto = .1, yAnibal, yAnteriorAnibal, xAnteriorAnibal, yIntermediaAnibal = 0.00011, xIntermediaAnibal = 0,
                pivote, factor, xMaria = 0, yMaria = 0, yAnteriorMaria, xAnteriorMaria, yIntermediaMaria = 0.00011, xIntermediaMaria = 0,
                t = 1, y = 50, f1 = 1, f2 = 1, criterio = 0.00001;

            double[]  anibalDatos = {50, 55, 60, 61, 65, 67, 69, 70, 72, 73, 74, 76};
            double[]  mariaDatos = {49, 57, 59, 61, 63, 65, 67, 69, 70, 71, 72, 74};
            double[]  tiempo = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            double[,] jacobianaAnibal = new double[datos, incognitas];
            double[,] jacobianaMaria = new double[datos, incognitas];
            double[,] matrizAnibal = new double[incognitas, incognitas + 1];
            double[,] matrizMaria = new double[incognitas, incognitas + 1];
            double[,] matriz = new double[ren, col];


            //Empezamos con el metodo de minimos cuadrados para ambos bebes.

            /////////EVALUAR MATRIZ JACOBIANA EN CADA TIEMPO ANIBAL //////////////////
            for (int i = 0; i < tiempo.Length; i++)
            {
                jacobianaAnibal[i, 0] = Math.Log(tiempo[i]);  ///PRIMERA COLUMNA DX
                jacobianaAnibal[i, 1] = 1;                   ///SEGUNDA COLUMNA DY
            }

            /////////////JACOBIANA^-1 * JACOBIANA ////////////////
            for (int r = 0; r < incognitas; r++)
            {
                ///r = 2    c = 0   1   2
                for (int c = 0; c < incognitas; c++)
                {
                    for (int d = 0; d < datos; d++)
                    {
                        ///matriz[r,c] += jacobiana[d,FIJA] * jacobiana[d,AVANZA];
                        matrizAnibal[r, c] += jacobianaAnibal[d, r] * jacobianaAnibal[d, c];
                    }
                }
            }

            ///////////COLUMNAS DE LA JACOBIANA * ESTATURA ///////
            for (int c = 0; c < incognitas; c++) ///COLUMNA
            {
                for (int r = 0; r < datos; r++)  ///RENGLONES
                {
                    matrizAnibal[c, incognitas] += jacobianaAnibal[r, c] * anibalDatos[r];
                }
            }

            ////////////INICIA ELIMINACION GAUSSIANA////////////////////////
            for (int i = 0; i < ren; i++)///RECORRE LOS RENGLONES
            {
                pivote = matrizAnibal[i, i]; // SELECCION DEL PIVOTE
                                       //DIVIDE ENTRE EL PIVOTE
                for (int j = 0; j < col; j++)///RECORRE LAS COLUMNAS
                {
                    matrizAnibal[i, j] = matrizAnibal[i, j] / pivote;
                }
                //CICLOS PARA CONVERTIR A CERO
                for (int k = 0; k < ren; k++) ///RECORRE RENGLONES
                {
                    if (k != i)
                    {
                        factor = matrizAnibal[k, i]; //ELEMENTO QUE QUIERES CONVERTIR A CERO
                        for (int l = 0; l < col; l++) ///RECORRE COLUMNAS
                        {
                            ///matriz = matriz  - factor * matriz(Rpivote, )
                            matrizAnibal[k, l] = matrizAnibal[k, l] - factor * matrizAnibal[i, l];
                        }
                    }
                }
            }
            ///////////TERMINA ELIMINACION GAUSSIANA////////////////////////

            //Imprimimos cuales son las x y ademas, imprimimos la ecuacion resultante con estos valores.
            Console.WriteLine();
            Console.WriteLine("Constantes de la ecuacion de Anibal");
            for (int r = 0; r < ren; r++) //RENGLONES
            {
                Console.WriteLine("x" + (r + 1) + " = " + matrizAnibal[r, incognitas]);
                if (r == 1)
                {
                    x2Anibal = matrizAnibal[r, incognitas];
                }
                else
                {
                    x1Anibal = matrizAnibal[r, incognitas];
                }
            }
            Console.WriteLine("Ecuacion: "+x1Anibal + " ln(t) + " + x2Anibal);


            //---------------------------------------------------------------------------
            /////////EVALUAR MATRIZ JACOBIANA EN CADA TIEMPO DE MARIA //////////////////
            for (int i = 0; i < tiempo.Length; i++)
            {
                jacobianaMaria[i, 0] = Math.Cos(tiempo[i]/8);      ///PRIMERA COLUMNA DX
                jacobianaMaria[i, 1] = Math.Exp(tiempo[i]/10);     ///SEGUNDA COLUMNA DY
            }

            /////////////JACOBIANA^-1 * JACOBIANA ////////////////
            for (int r = 0; r < incognitas; r++)
            {
                ///r = 2    c = 0   1   2
                for (int c = 0; c < incognitas; c++)
                {
                    for (int d = 0; d < datos; d++)
                    {
                        ///matriz[r,c] += jacobiana[d,FIJA] * jacobiana[d,AVANZA];
                        matrizMaria[r, c] += jacobianaMaria[d, r] * jacobianaMaria[d, c];
                    }
                }
            }

            ///////////COLUMNAS DE LA JACOBIANA * ESTATURA///////
            for (int c = 0; c < incognitas; c++) ///COLUMNA
            {
                for (int r = 0; r < datos; r++)  ///RENGLONES
                {
                    matrizMaria[c, incognitas] += jacobianaMaria[r, c] * mariaDatos[r];
                }
            }

            ////////////INICIA ELIMINACION GAUSSIANA////////////////////////
            for (int i = 0; i < ren; i++)///RECORRE LOS RENGLONES
            {
                pivote = matrizMaria[i, i]; // SELECCION DEL PIVOTE
                                             //DIVIDE ENTRE EL PIVOTE
                for (int j = 0; j < col; j++)///RECORRE LAS COLUMNAS
                {
                    matrizMaria[i, j] = matrizMaria[i, j] / pivote;
                }
                //CICLOS PARA CONVERTIR A CERO
                for (int k = 0; k < ren; k++) ///RECORRE RENGLONES
                {
                    if (k != i)
                    {
                        factor = matrizMaria[k, i]; //ELEMENTO QUE QUIERES CONVERTIR A CERO
                        for (int l = 0; l < col; l++) ///RECORRE COLUMNAS
                        {
                            ///matriz = matriz  - factor * matriz(Rpivote, )
                            matrizMaria[k, l] = matrizMaria[k, l] - factor * matrizMaria[i, l];
                        }
                    }
                }
            }
            ///////////TERMINA ELIMINACION GAUSSIANA////////////////////////

            //Imprimimos cuales son las x y ademas, imprimimos la ecuacion resultante con estos valores.
            Console.WriteLine();
            Console.WriteLine("Constantes de la ecuacion de Maria");
            for (int r = 0; r < ren; r++) //RENGLONES
            {
                Console.WriteLine("x" + (r + 1) + " = " + matrizMaria[r, incognitas]);
                if (r == 1)
                {
                    x2Maria = matrizMaria[r, incognitas];
                }
                else
                {
                    x1Maria = matrizMaria[r, incognitas];
                }
            }
            Console.WriteLine("Ecuacion: "+ x1Maria + " cos(t/8) + " + x2Maria + " e^t/10");
            Console.WriteLine();

            //---------------------------------------------------------------------------
            // EMPIEZA METODO DE ECUACIONES NO LINEALES PARA LAS 2 FUNCIONES QUE OBTUVIMOS ANTERIORMENTE.
            while (Math.Abs(f1) > criterio || Math.Abs(f2) > criterio)
            {
                //evaluar funciones en valores de X y Y
                f1 = 10.58 * Math.Log(t) + 48.36 - y;
                f2 = 30.47 * Math.Cos(t/8) + 22.49 * Math.Exp(t/10) - y;

                //PROGRAMAR MATRIZ JACOBIANA///
                //DERIVADAS PARCIALES DE LA FUNCION 1
                matriz[0, 0] = 10.58 * (1/t);
                matriz[0, 1] = -1;
                //COLUMNA EXTENDIDA
                matriz[0, 2] = -f1;

                //DERIVADAS PARCIALES DE LA FUNCION 2
                matriz[1, 0] = -3.808 * Math.Sin(0.125 * t) + 2.249 * Math.Exp(t / 10);
                matriz[1, 1] = -1;
                //COLUMNA EXTENDIDA
                matriz[1, 2] = -f2;

                ///////ELIMINACION GAUSSIANA//////////////////
                for (int i = 0; i < ren; i++)///RECORRE LOS RENGLONES
                {
                    pivote = matriz[i, i]; // SELECCION DEL PIVOTE

                    //DIVIDE ENTRE EL PIVOTE
                    for (int j = 0; j < col; j++)///RECORRE LAS COLUMNAS
                    {
                        matriz[i, j] = matriz[i, j] / pivote;
                    }

                    //CICLOS PARA CONVERTIR A CERO

                    for (int k = 0; k < ren; k++) ///RECORRE RENGLONES
                    {
                        if (k != i)
                        {
                            factor = matriz[k, i]; //ELEMENTO QUE QUIERES CONVERTIR A CERO
                            for (int l = 0; l < col; l++) ///RECORRE COLUMNAS
                            {
                                ///matriz = matriz  - factor * matriz(Rpivote, )
                                matriz[k, l] = matriz[k, l] - factor * matriz[i, l];
                            }
                        }
                    }
                }
                //////TERMINA ELIMINACION GAUSSIANA////////

                //AVANZAR X Y
                t += matriz[0, col - 1];
                y += matriz[1, col - 1];
            }

            //IMPRIMIMOS LA RAIZ EN DONDE AMBAS ECUACIONES SE INTERSECCIONAN, ES DECIR, LOS MESES EN QUE TENDRAN LA MISMA ESTATURA.
            Console.WriteLine("Los bebes tendran la misma estatura de " + y + " cm a los " + t + " meses.");
            Console.WriteLine();

            //---------------------------------------------------------------------------

            //EMPIEZA LA ELIMINACION POR BISECCION PARA ANIBAL
            xAnteriorAnibal = xAnibal;
            ///EVALUAR FUNCION EN X
            yAnibal = 10.58 * Math.Log(xAnibal) + 48.36 - 60; /////ECUACION A ANALIZAR
            yAnteriorAnibal = yAnibal;

            while (yAnibal * yAnteriorAnibal > 0) /// TIENEN EL MISMO SIGNO
            {
                //// Asingar valores actuales [x,y] a los valores Anteriores [xAnterior,yAnterior]
                xAnteriorAnibal = xAnibal;
                yAnteriorAnibal = yAnibal;
                ////Avanzar valores actuales [x,y]
                xAnibal = xAnibal + salto;
                yAnibal = 10.58 * Math.Log(xAnibal) + 48.36 - 60; /////ECUACION A ANALIZAR
            }
            while (Math.Abs(yIntermediaAnibal) > criterio) /// REDUCIENDO EL INTERVALO
            {
                /// ECONTRAR PUNTO INTERMEDIO 
                xIntermediaAnibal = (xAnibal + xAnteriorAnibal) / 2;
                yIntermediaAnibal = 10.58 * Math.Log(xIntermediaAnibal) + 48.36 - 60; /////ECUACION A ANALIZAR

                /// COMPRAR LA Y INTERMEDIA CON LAS Y's DE LOS LIMITES
                if (yAnteriorAnibal * yIntermediaAnibal > 0)
                {
                    ///CONVERTIR LOS VALORES A ANTERIORES A LOS VALORES INTERMEDIOS
                    xAnteriorAnibal = xIntermediaAnibal;
                    yAnteriorAnibal = yIntermediaAnibal;
                }
                else if (yAnibal * yIntermediaAnibal > 0)
                {
                    ///CONVERTIR LOS VALORES ACTUALES A LOS VALORES INTERMEDIOS
                    xAnibal = xIntermediaAnibal;
                    yAnibal = yIntermediaAnibal;
                }
            }
 
            ///IMPRIMIR RAIZ EN CUANTO ANIABL TENDRA 60 CENTIMETROS.
            Console.WriteLine("La estatura de Anibal sera de 60 centimetros a los " + xIntermediaAnibal);

            //---------------------------------------------------------------------------

            //EMPIEZA LA ELIMINACION POR SECANTE PARA MARIA
            xAnteriorMaria = xMaria;
            ///EVALUAR FUNCION EN X
            yMaria = 30.47 * Math.Cos(xMaria / 8) + 22.49 * Math.Exp(xMaria / 10) - 60; /////ECUACION A ANALIZAR
            yAnteriorMaria = yMaria;

            while (yMaria * yAnteriorMaria > 0) /// TIENEN EL MISMO SIGNO
            {
                //// Asingar valores actuales [x,y] a los valores Anteriores [xAnterior,yAnterior]
                xAnteriorMaria = xMaria;
                yAnteriorMaria = yMaria;
                ////Avanzar valores actuales [x,y]
                xMaria = xMaria + salto;
                yMaria = 30.47 * Math.Cos(xMaria / 8) + 22.49 * Math.Exp(xMaria / 10) - 60; /////ECUACION A ANALIZAR
            }
            while (Math.Abs(yIntermediaMaria) > criterio) /// REDUCIENDO EL INTERVALO
            {
                xIntermediaMaria = xMaria - ((xAnteriorMaria - xMaria) * yMaria) / (yAnteriorMaria - yMaria);
                yIntermediaMaria = 30.47 * Math.Cos(xIntermediaMaria / 8) + 22.49 * Math.Exp(xIntermediaMaria / 10) - 60; /////ECUACION A ANALIZAR

                /// COMPRAR LA Y INTERMEDIA CON LAS Y's DE LOS LIMITES
                if (yAnteriorMaria * yIntermediaMaria > 0)
                {
                    ///CONVERTIR LOS VALORES A ANTERIORES A LOS VALORES INTERMEDIOS
                    xAnteriorMaria = xIntermediaMaria;
                    yAnteriorMaria = yIntermediaMaria;
                }
                else if (yMaria * yIntermediaMaria > 0)
                {
                    ///CONVERTIR LOS VALORES ACTUALES A LOS VALORES INTERMEDIOS
                    xMaria = xIntermediaMaria;
                    yMaria = yIntermediaMaria;
                }
            }
            ///IMPRIMIR RAIZ EN CUANTO MARIA TENDRA 60 CENTIMETROS.
            Console.WriteLine();
            Console.WriteLine("La estatura de Maria sera de 60 centimetros a los " + xIntermediaMaria);
        }
    }
}
