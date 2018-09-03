using System;
using System.Text;
using System.Threading;

namespace Lapko_LabWork_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(@"Please,  type the number:
1.  f(a,b) = |a-b| (unary)
2.  f(a) = a (binary)
3.  music
4.  morse sos");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                MyStrings();
                                Console.WriteLine();
                                break;
                            case 2:
                                MyBinary();
                                Console.WriteLine();
                                break;
                            case 3:
                                MyMusic();
                                Console.WriteLine();
                                break;
                            case 4:
                                MorseCode();
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error" + e.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region ToFromUnary
        static void MyStrings()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("To from unary");
            Console.ForegroundColor = ConsoleColor.White;

            //Declare int and string variables for decimal and binary presentations
            //Implement two positive integer variables input

            Console.Write("Enter the value 1: ");
            var value1 = GetUIntValueFromConsole();
            if (value1 == null)
            {
                return;
            }

            Console.Write("Enter the value 2: ");
            var value2 = GetUIntValueFromConsole();
            if (value2 == null)
            {
                return;
            }

            //To present each of them in the form of unary string use for loop
            var binaryValue1 = GetBitary((uint)value1);
            var binaryValue2 = GetBitary((uint)value2);

            //Use concatenation of these two strings 
            //Note it is necessary to use some symbol ( for example “#”) to separate

            var result = binaryValue1 + "#" + binaryValue2;

            //Check the numbers on the equality 0
            //Realize the  algorithm for replacing '1#1' to '#' by using the for loop 
            //Delete the '#' from algorithm result

            while (result.IndexOf("1#1") != -1)
            {
                result = result.Replace("1#1", "#");
            }

            var temp = result.Split(new char[] { '#' });
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != "" && uint.Parse(temp[i]) == 0)
                {
                    temp[i] = "";
                }
            }

            //Output the result
            Console.WriteLine($"{value1} - {value2} = {binaryValue1} - {binaryValue2} = {string.Concat(temp)}");
        }
        #endregion

        #region ToFromBinary
        static void MyBinary()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("To from binary");
            Console.ForegroundColor = ConsoleColor.White;

            //Implement positive integer variable input

            Console.Write("Enter the number: ");

            var value = GetUIntValueFromConsole();
            if (value == null)
            {
                return;
            }

            //Present it like binary string
            //   For example, 4 as 100

            Console.WriteLine("{0} = {1}", value, GetBitary((uint)value));
        }

        public static uint? GetUIntValueFromConsole()
        {
            uint value;
            if (!uint.TryParse(Console.ReadLine(), out value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Number must be positive integer!");
                Console.ForegroundColor = ConsoleColor.White;

                return null;
            }

            return value;
        }

        static public string GetBitary(uint value)
        {
            uint hldr;
            var binaryString = new StringBuilder();

            //Use modulus operator to obtain the remainder  (n % 2) 
            //and divide variable by 2 in the loop

            while (value > 0)
            {
                hldr = value % 2;
                binaryString.Append(hldr);
                value = value / 2;
            }

            //Use the ToCharArray() method to transform string to chararray
            //and Array.Reverse() method
            var binaryValue = binaryString.ToString().ToCharArray();
            Array.Reverse(binaryValue);

            return string.Join("", binaryValue);
        }
        #endregion

        #region Morse
        static void MorseCode()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Morse");
            Console.ForegroundColor = ConsoleColor.White;

            //Create string variable for 'sos'
            var SOS = "sos".ToCharArray();

            //Use string array for Morse code
            string[,] Dictionary_arr = new string[,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};
            //Use ToCharArray() method for string to copy charecters to Unicode character array
            //Use foreach loop for character array in which

            //Implement Console.Beep(1000, 250) for '.'
            // and Console.Beep(1000, 750) for '-'

            //Use Thread.Sleep(50) to separate sounds

            var morseString = new StringBuilder();

            for (int i = 0; i < SOS.Length; i++)
            {
                for (int j = 0; j < Dictionary_arr.GetLength(1); j++)
                {
                    if (SOS[i].ToString() == Dictionary_arr[0, j])
                    {
                        morseString.Append(Dictionary_arr[1, j]);
                    }
                }
            }

            var temp = morseString.ToString().ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == '.')
                {
                    Console.Beep(1000, 250);
                }
                else if (temp[i] == '-')
                {
                    Console.Beep(1000, 750);
                }

                Thread.Sleep(50);
            }
        }

        #endregion

        #region MyMusic
        static void MyMusic()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

    }
}
