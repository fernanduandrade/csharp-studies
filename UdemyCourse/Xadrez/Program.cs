using System;
using tabuleiro;
using xadrez;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                PartidaXadrez partida = new PartidaXadrez();


                Tela.ImprimirTabuleiro(partida.tabuleiro);
            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
