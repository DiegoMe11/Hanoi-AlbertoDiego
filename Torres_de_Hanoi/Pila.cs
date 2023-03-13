using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {
        public int Size { get; set; } //Guarda el tamaño de la pila
        public int Top { get; set; } //Guarda el elemento de arriba de la pila
        public List<Disco> Elementos { get; set; } //List donde guarda los discos de la pila


        public Pila() //Inicializa la pila
        {
            Top = 0;
            Size = 0;
            Elementos = new List<Disco>();
        }
        public Pila(int Size) //Añade las variables a la pila
        {
            this.Size = Size;
            Elementos = new List<Disco>();

            for (int i = this.Size; i > 0; i--)
            {
                Elementos.Add(new Disco(i));
                if (i == 1)
                {
                    Top = Elementos[i].Valor;
                }
            }
        }

        public void push(Disco d) //Añade un disco a la pila y actualiza top y size
        {
            Elementos.Add(d);
            this.Size++;
            Top = Elementos[0].Valor;

        }

        public Disco pop() //Elimina un disco a la pila y actualiza top y size
        {
            Disco disco = Elementos.Last();
            Elementos.Remove(disco);

            if (Elementos.Count == 0) //Si no hay discos en una pila top = 0
            {
                Top = 0;
            }
            else
            {
                Top = Elementos[0].Valor;
            }
            this.Size--;
            return disco;
        }

        public bool isEmpty() //True si esta vacia, false si hay algo
        {
            bool devuelve;
            if (Elementos.Count == 0)
            {
                devuelve = true;
            }
            else
            {
                devuelve = false;
            }
            return devuelve;
        }

    }
}

