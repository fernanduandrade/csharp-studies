using tabuleiro;
using System;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (tabuleiro.peca(i, j) == null) { 
                        Console.Write("- ");
                    }
                    else { 
                        Console.Write(tabuleiro.peca(i, j) + " ");
                    }
                }

                Console.WriteLine(); 
            }
        }
    }
}
