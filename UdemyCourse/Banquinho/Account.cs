using System;
using System.Globalization;

namespace Banquinho
{
    public class Account
    {
        private int _accountCode {get; set;}
        public string _accountName {get; set;}
        public double Balance {get; set;} = 0;

        public Account(int code, string name)
        {
            _accountCode = code;
            _accountName = name;
        }

        public void Deposit()
        {
            Console.Write("Entre um valor para depósito: ");
            double value = double.Parse(Console.ReadLine());
            Balance += value;
            Console.Write("Dados da conta atualizados: ");
            Console.WriteLine("Conta " + _accountCode + ", Titular: " + _accountName + ", Saldo R$" + Balance.ToString("F2", CultureInfo.InvariantCulture));

        }
        public void WithDraw()
        {
            Console.Write("Entre um valor para depósito: ");
            double value = double.Parse(Console.ReadLine());
            Balance -= value;
            Console.Write("Dados da conta atualizados: ");
            Console.WriteLine("Conta " + _accountCode + ", Titular: " + _accountName + ", Saldo R$" + Balance.ToString("F2", CultureInfo.InvariantCulture));

        }


        public override string ToString()
        {
            return "Conta " + _accountCode + ", Titular: " + _accountName + ", Saldo R$" + Balance.ToString("F2", CultureInfo.InvariantCulture);
        }
    }



}