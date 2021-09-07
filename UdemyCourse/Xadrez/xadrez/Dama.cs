using tabuleiro;

namespace xadrez {

    class Dama : Peca {

        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "D";
        }

        private bool PoderMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha, pos.coluna - 1);
            }

            // direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha, pos.coluna + 1);
            }

            // acima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna);
            }

            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna);
            }

            // NO
            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna - 1);
            }

            // NE
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha - 1, pos.coluna + 1);
            }

            // SE
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
            }

            // SO
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.DefinirValores(pos.linha + 1, pos.coluna - 1);
            }

            return mat;
        }
    }
}