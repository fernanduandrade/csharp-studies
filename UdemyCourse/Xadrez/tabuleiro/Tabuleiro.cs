namespace tabuleiro {
    class Tabuleiro {
        public int linhas {get; set; }
        public int colunas {get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(Posicao posicao) {
            return pecas[posicao.linha, posicao.coluna];
        }
        
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        
        public void ColocarPeca(Peca peca, Posicao posicao)
        {
            if (ExistePeca(posicao)) {
                throw new TabuleiroException("Peça já existe");
            }
            pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }

        public bool PosicaoValida(Posicao posicao) {
            if(posicao.linha < 0 || posicao.linha >= linhas || posicao.coluna < 0 || posicao.coluna >= colunas)
            {
                return false;   
            }
            return true;
        }

        public Peca RemoverPeca(Posicao posicao)
        {
            if(peca(posicao) == null)
            {
                return null;
            }
            Peca aux = peca(posicao);
            aux.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return aux;

        }

        public void ValidarPosicao(Posicao posicao) {
            if (!PosicaoValida(posicao)) {
                throw new TabuleiroException("Posição inválida");
            }
        }

        public bool ExistePeca(Posicao posicao) {
            ValidarPosicao(posicao);
            return peca(posicao) != null;
        }
    }
}
