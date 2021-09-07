using tabuleiro;

namespace xadrez {
    class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base( tabuleiro, cor)
        {
            
        }

        public override string ToString()
        {
            return "B";

        }

        public bool PoderMover(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }

        public override  bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);


            // Noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna -1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.DefinirValores(pos.linha -1, pos.coluna -1);
            }
            
            // Nordeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.DefinirValores(pos.linha -1, pos.coluna + 1);
            }

            // Sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.DefinirValores(pos.linha + 1, pos.coluna + 1);
            }

            // Sudoeste
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
