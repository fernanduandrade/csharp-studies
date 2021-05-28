using System;
using System.Collections.Generic;
using System.IO;

namespace OOP
{
    public class NamedObjected{
        public NamedObjected(string name)
        {
            Name = name;
        }
        public string Name { get; set;}
    } 
    
        public abstract class Book : NamedObjected, IBook
        {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    
    public interface IBook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
    }
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            grades = new List<double>();
        } 
        public override void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            else {
                throw new ArgumentException($"passou dos 100 {nameof(grade)}");
            }
            
        }
        public class DiskBook : Book
        {
            public DiskBook(string name) : base(name)
            {
            }

            public override void AddGrade(double grade)
            {
                using(var writer = File.AppendText($"{Name}.txt"))
                {
                    writer.WriteLine(grade);
                   

                }
                
            }

            public override Statistics GetStatistics()
            {
                Statistics result = new Statistics();
                using(var reader = File.OpenText($"{Name}.txt"))
                {
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        var number = Double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
                return result;
            }
        }
        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();


            foreach(var grade in grades)
            {
                result.Add(grade);
                
            }
            return result;
        }

        private List<double> grades;
    }
}