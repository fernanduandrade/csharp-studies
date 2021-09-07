using tabuleiro;

namespace xadrez {

    class Peao : Peca {

        private PartidaXadrez partida;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;                
        }


        public override string ToString() {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool Livre(Posicao pos) {
            return tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branco) {
                pos.DefinirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 2, posicao.coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos) && quantidadeMovimento == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Jogada especial En Passant
                if(posicao.linha ==  3) {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if(tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha -1 , esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if(tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha - 1, direita.coluna] = true;
                    }
                }
            }
            else {
                pos.DefinirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 2, posicao.coluna);
                if (tabuleiro.PosicaoValida(pos) && Livre(pos) && quantidadeMovimento == 0) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    mat[pos.linha, pos.coluna] = true;
                }

                // Jogada especial En Passant
                if(posicao.linha ==  4) {
                    Posicao esquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if(tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && tabuleiro.peca(esquerda) == partida.vulneravelEnPassant) {
                        mat[esquerda.linha + 1, esquerda.coluna] = true;
                    }

                    Posicao direita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if(tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && tabuleiro.peca(direita) == partida.vulneravelEnPassant) {
                        mat[direita.linha + 1, direita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}