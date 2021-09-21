using System;
using System.IO;
using LeitorDeProdutos.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LeitorDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caminho do arquivo");
            string path = Console.ReadLine();

            List<Product> list = new List<Product>();

            using(StreamReader sr = File.OpenText(path)) {
                while(!sr.EndOfStream) {
                    string[] fields = sr.ReadLine().Split(',');
                    string productName = fields[0];
                    double productPrice = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(productName, productPrice));
                }
            }

            var avg = list.Select(product => product.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine($"Preço médio {avg.ToString("F2", CultureInfo.InvariantCulture)}");
        
            var names = list
                .Where(product => product.Price < avg)
                .OrderByDescending(p => p.Name)
                .Select(p => p.Name);


            foreach(string name in names) {
                Console.Write(name);
            }
        }
    }
}
