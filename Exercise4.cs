using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Exercise4
    {
        public static void Bai4()
        {
            Console.Write("Start Date (dd/MM/yyyy): ");
            string? startDateInput = Console.ReadLine();
            if (startDateInput == null || !DateTime.TryParseExact(startDateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDate))
            {
                Console.WriteLine("Invalid date format. Please use dd/MM/yyyy.");
                return;
            }

            Console.Write("Department Name (3 letters): ");
            string? departmentName = Console.ReadLine()?.ToUpper();
            if (departmentName == null || departmentName.Length != 3 || !IsAllLetters(departmentName))
            {
                Console.WriteLine("Invalid department name. Please use exactly 3 letters.");
                return;
            }

            Console.Write("Number of invoices per day: ");
            if (!int.TryParse(Console.ReadLine(), out int invoicesPerDay) || invoicesPerDay <= 0)
            {
                Console.WriteLine("Invalid number of invoices. Please enter a natural number.");
                return;
            }

            Console.Write("Number of days to print invoice: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfDays) || numberOfDays <= 0)
            {
                Console.WriteLine("Invalid number of days. Please enter a natural number.");
                return;
            }

            GenerateInvoices(startDate, departmentName, invoicesPerDay, numberOfDays);
        }

        static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }
            return true;
        }

        static void GenerateInvoices(DateTime startDate, string departmentName, int invoicesPerDay, int numberOfDays)
        {
            int invoiceNumber = 1;

            for (int i = 0; i < numberOfDays; i++)
            {
                DateTime currentDate = startDate.AddDays(i);
                string fiscalYear = GetFiscalYear(currentDate);
                Console.Write($"Invoice Date {currentDate:dd/MM/yyyy}: ");

                for (int j = 0; j < invoicesPerDay; j++)
                {
                    string invoiceCode = $"{departmentName}FY{fiscalYear}{invoiceNumber:D5}";
                    Console.Write(invoiceCode);
                    if (j < invoicesPerDay - 1)
                        Console.Write(", ");
                    invoiceNumber++;
                    if (currentDate.Month == 4 && currentDate.Day == 1)
                    {
                        invoiceNumber = 1;
                    }
                }
                Console.WriteLine();
            }
        }

        static string GetFiscalYear(DateTime date)
        {
            int year = date.Month >= 4 ? date.Year : date.Year - 1;
            return $"{year}";
        }
    }
}
