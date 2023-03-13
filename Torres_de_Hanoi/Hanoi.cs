using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Torres_de_Hanoi
{
    class Hanoi
    {
        public int movimientos { get; set; }
        public Hanoi() //Inicializa los movimientos a 0
        {
            movimientos = 0;
        }
        public void mover_disco(Pila a, Pila b) //Mueve entre dos pilas el disco de arriba
        {
            int a_top = a.Top;
            int b_top = b.Top;

            if (a_top == 0) //Comprueba si el top de a es igual 0
            {
                if (b_top > 0) //Comprueba si el top de b es mayor a 0, mueve el disco de b a a
                {
                    Disco b_pop = b.pop(); //Elimina b top
                    a.push(b_pop); //Pone b top en a
                }
            }
            else if (b_top == 0) //Comprueba si el top de b es igual 0
            {
                if (a_top > 0) //Comprueba si el top de a es mayor a 0, mueve el disco de a a b
                {
                    Disco a_pop = a.pop();
                    b.push(a_pop);
                }
            }
            else if (a_top < b_top) //Comprueba top a es mayor a top b
            {
                Disco a_pop = a.pop();
                b.push(a_pop);
            }
            else
            {
                Disco b_pop = b.pop();
                a.push(b_pop);
            }
        }

        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            if ((n % 2) == 0) //Comprobamos si num es un número par o no
            {
                do //Hace esto mientras el numero de discos de la ultima pila sea menor al total de discos
                {
                    mover_disco(ini, aux);
                    movimientos++;
                    Log(ini, aux, fin, movimientos);

                    mover_disco(ini, fin);
                    movimientos++;
                    Log(ini, aux, fin, movimientos);

                    if (fin.Elementos.Count < n)
                    {
                        mover_disco(aux, fin);
                        movimientos++;
                        Log(ini, aux, fin, movimientos);
                    }

                } while (fin.Elementos.Count < n);
            }
            else
            {
                do
                {
                    mover_disco(ini, fin);
                    movimientos++;
                    Log(ini, aux, fin, movimientos);

                    if (fin.Elementos.Count < n)
                    {
                        mover_disco(ini, aux);
                        movimientos++;
                        Log(ini, aux, fin, movimientos);

                        mover_disco(aux, fin);
                        movimientos++;
                        Log(ini, aux, fin, movimientos);

                    }
                } while (fin.Elementos.Count < n);
            }
            return movimientos;
        }

        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            if (n == 1)
            {
                mover_disco(ini, fin);
                movimientos++;
                Log(ini, aux, fin, movimientos);

            }
            else
            {
                recursivo(n - 1, ini, aux, fin);
                mover_disco(ini, fin);
                movimientos++;
                Log(ini, aux, fin, movimientos);
                recursivo(n - 1, aux, fin, ini);
            }
            return movimientos;
        }

        public void Log(Pila ini, Pila aux, Pila fin, int n)
        {
            Thread.Sleep(1000);

            Console.WriteLine("Situacion tras el movimiento " + n);

            Console.Write("INI: ");
            for (int i = 0; i <= ini.Size - 1; i++)
            {
                string ini_disco = ini.Elementos[i].Valor != null ? ini.Elementos[i].Valor.ToString() : " ";
                if (i == ini.Size - 1)
                {
                    Console.Write(ini_disco);
                }
                else if (ini.Size != 1)
                {
                    Console.Write(ini_disco + ", ");
                }
            }
            Console.WriteLine();

            Console.Write("AUX: ");
            for (int i = 0; i <= aux.Size - 1; i++)
            {
                string aux_disco = aux.Elementos[i].Valor != null ? aux.Elementos[i].Valor.ToString() : " ";
                if (i == aux.Size - 1)
                {
                    Console.Write(aux_disco);
                }
                else if (aux.Size != 1)
                {
                    Console.Write(aux_disco + ", ");
                }
            }
            Console.WriteLine();

            Console.Write("FIN: ");
            for (int i = 0; i <= fin.Size - 1; i++)
            {
                string fin_disco = fin.Elementos[i].Valor != null ? fin.Elementos[i].Valor.ToString() : " ";
                if (i == fin.Size - 1)
                {
                    Console.Write(fin_disco);
                }
                else if (fin.Size != 1)
                {
                    Console.Write(fin_disco + ", ");
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}