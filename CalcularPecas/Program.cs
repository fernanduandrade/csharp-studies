using System;

namespace CalcularPecas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Passe por argumentos a quantidade e preço das peças 1 e 2  

            float peca1Quantidade = float.Parse(args[0]);
            float peca1Preco = float.Parse(args[1]);   
            float peca2Quantidade = float.Parse(args[2]);
            float peca2Preco = float.Parse(args[3]);   
            float valorTotal = peca1Quantidade * peca1Preco  + peca2Quantidade * peca2Preco;

            Console.WriteLine($"VALOR A PAGAR: R$ {valorTotal:N2}");

        
        }
    }
}
