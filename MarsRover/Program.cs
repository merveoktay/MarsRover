using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverPosition position = new MarsRoverPosition(); // MarsRoverPosition sinifindan nesne olusturulur 

            var MaxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList(); // Maksimum eksen degerleri bosluklar temizlenerek alinir 

            var startPositions = Console.ReadLine().Trim().Split(' '); // Baslangic eksen degerleri bosluklar temizlenerek alinir

            var Moves = Console.ReadLine().ToUpper(); // Yon degerleri alinir 

            if (startPositions.Count() == 3)
            {
                position.XAxis = Convert.ToInt32(startPositions[0]);
                position.YAxis = Convert.ToInt32(startPositions[1]);
                position.Direction = (RoverDirections)Enum.Parse(typeof(RoverDirections), startPositions[2]);
            }

            try
            {
                position.Moving(MaxPoints, Moves); // Console dan alinan yon degerleri Moving fonksiyonuna gonderilerek son pozisyon degeri hesaplanir
                Console.WriteLine(position.XAxis + " " + position.YAxis + " " + position.Direction.ToString()); // Son pozisyon degerleri yazdirilir
            }
            catch (Exception ex) // Hata olmasi durumunda catch bloguna yakalanip hata mesaji verir
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
