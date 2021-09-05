namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao {get; set; }
        public Cor cor {get; protected set; }
        public int quantidadeMovimento {get; protected set; }
        public Tabuleiro tabuleiro {get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.quantidadeMovimento = 0;
        }

        public void IncrementarMovimento()
        {
            quantidadeMovimento++;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < tabuleiro.linhas; i++) {
                for(int j = 0; j < tabuleiro.colunas; j++) {
                    if(mat[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public abstract bool[,] MovimentosPossiveis();

        
    }
     
}
