using System;

namespace OOP
{
    public class Statistics
    {

        public double Average { get => Sum / Count; }
        public double Low;
        public double Max;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    case var d when d >= 50.0:
                        return 'E';
                    default:
                        return 'F';
                }

                
            }
        }
        public int Count;
        public double Sum;


        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            Max = double.MinValue;
            Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Max = Math.Max(number, Max);
            Low = Math.Min(number, Low);
        }
    }
}