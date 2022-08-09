using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
	class MarsRoverPosition
	{
		public int XAxis { get; set; }
		public int YAxis { get; set; }
		public RoverDirections Direction { get; set; }
		public MarsRoverPosition() // Constructor sinifi
		{
			XAxis = YAxis = 0;
			Direction = RoverDirections.N;
		}
		private void SameDirection()//Ayni Dogrultuda Ilerleme Durumu
		{
			switch (this.Direction)
			{
				case RoverDirections.N:// Kuzey yonunde ise y ekseni degeri arttirilir
					this.YAxis += 1;
					break;
				case RoverDirections.W:// Bati yonunde ise x ekseni degeri azaltilir
					this.XAxis -= 1;
					break;
				case RoverDirections.E:// Dogu yonunde ise x ekseni degeri arttirilir
					this.XAxis += 1;
					break;
				case RoverDirections.S:// Guney yonunde ise y ekseni degeri azaltilir
					this.YAxis -= 1;
					break;
				default:
					break;
			}
		}
		private void RotateRight()//Saga Donme Durumu
		{
			switch (this.Direction)
			{
				case RoverDirections.N: // Kuzey yonunde ise Direction E(dogu) değerini alir
					this.Direction = RoverDirections.E;
					break;
				case RoverDirections.W: // Bati yonunde ise Direction N(kuzey) değerini alir
					this.Direction = RoverDirections.N;
					break;
				case RoverDirections.E: // Dogu yonunde ise Direction S(guney) değerini alir
					this.Direction = RoverDirections.S;
					break;
				case RoverDirections.S: // Guney yonunde ise Direction W(bati) değerini alir
					this.Direction = RoverDirections.W;
					break;
				default:
					break;
			}
		}
		private void RotateLeft()//Sola Donme Durumu
		{
			switch (this.Direction)
			{
				case RoverDirections.N: // Kuzey yonunde ise Direction W(bati) değerini alir
					this.Direction = RoverDirections.W;
					break;
				case RoverDirections.W: // Bati yonunde ise Direction S(guney) değerini alir
					this.Direction = RoverDirections.S;
					break;
				case RoverDirections.E: // Dogu yonunde ise Direction N(kuzey) değerini alir
					this.Direction = RoverDirections.N;
					break;
				case RoverDirections.S: // Guney yonunde ise Direction E(dogu) değerini alir
					this.Direction = RoverDirections.E;
					break;
				default:
					break;
			}
		}
		public void Moving(List<int> MaxPoints, string Moves)
		{
			foreach (var move in Moves)
			{
				switch (move) // Console dan girilen degerlere gore hareket fonksiyonları cagirilir
				{
					case 'M': // Ayni dogrultuda ilerleme
						this.SameDirection();
						break;
					case 'L': // Sola donme
						this.RotateLeft();
						break;
					case 'R': // Saga donme
						this.RotateRight();
						break;
					default: // Gecersiz karakter girilmesi durumu
						Console.WriteLine(move + " is The Invalid Character ");
						break;
				}
				if (this.XAxis < 0 || this.XAxis > MaxPoints[0] || this.YAxis < 0 || this.YAxis > MaxPoints[1]) // X ve Y eksen degerlerinin maksimum eksen degerlerini asip asmadigi yada sifidan kücük olup olmadigi kontrol edilir
				{
					throw new Exception("Position must be between (0,0) and (" + MaxPoints[0] + "," + MaxPoints[1] + ") !");
				}
			}
		}
	}
}
