using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book();
            book.AddGrade(20.4);
            book.AddGrade(21.4);
            book.AddGrade(22.4);
            book.ShowStatistics();
        }
    }
}
