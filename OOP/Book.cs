using System;
using System.Collections.Generic;

namespace OOP
{
    public class Book
    {
        public Book()
        {
            grades = new List<double>();
        } 
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void ShowStatistics()
        {
            double result = 0.0;
            double highGrade = double.MaxValue;
            double lowGrade = double.MinValue;

            foreach(double number in grades)
            {
                highGrade = Math.Min(number, highGrade);
                lowGrade = Math.Min(number, lowGrade);
                result += number;
            }

            result /= grades.Count;

            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The average grade is {result:N1}");
        }

        private List<double> grades;
    }
}