using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter,

            Max,
        }

        public static string[] SeasonStrings = new string[]
        {
            "Spring",
            "Summer",
            "Autumn",
            "Winter",
        };

        static void Main(string[] args)
        {
            int enumMax = (int)Season.Max;
            for (int i = 0; i < 10000; i ++)
            {
                //var enumData = System.Enum.Parse<Season>(SeasonStrings[i % enumMax]);
                var enumData = EnumUtility.EnumParse<Season>(SeasonStrings[i % enumMax]);
            }

            Console.WriteLine("Hello World!");
        }
    }
}