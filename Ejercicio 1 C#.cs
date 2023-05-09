using System;

namespace Evidencia3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double[] x = { 3, 4 };
            double[] y = { 23.5, 30 };
            int datos = x.Length;
            int ren = datos, col = datos + 1;
            double pivote, factor;
            double[,] matriz = new double[datos, datos + 1];

            Console.WriteLine("====================");
            Console.WriteLine("====== Punto 1 =====");
            Console.WriteLine("====================");
            Console.WriteLine();

            ///INFORMAR MATRIZ CUADRADRA
            for (int i = 0; i < datos; i++) ////RECORRE RENGLONES
            {
                for (int j = 0; j < datos; j++) ////RECORRE COLUMNAS
                {
                    matriz[i, j] = Math.Pow(x[i], j);
                }
            }

            ///INFORMAR COLUMNA EXTENDIDA (VACIAR VECTOR Y A LA ULTIMA COLUMNA)
            for (int i = 0; i < datos; i++)
            {
                matriz[i, datos] = y[i];
            }

            ////////////////////////ELIMINACION GAUSSIANA ///////////////////
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


            //////////////IMPRIMIR COEFICIENTES DE LA ECUACION////////////////////
            Console.WriteLine("La ecuacion de aceleracion de la particula: " + matriz[0, datos] + " + " + matriz[1, datos] + "x");
            Console.WriteLine();
            Console.WriteLine("La ecuacion de velocidad de la particula: 6.5x^2/2 + 4x + 2.5");
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine("====== Punto 2 =====");
            Console.WriteLine("====================");
            Console.WriteLine();

            double lInferior = 5, lSuperior = 10, baseF, altura1, altura2, altura3, areaT = 0, partes = 1; // adaptar 

            baseF = (lSuperior - lInferior) / partes;

            for (double X = lInferior; X < lSuperior;)
            {
                ///primera altura (x = 3)
                altura1 = 4 + (6.5 * X);

                ///segunda altura (3 + 4/2) = (3 + 2) = 5
                X += baseF / 2;
                altura2 = 4 + (6.5 * X);

                ///tercera altura (5 + 4/2) = (5 +2) = 7
                X += baseF / 2;
                altura3 = 4 + (6.5 * X);

                areaT += (altura1 + 4 * altura2 + altura3) / 6 * baseF;

            }

            Console.WriteLine("El resultado de la integral es: " + areaT);
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine("====== Punto 3 =====");
            Console.WriteLine("====================");
            Console.WriteLine();
            double tiempo = 0, Y = 0, k1, k2, k3, k4, XBusqueda = 25, yTemp;
            double paso = 1;

            //Metodo de Kutta
            while (tiempo < XBusqueda)
            {
                ///PRIMER CONSTANTE
                k1 = ((6.5 * Math.Pow(tiempo, 2)) / 2) + (4 * tiempo) + 2.5;
                tiempo = tiempo + paso / 2;                ///AVANZAR X                   
                yTemp = k1 * (paso / 2) + Y;    ///AVANZAR Y
                                                ///SEGUNDA CONSTANTE
                k2 = ((6.5 * Math.Pow(tiempo, 2)) / 2) + (4 * tiempo) + 2.5;
                yTemp = k2 * (paso / 2) + Y;     ///AVANZAR Y
                                                 ///TERCER CONSTANTE
                k3 = ((6.5 * Math.Pow(tiempo, 2)) / 2) + (4 * tiempo) + 2.5;
                tiempo = tiempo + paso / 2;                ///AVANZAR X         
                yTemp = k3 * (paso) + Y;       ///AVANZAR Y
                                               ///CUARTA CONSTANTE
                k4 = ((6.5 * Math.Pow(tiempo, 2)) / 2) + (4 * tiempo) + 2.5;
                ///SIGUIENTE VALOR DE Y
                Y = Y + (k1 + 2 * k2 + 2 * k3 + k4) / 6 * paso;
            }
            Console.WriteLine("Ecuacion de la posicion de la particula: 6.5(25)^3/6 + 4(25)^2/2 + 2.5(25)");
            Console.WriteLine();

            Console.WriteLine("El valor de Y cuando x es " + XBusqueda + " es: " + Y);
            Console.WriteLine();
        }
    }
}
