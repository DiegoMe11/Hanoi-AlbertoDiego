using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine();
            Console.WriteLine("3 torres");
            Console.WriteLine();
            Console.WriteLine("Indica el número de discos");

            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Has seleccionado " + n + " discos");
            Console.WriteLine();

            Pila ini = new Pila(n);
            Pila aux = new Pila();
            Pila fin = new Pila();

            Console.WriteLine("Indica I para iterativo o R para recursivo...");
            Console.WriteLine();

            string modo = Console.ReadLine();

            Thread.Sleep(1000);

            if (modo.Equals("I"))
            {
                Console.WriteLine("Has seleccionado el metodo iterativo");
                Console.WriteLine();
            }
            else if (modo.Equals("R"))
            {
                Console.WriteLine("Has seleccionado el metodo recursivo");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No ha seleccionado ningun modo");
                Console.WriteLine();
            }


            Console.WriteLine("Situacion inicial");
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

            int movimientos = 0;

            if (modo.Equals("I"))
            {

                movimientos = new Hanoi().iterativo(n, ini, fin, aux);
            }
            else if (modo.Equals("R"))
            {
                movimientos = new Hanoi().recursivo(n, ini, fin, aux);
            }

            Thread.Sleep(1000);
            Console.WriteLine();
            Console.WriteLine("Con " + n + " piezas se han necesitado " + movimientos + " movimientos para resolver el puzle");
            Console.WriteLine("Pulsa cualquier boton para salir");
            Console.ReadLine();
        }
    }
}
