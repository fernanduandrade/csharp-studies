using tabuleiro;

namespace xadrez {
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base( tabuleiro, cor)
        {
            
        }

        public override string ToString()
        {
            return "T";

        }

        public bool PoderMover(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }

        public override  bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);


            // cima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.linha = pos.linha - 1;
            }
            
            // baixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.linha = pos.linha + 1;
            }

            // direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.coluna = pos.coluna + 1;
            }

            // esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }

                pos.coluna = pos.coluna - 1;
            }
            
            return mat;
        }

    }
}
