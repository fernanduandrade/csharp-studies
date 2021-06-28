using System;

namespace EstruturaRepeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            int alcool = 0;
            int gasolina = 0;
            int dissel = 0;

            int input = int.Parse(Console.ReadLine());

            while(input != 4)
            {
                if(input == 1) alcool += 1;
                if(input == 2) gasolina += 1;
                if(input == 3) dissel += 1;

                input = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Muito Obrigado!");
            Console.WriteLine($"Alcool: {alcool}");
            Console.WriteLine($"Gasolina:  {gasolina}");
            Console.WriteLine($"Dissel: {dissel}");

            
        }
    }
}
