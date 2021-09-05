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

        public abstract bool[,] MovimentosPossiveis();
    }
}
