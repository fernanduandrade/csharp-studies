using System;
using tabuleiro;

namespace xadrez {
    class PartidaXadrez
    {
        public Tabuleiro tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; set;}
        public bool Terminada{get; private set; }

        public PartidaXadrez() {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branco;
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = tabuleiro.RemoverPeca(destino);
            tabuleiro.ColocarPeca(peca, destino);
        }

        public void RealizarJogada(Posicao origem, Posicao destino) {
            ExecutarMovimento(origem, destino);
            Turno++;
            MudarJogador();
        }

        public void ValidarPosicaoOrigem(Posicao posicao) {
            if(tabuleiro.peca(posicao) == null) {
                throw new TabuleiroException("Não existe peça para essa posição escolhida");
            }

            if(JogadorAtual != tabuleiro.peca(posicao).cor) {
                throw new TabuleiroException("A peça escolhida não é sua!");
            }
            if(!tabuleiro.peca(posicao).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida!");
            }
        }


        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if(!tabuleiro.peca(origem).PoderMoverPara(destino)) {
                throw new TabuleiroException("Posição inválida");
            }
        }

        public void MudarJogador() {
            if(JogadorAtual == Cor.Branco) {
                JogadorAtual = Cor.Preto;
            } 
            else {
                JogadorAtual = Cor.Branco;
            }
        }

        public void ColocarPecas() {
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('c', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('c', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('d', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('e', 2).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Branco), new PosicaoXadrez('e', 1).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Branco), new PosicaoXadrez('d', 1).ToPosicao());

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('c', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('c', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('d', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('e', 7).ToPosicao());
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preto), new PosicaoXadrez('e', 8).ToPosicao());
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preto), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
