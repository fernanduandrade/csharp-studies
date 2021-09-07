using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaXadrez
    {
        public Tabuleiro tabuleiro {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; private set;}
        public bool Terminada{get; private set; }
        public bool Xeque {get; private set;}
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public Peca vulneravelEnPassant {get; private set;}

        public PartidaXadrez() {
            tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            Terminada = false;
            Xeque = false;
            vulneravelEnPassant = null;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            JogadorAtual = Cor.Branco;
            ColocarPecas();
        }

        public Peca ExecutarMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.RemoverPeca(origem);
            peca.IncrementarMovimento();
            Peca pecaCapturada = tabuleiro.RemoverPeca(destino);
            tabuleiro.ColocarPeca(peca, destino);
            if(pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }

            // Jogada especial - Roque pequeno
            if(peca is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tabuleiro.RemoverPeca(origemT);
                T.IncrementarMovimento();
                tabuleiro.ColocarPeca(T, destinoT);
            }

            // Jogada especial - Roque Grande
            if(peca is Rei && destino.coluna == origem.coluna - 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tabuleiro.RemoverPeca(origemT);
                T.IncrementarMovimento();
                tabuleiro.ColocarPeca(T, destinoT);
            }

            // jogada especial en passant
            if(pecaCapturada is Peao) {
                if(origem.coluna != destino.coluna && pecaCapturada == null) {
                    Posicao posP;
                    if(pecaCapturada.cor == Cor.Branco) {
                        posP = new Posicao(destino.linha + 1, destino.coluna);
                    } 
                    else {
                        posP = new Posicao(destino.linha - 1, destino.coluna);
                    }
                    pecaCapturada = tabuleiro.RemoverPeca(posP);
                    capturadas.Add(pecaCapturada);
                }
            }

            return pecaCapturada;
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void RealizarJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutarMovimento(origem, destino);

            if (EstarEmXeque(JogadorAtual)) {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            
            Peca p = tabuleiro.peca(destino);

            // jogada especial - promocao
            if(p is Peao) {
                if((p.cor == Cor.Branco && destino.linha == 0) || p.cor == Cor.Preto && destino.linha == 07) {
                    p = tabuleiro.RemoverPeca(destino);
                    pecas.Remove(p);
                    Peca dama = new Dama(tabuleiro, p.cor);
                    tabuleiro.ColocarPeca(dama, destino);
                    pecas.Add(dama);
                }
            }

            if (EstarEmXeque(Adversario(JogadorAtual))) {
                Xeque = true;
            }
            else {
                Xeque = false;
            }

            if(TesteXequeMate(Adversario(JogadorAtual))) {
                Terminada = true;
            } 
            else {
                Turno++;
                MudarJogador();
            }


            // Jogada En Passant            
            if(p is Peao &&(destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2)) {
                vulneravelEnPassant = p;
            } 
            else {
                vulneravelEnPassant = null;
            }

        }

        public bool TesteXequeMate(Cor cor) {
            if(!EstarEmXeque(cor)) {
                return false;
            }
            foreach(Peca x in PecasEmJogo(cor)) {
                bool[,] mat = x.MovimentosPossiveis();
                for( int i = 0; i < tabuleiro.linhas; i++) {
                    for(int j = 0; j < tabuleiro.colunas; j++) {
                        if(mat[i,j]) {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(i,j);
                            Peca pecaCapturada = ExecutarMovimento(origem, destino);
                            bool testeXeque = EstarEmXeque(cor);
                            DesfazerMovimento(origem, destino, pecaCapturada);

                            if(!testeXeque) {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tabuleiro.RemoverPeca(destino);
            p.DecrementarMovimento();
            if(pecaCapturada != null) {
                tabuleiro.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }

            // Roque pequeno
            if(p is Rei && destino.coluna == origem.coluna + 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tabuleiro.RemoverPeca(destinoT);
                T.DecrementarMovimento();
                tabuleiro.ColocarPeca(T, origemT);
            }

            // Roque grande
            if(p is Rei && destino.coluna == origem.coluna - 2) {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tabuleiro.RemoverPeca(destinoT);
                T.DecrementarMovimento();
                tabuleiro.ColocarPeca(T, origemT);
            }

            // Jogada especial - En Passant
            if(p is Peao) {
                if(origem.coluna != destino.coluna && pecaCapturada == vulneravelEnPassant) {
                    Peca peao = tabuleiro.RemoverPeca(destino);
                    Posicao posP;
                    if(p.cor == Cor.Branco) {
                        posP = new Posicao(3, destino.coluna);
                    }
                    else {
                        posP = new Posicao(4, destino.coluna);
                    }

                    tabuleiro.ColocarPeca(peao, posP);
                } 
            }

            tabuleiro.ColocarPeca(p, origem);
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
            if (JogadorAtual == Cor.Branco) {
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

            // brancas
            ColocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.Branco));
            ColocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.Branco));

            ColocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.Branco));

            ColocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.Branco));
            ColocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.Branco));

            ColocarNovaPeca('d', 1, new Dama(tabuleiro, Cor.Branco));
            ColocarNovaPeca('e', 1, new Rei(tabuleiro, Cor.Branco, this));

            ColocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.Branco,this));
            ColocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.Branco,this));

            // pretas

            ColocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.Preto));
            ColocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.Preto));

            ColocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.Preto));

            ColocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.Preto));
            ColocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.Preto));

            ColocarNovaPeca('d', 8, new Dama(tabuleiro, Cor.Preto));
            ColocarNovaPeca('e', 8, new Rei(tabuleiro, Cor.Preto, this));

            ColocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.Preto, this));
            ColocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.Preto, this));

        }

        private Cor Adversario(Cor cor) {
            if (cor == Cor.Branco) {
                return Cor.Preto;
            }
            else {
                return Cor.Branco;
            }
        }
        private Peca rei(Cor cor) {
            foreach (Peca x in PecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool EstarEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversario(cor))) {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }
            return false;
        }
    }
}
