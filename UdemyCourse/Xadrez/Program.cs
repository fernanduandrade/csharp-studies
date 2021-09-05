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
                    try {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: {partida.Turno}");
                        Console.WriteLine($"Aguardando jogada: {partida.JogadorAtual}");

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);
                        
                        bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).MovimentosPossiveis();
                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);
                        

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();

                        partida.RealizarJogada(origem, destino);
                    } catch(TabuleiroException erro) {
                        Console.WriteLine(erro.Message);
                    }
                    
                }

            }
            catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
