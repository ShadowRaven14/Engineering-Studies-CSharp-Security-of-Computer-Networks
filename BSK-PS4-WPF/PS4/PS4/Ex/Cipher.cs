using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4.Ex
{
    class Cipher
    {
        private string BitString;
        private string Taps;
        private string Repeat;
        public List<int> key;
        public List<int> seed;
        
        public Cipher(string BitString, string Taps)
        {
            this.BitString = BitString;
            this.Taps = Taps;
            Repeat = BitString;
            
        }
        public string Encrypt()
        {
            string temp = Repeat.ToString();
            LFSR LFSR = new(temp, Taps);
            key = LFSR.Generate();
            seed = LFSR.GetRandoms();
            int[] bitStringsInts = LFSR.ToArray(BitString);
            int[] resultInts = new int[BitString.Length];

            for (int i = 0; i < BitString.Length; i++)
            {
                int xor = key[i] ^ bitStringsInts[i];
                resultInts[i] = xor;
            }

            return string.Join("", resultInts);
        }
    }
}
