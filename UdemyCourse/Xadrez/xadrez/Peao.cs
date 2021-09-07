using tabuleiro;

namespace xadrez {

    class Peao : Peca {

        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
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
            }

            return mat;
        }
    }
}