namespace Course.Entities {
    public class Empregado
    {
        public string Nome {get; set; }
        public int Horas {get; set; }
        public double ValorPorHora {get; set; }

        public Empregado() { }

        public Empregado(string nome, int hora, double valorPorHora)
        {
            Nome = nome;
            Horas = hora;
            ValorPorHora = valorPorHora;
        }

        public virtual double Pagamento()
        {
            return Horas * ValorPorHora;
        }
    }
}

