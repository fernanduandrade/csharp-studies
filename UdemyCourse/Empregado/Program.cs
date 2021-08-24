using System;
using System.Collections.Generic;
using Course.Entities;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empregado> empregado = new List<Empregado>();
            Console.Write("Entre com o número de empregados: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Empregado #{i} dados: ");
                Console.Write("Tercerizado (s/n)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Horas: ");
                int horas = int.Parse(Console.ReadLine());

                Console.Write("Valor por hora: ");
                double valorPH = double.Parse(Console.ReadLine());

                if (ch == 's') {
                    Console.Write("Valor adicional: ");
                    double valorAdicional = double.Parse(Console.ReadLine());
                    empregado.Add(new Tercerizado(nome, horas, valorPH, valorAdicional));
                }
                else
                {
                    empregado.Add(new Empregado(nome, horas, valorPH));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pagamentos");

            foreach (Empregado emp in empregado) {
                Console.WriteLine(emp.Nome + " - $ " + emp.Pagamento().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
