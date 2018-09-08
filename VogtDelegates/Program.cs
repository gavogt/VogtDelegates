using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VogtDelegates
{
    class Program
    {
        #region Delegates
        public delegate void DisplayRed();
        public delegate void DisplayRedString(string color);
        public delegate T DisplayChange<T>(T color);
        public delegate T DisplayChangeInt<T>(T number);
        #endregion

        static void Main(string[] args)
        {
            DisplayRed changeToRed = new DisplayRed(DisplayRedConsole);
            changeToRed();

            DisplayRedString changeToRedString = new DisplayRedString(DisplayRedConsole);
            changeToRedString("RED");

            DisplayChange<string> changeToMagenta = new DisplayChange<string>(DisplayMagentaConsole<string>);
            DisplayChangeInt<int> changeToBlueInt = new DisplayChangeInt<int>(DisplayBlueConsole);

            changeToMagenta += new DisplayChange<string>(DisplayMagentaConsole);
            //changeToBlueInt += new DisplayChangeInt<int>(DisplayBlueConsole);

            Action<string> changeToBlue = DisplayBlueConsole;
            changeToBlue("I am a blue string!");

            changeToMagenta("I am a magenta string!");

            changeToBlueInt(1337);

        }

        public static void DisplayRedConsole()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Red Warning");
            ConsoleReset();

        }

        public static void DisplayRedConsole(string color)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("This is my string as: " + color);
            ConsoleReset();

        }

        public static string DisplayMagentaConsole(string color)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("This is my string as: " + color);
            ConsoleReset();

            return color;

        }

        public static void DisplayBlueConsole(string color)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Blue Warning");
            ConsoleReset();

        }

        public static int DisplayBlueConsole(int number)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("I am a blue number known as: " + number);
            ConsoleReset();

            return number;

        }

        public static T DisplayMagentaConsole<T>(T color)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("I am now this magenta color! ");
            ConsoleReset();

            return color;

        }

        public static void ConsoleReset()
        {
            Console.ResetColor();

        }


    }
}
