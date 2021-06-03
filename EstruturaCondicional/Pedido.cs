namespace EstruturaCondicional
{
    public class Pedido
    {
        private float _quantitade {get;}
        private int _opcao {get;}
        public Pedido(int opcao, float quantitade) 
        {
            _opcao = opcao;
            _quantitade = quantitade;

               
        }
        public float[] PedidoCodigo {get => new float[] {
                4.00f,
                4.50f,
                5.00f,
                2.00f,
                1.50f
        };}

        public float ValorFinal 
        { get 
            {
                switch(_opcao)
                {
                    case 1:
                        return CalcularPrecoFinal(_quantitade, PedidoCodigo[0]);
                    case 2:
                        return CalcularPrecoFinal(_quantitade, PedidoCodigo[1]);
                    case 3:
                        return CalcularPrecoFinal(_quantitade, PedidoCodigo[2]);
                    case 4:
                        return CalcularPrecoFinal(_quantitade, PedidoCodigo[3]);
                    case 5:
                        return CalcularPrecoFinal(_quantitade, PedidoCodigo[4]);
                    default:
                        return 0.0f;
                }
            }
        }
        public static float CalcularPrecoFinal(float quantidade, float preco) 
        {
            float precoFinal = preco * quantidade;

            return precoFinal;
        }

    }
}