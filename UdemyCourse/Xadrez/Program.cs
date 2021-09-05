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

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                    
                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);
                    

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutarMovimento(origem, destino);
                }

            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
