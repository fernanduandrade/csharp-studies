using tabuleiro;

namespace xadrez {
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base( tabuleiro, cor)
        {
            
        }

        public override string ToString()
        {
            return "C";

        }

        public bool PoderMover(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }

        public override  bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 2);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 2);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 2, posicao.coluna + 1);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 2, posicao.coluna - 1);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            pos.DefinirValores(posicao.linha + 1, posicao.coluna - 2);
            if (tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            
            return mat;
        }

    }
}
