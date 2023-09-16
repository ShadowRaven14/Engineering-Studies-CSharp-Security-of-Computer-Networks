using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3.Algorytmy
{
    class Macierzowe2a
    {
        private string M; //słowo do kodowania/ dekodowania
        private string key; //słowo klucz
        private int il = 0; //ilość kolumn macierzy
        private string result = ""; //rezultat kodowania
        private string result2 = ""; //rezultat dekodowania
        private List<int> order = new List<int>(); //tablica inicjatyw
        private List<string> Mtab = new List<string>(); //zawartość kolumn kodowania
        private List<string> Mtab2 = new List<string>(); //zawartość kolumn dekodowania

        //Konstrukror bezparametrowy
        public Macierzowe2a(string M, string key)
        {
            this.M = M.Replace(" ", "");
            this.key = key;
            order = Order();
            Mtab = Matching();
        }

        //Odczytywanie klucza
        public List<int> Order()
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (((int)key[i] >= 48
                && (int)key[i] <= 57)
                || (int)key[i] == 240)

                    if (key[i] != '-')
                        order.Add((int)key[i] - 48);
            }

            foreach (int o in order) il++;
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

            for (int i = 0; i < il; i++)
            {
                Mtab.Add("");
            }
            for (int i = 0; i < M.Length; i = i + il)
            {
                for (int y = 0; y < il; y++)
                {
                    if (M.Length > (i + y))
                    {
                        Mtab[y] = Mtab[y] + M[i + y];
                    }

                }
            }

            /*Order();
            Matching();*/
            //var order = key.Split('-').Select(Int32.Parse).ToArray();
            for (int i = 0; i < il; i++)
            {
                foreach (int o in order)
                {
                    if (Mtab[o - 1].Length > i)
                        result = result + Mtab[o - 1][i];
                }
            }
            Mtab.Clear();
            return result;
        }

        //Dekodowanie
        public string Decrypt()
        {
            /*Order();
            Matching();*/
            result = M;
            //var order = key.Split('-').Select(Int32.Parse).ToArray();
            for (int i = 0; i < il; i++) Mtab2.Add("");

            for (int i = 0; i < result.Length; i = i + 0)
            {
                foreach (int o in order)
                {
                    if (result.Length > i)
                    {
                        if (result.Length % il < o && i + il > result.Length)
                            Mtab2[o - 1] = Mtab2[o - 1] + "";
                        else
                        {
                            Mtab2[o - 1] = Mtab2[o - 1] + result[i];
                            i++;
                        }
                    }
                }
            }

            string result2 = "";
            for (int i = 0; i < result.Length; i++)
            {
                foreach (string z in Mtab2)
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
