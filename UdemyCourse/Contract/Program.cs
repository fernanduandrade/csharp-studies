using System;
using System.Globalization;

namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            Contrato contrato = new Contrato();

            Console.WriteLine("Insira os dados do contrato");
            Console.Write("Número: ");
            contrato.Numero = int.Parse(Console.ReadLine());
            Console.Write("Data do contrato: ");
            contrato.Data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Valor : ");
            contrato.Valor = float.Parse(Console.ReadLine());
            Console.Write("Quantidade de parcelas: ");
            contrato.Parcelas = int.Parse(Console.ReadLine());
            Console.WriteLine("Resultado das parcelas: ");
            Console.WriteLine("");
            for(int i = 1; i <= contrato.Parcelas; i ++) {
                float parcelaValor = contrato.Valor / contrato.Parcelas; 
                float parcela1 = parcelaValor + (parcelaValor * 0.01f) * i;
                float parcelaTotal = parcela1 + (parcela1 * 0.02f);

                Console.WriteLine($"{contrato.Data.AddMonths(i).ToString("dd/MM/yyyy")} - {parcelaTotal.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}
