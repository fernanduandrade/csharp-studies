namespace Course.Entities {

    public class Tercerizado : Empregado {
        public double PagamentoAdicional {get; set; }
        
        public Tercerizado() {}
        public Tercerizado(string nome, int hora, double valorPorHora, double pagamentoAdicional) : base(nome, hora, valorPorHora)
        {
            PagamentoAdicional = pagamentoAdicional;
        }
        public override double Pagamento()
        {
            return base.Pagamento() + 1.1 * PagamentoAdicional;
                                        }
    }
}
