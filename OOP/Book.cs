using System;
using System.Collections.Generic;

namespace OOP
{
    public class Book
    {
        public Book(string name)
        {
            _Name = name;
            grades = new List<double>();
        } 
        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else {
                throw new ArgumentException($"passou dos 100 {nameof(grade)}");
            }
            
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

            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                    
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                    
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                case var d when d >= 50.0:
                    result.Letter = 'E';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        private List<double> grades;
        public string _Name {get;set;}
    }
}