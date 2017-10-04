using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexTableCreator
{
    class Program
    {
        static string LittleEndian(string num)
        {
            int number = Convert.ToInt32(num, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            return retval;
        }

        static void Main(string[] args)
        {
            Console.Write("Amount? ");
            int amount = int.Parse(Console.ReadLine());

            string[] table = new string[amount];

            Console.Write("Start Offset (08XXXXXX)? ");
            int start = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber);

            Console.Write("Size (Hex)? ");
            int size = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber);

            Console.WriteLine();

            for (int i = 0; i < amount; i++)
            {
                table[i] = LittleEndian((start + i * size).ToString("X8"));
                Console.Write(table[i]);
            }

            Console.ReadLine();
        }
    }
}
