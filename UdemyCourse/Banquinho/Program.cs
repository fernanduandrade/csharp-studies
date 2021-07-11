using System;

namespace Banquinho
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Write("Entre o número da conta: ");
            int codeValue = int.Parse(Console.ReadLine());

            Console.Write("Entre o titular da conta: ");
            string nameValue = Console.ReadLine();
            
            Console.Write("Haverá depísto inicial (s/n)? ");
            string resposta = Console.ReadLine();

            Account account = new Account(codeValue, nameValue);
            if(resposta == "s") {
                Console.Write("Entre o valor de depósito inicial: ");
                double value = double.Parse(Console.ReadLine());
                account.Balance += value;

            }

            Console.WriteLine($"{account}");

            account.Deposit();

            account.WithDraw();

        }
    }
}
