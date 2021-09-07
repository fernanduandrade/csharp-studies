using tabuleiro;

namespace xadrez {
    class Rei : Peca
    {
        private PartidaXadrez partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base( tabuleiro, cor)
        {
            this.partida = partida;   
        }

        public override string ToString()
        {
            return "R";
        }

        public bool PoderMover(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;
        }

        private bool TesteTorreParaRoque(Posicao posicao) {
            Peca p = tabuleiro.peca(posicao);
            return p != null && p is Torre && p.cor == cor && p.quantidadeMovimento == 0;
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

            // Jogada especial - Roque
            if(quantidadeMovimento == 0 && !partida.Xeque) {

                // Jogada especial - Roque pequeno
                Posicao posT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(TesteTorreParaRoque(posT1)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null) {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // Jogada especial - Roque grande
                Posicao posT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if(TesteTorreParaRoque(posT2)) {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if(tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null) {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;


        }
    }
}
