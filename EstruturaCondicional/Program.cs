using System;

namespace EstruturaCondicional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a quantidade e após o número do pedido");
            Console.WriteLine("1 - Cachorro Quente, valor da unidade R$ 4,00");
            Console.WriteLine("2 - X-Salada, valor da unidade R$ 4,50");
            Console.WriteLine("3 - X-Bacon, valor da unidade R$ 5,00");
            Console.WriteLine("4 - Torrada Simples, valor da unidade R$ 2,00");
            Console.WriteLine("5 - Refrigerante, valor da unidade R$ 1,50");
            float quantidade = float.Parse(Console.ReadLine());
            int opcao = int.Parse(Console.ReadLine());
            float[] precos = new float[] {
                4.00f,
                4.50f,
                5.00f,
                2.00f,
                1.50f
            };
            
            switch(opcao)
            {
                case 1:
                    float precoFinal1 =  quantidade * precos[0];
                    Console.WriteLine($"Total: R$ {precoFinal1:N2}");
                    break;
                case 2:
                    float precoFinal2 =  quantidade * precos[1];
                    Console.WriteLine($"Total: R$ {precoFinal2:N2}");
                    break;
                case 3:
                    float precoFinal3 =  quantidade * precos[2];
                    Console.WriteLine($"Total: R$ {precoFinal3:N2}");
                    break;
                case 4:
                    float precoFinal4 =  quantidade * precos[3];
                    Console.WriteLine($"Total: R$ {precoFinal4:N2}");
                    break;
                case 5:
                    float precoFinal5 =  quantidade * precos[4];
                    Console.WriteLine($"Total: R$ {precoFinal5:N2}");
                    break;
                default:
                    Console.WriteLine("Nada Informado");
                    break;
            }
        }
    }
}
