using tabuleiro;

namespace xadrez {
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base( tabuleiro, cor)
        {
            
        }

        public override string ToString()
        {
            return "R";
        }

        public bool PoderMover(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }

        public override  bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // Cima
            pos.DefinirValores(posicao.linha - 1, posicao.coluna);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // nordeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // direita
            pos.DefinirValores(posicao.linha, posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // sudeste
            pos.DefinirValores(posicao.linha + 1, posicao.coluna + 1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // abaixo
            pos.DefinirValores(posicao.linha + 1, posicao.coluna);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // sudoeste
            pos.DefinirValores(posicao.linha +1 , posicao.coluna -1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // esquerda
            pos.DefinirValores(posicao.linha, posicao.coluna -1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            // noroeste
            pos.DefinirValores(posicao.linha - 1, posicao.coluna -1);
            if(tabuleiro.PosicaoValida(pos) && PoderMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }


            return mat;


        }
    }
}
