using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Teste");
            book.AddGrade(10.0);
            book.AddGrade(12.0);
            book.AddGrade(11.0);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.Max}");
            Console.WriteLine($"The average grade is {stats.Average}");
        }
    }
}
