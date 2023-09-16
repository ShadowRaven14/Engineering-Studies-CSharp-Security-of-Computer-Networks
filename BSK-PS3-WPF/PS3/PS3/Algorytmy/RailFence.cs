using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS3.Algorytmy
{
    class RailFence
    {
        private string word; //wyraz czytany
        private int x; //klucz

        //Konstrukror bezparametrowy
        public RailFence(string word, int x)
        {
            this.word = word.Replace(" ", "");
            this.x = x;
        }

        //Kodowanie
        public string Encrypt()
        {
            string outcome = "";
            int col = 0, row = 0;
            bool temp = false;
            char[,] tab = new char[x, word.Length];
            for(int i=0;i<word.Length;i++)
            {
                if(row==0 || row==x-1)
                {
                    temp = !temp;
                }
                tab[row, col++] = word[i];
                if(temp==true)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }
            for(int i=0;i<x;i++)
            {
                for(int j=0;j<word.Length;j++)
                {
                    if(tab[i,j]!='\0')
                    {
                        outcome += tab[i, j];
                    }
                }
            }
            return outcome;
        }


        //Dekodowanie
        public string Decrypt()
        {
            string outcome = "";
            int row = 0, col = 0, id = 0;
            bool temp = false;
            char[,] tab = new char[x, word.Length];
            for (int i=0;i<word.Length;i++)
            {
                if (row==0)
                {
                    temp = true;
                }
                else if (row==x-1)
                {
                    temp = false;
                } 
                tab[row, col++] = '*';

                if (temp==true)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }
            for (int i=0;i<x;i++)
            {
                for (int j=0;j<word.Length;j++)
                {
                    if (tab[i, j]=='*' && id<word.Length)
                    {
                        tab[i, j] = word[id++];
                    }
                }
            }
            row = 0; col = 0;
            for (int i=0;i<word.Length;i++)
            {
                if (row==0)
                {
                    temp = true;
                }
                else if (row==x-1)
                {
                    temp = false;
                }

                if (tab[row, col]!='\0')
                {
                    outcome += tab[row, col++];
                }

                if (temp==true)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }
            return outcome;
        }

    }
}
