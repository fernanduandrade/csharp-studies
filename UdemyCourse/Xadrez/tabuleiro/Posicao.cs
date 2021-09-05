namespace tabuleiro {
    class Posicao
    {
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        public int linha {get; set; }
        public int coluna {get; set; }

        public void DefinirValores(int linha, int coluna) {
            this.linha = linha;
            this.coluna = coluna;
        }
        
        public override string ToString()
        {
            return linha + ", " + coluna;

        }
    }
}
