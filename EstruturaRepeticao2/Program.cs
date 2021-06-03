using System;

namespace EstruturaRepeticao2
{
    class Program
    {
        static void Main(string[] args)
        {
            int inArray = 0;
            int outArray = 0;

            for(int i = 0; i < args.Length; i++) 
            {
                if(int.Parse(args[i]) >=10 && int.Parse(args[i]) <=20)
                {
                    inArray++;
                }
                else 
                {
                    outArray++;
                }
            }

            Console.WriteLine($"{inArray} in, {outArray} out");
        }
    }
}
