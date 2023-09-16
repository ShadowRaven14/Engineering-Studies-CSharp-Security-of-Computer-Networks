using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BSK4___Console
{
    class Program
    {
		public class LFSR_Line
		{
			
			public List<int> Line; //pojedyncza linia
			public int xor { get; set; } //wynik xor

			public LFSR_Line()
			{
				Line = new List<int>();
				xor = -1;
			}

			public int XOR_Method(int x, int y)
			{
				if (x == 0 && y == 0) return 0;
				if (x == 1 && y == 0) return 1;
				if (x == 0 && y == 1) return 1;
				if (x == 1 && y == 1) return 0;
				return -1;
			}
		}


		public static void Main() //public class LFSR_Algorytm
		{

			//POBRANIE DANYCH OD UŻYTKOWNIKA
			string Taps = "1+x^1+x^3+x^5"; //wczytywane z textbox
			int Repeat = 5; //licznik, ile razy ma wykonać się algorytm

			//DANE TWORZONE PRZEZ PROGRAM
			var rand = new Random(); //Losowanie liczb startowych
			int numcol = -1; //ilosc kolumn, tworzone odczytując M
			List<int> Order = new List<int>(); //tablica inicjatyw, , tworzone odczytując M
			LFSR_Line NewLineObject = new LFSR_Line(); //Obiekt pojedynczej linii
			List<int> LFSR_Result = new List<int>(); //Wynikowa lista LFSR!!!

			//ODCZYTYWANIE KLUCZA
			//Czytanie klucza
			Console.WriteLine("");
			Console.WriteLine("Ordering...");
			for (int i = 0; i < Taps.Length; i++)
			{
				//Szukamy znaku x
				if (Taps[i] == 'x'|| Taps[i] == 'X')
				{
					if (((int)Taps[i+2] >= 48 && (int)Taps[i+2] <= 57))
                    {
						Order.Add((int)Taps[i + 2] - 48); //zapisujemy liczbę potęgi przy x'ie
						Console.WriteLine((int)Taps[i + 2] - 48);
					}
				}
			}

			foreach(int o in Order)
            {
				if (numcol < o) numcol = o;
            }
			Console.WriteLine(numcol + " numcol");

			//WYGENEROWANIE PIERWSZEJ LINII
			Console.WriteLine("");
			Console.WriteLine("Preparing...");
			for (int i = 0; i < numcol; i++)
            {
				NewLineObject.Line.Add(rand.Next(2));
				Console.WriteLine(NewLineObject.Line[i]);
			}


			Console.WriteLine("");
			Console.WriteLine("LOOPing...");
			for (int c = 0; c<Repeat; c++)
            {
				Console.WriteLine("");
				Console.WriteLine("XORing...");
				int x = NewLineObject.Line[Order[0] - 1]; 
				int y = NewLineObject.Line[Order[1] - 1];
				//Console.WriteLine("XOR=" + x + "+" + y);
				//Console.WriteLine("Gdzie" + x + "=" + Order[0]);
				//Console.WriteLine("Gdzie" + x + "=" + Order[1]);
				//x = NewLineObject.XOR_Method(x, y);
				//Console.WriteLine(Order.Count);
				for (int i=1; i<Order.Count; i++)
                {
					y = NewLineObject.Line[Order[i] - 1];
					Console.WriteLine("XOR = "+x+"+"+y);
					//Console.WriteLine("Gdzie " + x + "=" + Order[i-1]);
					//Console.WriteLine("Gdzie " + x + "=" + Order[i]);
					x = NewLineObject.XOR_Method(x, y);
					Console.WriteLine(x);
				}
				NewLineObject.xor = x;
				//NewLineObject.XOR_Method(NewLineObject.Line[0], NewLineObject.Line[3]);
				//Console.WriteLine(NewLineObject.xor);
				LFSR_Result.Add(NewLineObject.Line[numcol - 1]); //dodajemy nowy wynik równy najmłodszemu bitowi

				Console.WriteLine("");
				Console.WriteLine("Creating new NewLineObject ...");
				for (int i = numcol - 1; i > 0; i--) //Patrzymy na linię od końca
					NewLineObject.Line[i] = NewLineObject.Line[i - 1]; //Zmieniamy obecny obiekt NewLineObject
				NewLineObject.Line[0] = NewLineObject.xor; //ustawiamy najstarszy bit na xor

				
				for (int i = 0; i < numcol; i++)
					Console.WriteLine(NewLineObject.Line[i]);
				Console.WriteLine(LFSR_Result[c] + " result");
			}

			Console.WriteLine("");
			Console.WriteLine("Show LFSR_Result...");
			foreach (int i in LFSR_Result)
			{
				Console.WriteLine(i);
			}

		}
	}
}
