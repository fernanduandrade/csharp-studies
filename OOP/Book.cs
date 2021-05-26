using System;
using System.Collections.Generic;

namespace OOP
{
    public class Book
    {
        public Book(string name)
        {
            _name = name;
            grades = new List<double>();
        } 
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.Average = 0.0;
            result.Max = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades)
            {
                result.Max = Math.Max(grade, result.Max);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;
        }

        private List<double> grades;
        private string _name {get;set;}
    }
}