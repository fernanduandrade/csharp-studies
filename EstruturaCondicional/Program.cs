using System;

namespace EstruturaCondicional
{
    class Program
    {
        static void Main(string[] args)
        {
            BemVindo.Intro();

            float quantidade = float.Parse(Console.ReadLine());
            int opcao = int.Parse(Console.ReadLine());

            Pedido pedido = new Pedido(opcao, quantidade);

            Console.WriteLine($"Total: R$ {pedido.ValorFinal:N2}");
        }
    }
}
