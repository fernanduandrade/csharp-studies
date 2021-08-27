using System;
using tabuleiro;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Posicao posicao = new Posicao(3, 5);

            Console.WriteLine("Posição: " + posicao);

            Console.ReadLine();
        }
    }
}
