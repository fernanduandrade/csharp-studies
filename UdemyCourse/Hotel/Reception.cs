using System;
using System.Linq;

namespace Hotel
{
    public static class Reception
    {
        public static void FillRooms(Rooms[] rooms)
        {
            Console.Write("How many rooms will be rented? ");
            int answer = int.Parse(Console.ReadLine());

            // Preencher os quartos baseado na quantidade inicial informada
            for(int i = 0; i < answer; i ++) 
            {
                Console.WriteLine($"Rent #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
            
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Room: ");    
                int roomNumber = int.Parse(Console.ReadLine());
                rooms[roomNumber-1].Name = name;
                rooms[roomNumber-1].Email = email;
                rooms[roomNumber-1].Code = roomNumber;
                Console.WriteLine();            
            }
        }
        public static void ShowBusyRooms(Rooms[] rooms)
        {
            Console.WriteLine($"Busy rooms:");

            // Verificar se um quarto foi atribuido um valor
            // Se possuir um valor diferente de 0 então o quarto está ocupado
            foreach(Rooms room in rooms.Where(q => q.Code != 0)) 
            {
                Console.WriteLine($"{room.Code}: {room.Name}, {room.Email}");
            }
        }
    }
}