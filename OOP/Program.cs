using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Teste");
            
            while(true) {
                Console.WriteLine("1 - Digitar uma nota");
                Console.WriteLine("2 - Digite q para sair");
                Console.WriteLine("");
                string opcao = Console.ReadLine();
                
                if(opcao == "1")
                {
                    Console.Write("Digite o valor da nota: ");
                    Console.Write("");
                    double nota = Double.Parse(Console.ReadLine());
                    book.AddGrade(nota);
                }
                else if(opcao == "2")
                {
                    break;
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.Max}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
    }
}
