using System;
using System.Numerics;

namespace PasswordGenerator
{
    class Program
    {
        public static void Main()
        {
            Console.Write($"Enter a start key (from 0 to {UInt64.MaxValue}): ");
            ulong keyValue = UInt64.Parse(Console.ReadLine());
            
            Console.Write($"Select pattern:" +
                          $"\n\t[1] - \"0123456789abcdefghijklmnopqrstuvwxyz\" (default)" +
                          $"\n\t[2] - \"0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHUJKLMNOPQRSTUVWXYZ\"" +
                          $"\n\t[3] - Custom pattern\n");

            string pattern = "0123456789abcdefghijklmnopqrstuvwxyz";
            
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                pattern = "0123456789abcdefghijklmnopqrstuvwxyz";
            }
            else if (choice == "2")
            {
                pattern = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHUJKLMNOPQRSTUVWXYZ";
            }
            else if (choice == "3")
            {
                Console.Write("Enter custom pattern: ");
                pattern = Console.ReadLine();
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                Console.WriteLine(NumberToString(keyValue, pattern));
                keyValue += 1;
            }
        }

        public static string NumberToString(ulong value, string chars)
        {
            string result = "";
            ulong targetBase = UInt64.Parse(chars.Length.ToString());

            do
            {
                int index = Int32.Parse((value % targetBase).ToString());
                result = chars[index] + result;
                value /= targetBase;
            }
            while (value > 0);

            return result;
        }
    }
}