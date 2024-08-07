using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment1
{
    class Exercise5
    {
        public static void Bai5()
        {
            Console.WriteLine("Enter multiple lines of text. Press Ctrl + Z (or Ctrl + D on Unix) to finish typing:");

            List<string> inputLines = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                inputLines.Add(line);
            }

            inputLines.Sort(CompareLinesByDateTime);

            Console.WriteLine("Sorted lines by increasing time:");
            foreach (var sortedLine in inputLines)
            {
                Console.WriteLine(sortedLine);
            }
        }

        static int CompareLinesByDateTime(string line1, string line2)
        {
            DateTime dateTime1 = ExtractDateTime(line1);
            DateTime dateTime2 = ExtractDateTime(line2);

            return DateTime.Compare(dateTime1, dateTime2);
        }

        static DateTime ExtractDateTime(string line)
        {
            string[] dateFormats = { "dd/MM/yyyy", "dd/MM/yyyy hh:mm:ss tt", "dd/MMM/yyyy" };
            string pattern = @"\b\d{2}/\d{2}/\d{4}\b|\b\d{2}/\d{2}/\d{4} \d{2}:\d{2}:\d{2} [APM]{2}\b|\b\d{2}/\w{3}/\d{4}\b";
            Match match = Regex.Match(line, pattern);

            if (match.Success && DateTime.TryParseExact(match.Value, dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                return dateTime;
            }
            else
            {
                return DateTime.MaxValue;
            }
        }
    }
}
