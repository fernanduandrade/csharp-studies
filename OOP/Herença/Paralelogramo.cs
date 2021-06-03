using System;

namespace OOP.Herença
{
    public abstract class Paralelogramo
    {
        private int _altura {get; set;}
        private int _largura {get; set;}
        public Paralelogramo(int altura, int largura) 
        {
            _altura = altura;
            _largura = largura;

        }

        public int Area {get => _altura * _largura;}
    }

    public class Quadrado : Paralelogramo
    {
        public Quadrado(int altura, int largura) : base(altura, largura)
        {
            if(altura != largura)
            throw new Exception("Tanto a altura como a largura devem ser iguais");
        }
    }

    public class Retangulo : Paralelogramo
    {
        public Retangulo(int altura, int largura) : base(altura, largura)
        {
            
        }
    }
}