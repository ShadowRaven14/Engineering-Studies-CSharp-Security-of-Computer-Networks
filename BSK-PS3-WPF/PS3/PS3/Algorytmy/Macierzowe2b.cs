using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3.Algorytmy
{
    //Klasa liter klucza
    public class Letter
    {
        public int seq { get; set; } // pozycja w wyrazie
        public int value { get; set; } //wartośc litery w ascii -64
        public Letter()
        {
            seq = -1;
            value = -1;
        }
    }
    class Macierzowe2b
    {

        private string M; //słowo do kodowania/ dekodowania
        private string key; //słowo klucz
        private int il; //ilość kolumn macierzy
        private string result = ""; //rezultat kodowania
        private string result2 = ""; //rezultat dekodowania
        private List<int> order = new List<int>(); //tablica inicjatyw
        private List<string> Mtab = new List<string>(); //zawartość kolumn kodowania
        private List<string> Mtab2 = new List<string>(); //zawartość kolumn dekodowania

        //Konstrukror bezparametrowy
        public Macierzowe2b(string M, string key)
        {
            this.M = M;
            this.key = key;
            il = key.Length;
            order = Order();
            Mtab = Matching();
        }


        //Odczytanie klucza
        public List<int> Order()
        {
            List<Letter> order2 = new List<Letter>();
            for (int i = 0; i < key.Length; i++)
            {
                Letter l = new Letter();
                if (((int)key[i] >= 65
                && (int)key[i] <= 90))
                {
                    l.value = (int)key[i] - 64;
                    l.seq = i + 1;
                    order2.Add(l);
                }
            }
            order2.Sort(delegate (Letter p1, Letter p2)
            {
                return p1.value.CompareTo(p2.value);
            });
            for (int i = 0; i < key.Length; i++)
            {
                order.Add(0);
                order2[i].value = i + 1;
            }

            for (int i = 0; i < key.Length; i++)
            {
                order[order2[i].seq - 1] = order2[i].value;
            }
            return order;
        }

        //Przygotowanie kodowania
        public List<string> Matching()
        {  
            return Mtab;
        }

        //Kodowanie
        public string Encrypt()
        {
            for (int i = 0; i < il; i++) Mtab.Add("");
            for (int i = 0; i < M.Length; i = i + il)
            {
                for (int y = 0; y < il; y++)
                {
                    if (M.Length > (i + y))
                    {
                        if ((int)M[i + y] == 32) i++;
                        string x = Mtab[y] + M[i + y];
                        Mtab[y] = x;
                    }
                }
            }


            List<string> Mtemp = new List<string>();
            for (int i = 0; i < il; i++) Mtemp.Add("");
            for (int i = 0; i < il; i++)
            {
                Mtemp[order[i] - 1] = Mtab[i];
            }

            foreach (string z in Mtemp)
            {
                result = result + z + " ";
            }

            Mtab.Clear();
            return result;
        }

        //Dekodowanie
        public string Decrypt()
        {
            result = M;
            //List<string> Mtab2 = new List<string>();
            List<string> Mtemp2 = new List<string>();
            int u = 0;
            for (int i = 0; i < il; i++) Mtab2.Add("");
            for (int i = 0; i < il; i++) Mtemp2.Add("");
            for (int i = 0; i < result.Length; i++)
            {
                if ((int)result[i] == 32) { u++; i++; }
                if (u < il) Mtab2[u] = Mtab2[u] + result[i];
            }

            for (int i = 0; i < il; i++)
            {
                Mtemp2[i] = Mtab2[order[i] - 1];
            }

            
            for (int i = 0; i < result.Length; i++)
            {
                foreach (string z in Mtemp2)
                {
                    if (z.Length > i)
                        result2 = result2 + z[i];
                }
            }

            Mtab2.Clear();
            return result2;
        }
    }
}
