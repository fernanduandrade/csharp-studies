namespace EstruturaCondicional
{
    public class PrecoFinal
    {
        private float _preco {get;}
        private float _quantidade {get;}
        public PrecoFinal(float preco, float quantidade) {
            _preco = preco;
            _quantidade = quantidade;
        }

        public float CalcularPrecoFinal() 
        {
            float precoFinal = _preco * _quantidade;

            return precoFinal;
        }
    }
}