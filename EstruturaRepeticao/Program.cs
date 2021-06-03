using System;

namespace EstruturaRepeticao
{
    class Program
    {
        static void Main(string[] args)
        {

            int password = 2002;
            

            
            while (true)
            {
                Console.WriteLine("Digite a senha");
                int passwordInput = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(passwordInput != password)
                {
                    Console.WriteLine("Senha Invalida");
                    Console.WriteLine();
                }
                else 
                {
                    Console.WriteLine("Acesso Permitido");
                    break;
                }
            }
        }
    }
}
