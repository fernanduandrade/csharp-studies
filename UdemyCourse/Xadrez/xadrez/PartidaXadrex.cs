using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaXadrez
    {
        public Tabuleiro tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; private set;}
        public bool Terminada{get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez() {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            JogadorAtual = Cor.Branco;
            ColocarPecas();
        }

        public void ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = tabuleiro.RemoverPeca(destino);
            tabuleiro.ColocarPeca(peca, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }

            
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) {
                if(x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
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

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }
        public void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branco));
            ColocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branco));
            ColocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branco));

            ColocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preto));

        }
    }
}
