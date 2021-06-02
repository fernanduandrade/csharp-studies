using System;

namespace CalcularPecas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo, digite a quantidade de peças número 1: ");
            float peca1Quantidade = float.Parse(Console.ReadLine());

            Console.WriteLine("Agora digite o valor individual da peça número 1: ");
            float peca1Preco = float.Parse(Console.ReadLine());
            Console.WriteLine(peca1Preco);

            Console.WriteLine("Digite agora a quantidade de peças número 2: ");
            float peca2Quantidade = float.Parse(Console.ReadLine());

            Console.WriteLine("Agora digite o valor individual da peça número 2: ");
            float peca2Preco = float.Parse(Console.ReadLine());

            float resultado = peca1Quantidade * peca1Preco  + peca2Quantidade * peca2Preco;

            Console.WriteLine();
            
            Console.WriteLine($"VALOR A PAGAR: R$ {resultado:N2}");

        
        }
    }
}
