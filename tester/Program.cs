/*Program name: Worksheet 4 Part 1 : 
  Author      : Therese Hume
  Date        : Updated Feb 2025
  Purpose     : Data validation and tax calculation - simple version
                Could we improve this????
*/
using Microsoft.Win32.SafeHandles;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string employee;
            double hoursWorked;
            double payRate;

            Console.WriteLine("Please enter Employee Number:");
            employee = Console.ReadLine();
            while (!IsValidEmployeeNumber(employee)) 
            {
                Console.WriteLine("Invalid Employee Number- Please re-enter:");
                employee = Console.ReadLine();
            }
   
            Console.WriteLine("Please enter hours worked:");
            string input = Console.ReadLine();

            while ((hoursWorked = ParseValidHours(input)) == -1)
            {
                Console.WriteLine("Invalid hours (should be between 10 and 50) - Please re-enter:");
                input = Console.ReadLine();

            }
            Console.WriteLine("Please enter pay rate:");
            input = Console.ReadLine();
            while ((payRate = ParseValidHours(input)) == -1)
            {
                Console.WriteLine("Invalid pay rate (should be between 10 and 65) - Please re-enter:");
                input = Console.ReadLine();

            }

            decimal pay = (decimal) (hoursWorked * payRate)*52;
            decimal tax = CalculateTax(pay);
            Console.WriteLine($"Pay: {pay:C}   Tax: {tax:C}   Net: {pay - tax:C}");

        }
/// <summary>
/// Calculates tax for a payrate following a set tax regime (0 under 3000, 20% up until 34000, 40% above that).
/// </summary>
/// <param name="pay"></param>
/// <returns>tax due </returns>
        public static decimal CalculateTax(decimal pay) 
        { 
            decimal tax = 0;

        if(pay<3000m)
            {
                tax = 0;
            }
         else if (pay < 34000)
            {
                tax = ((pay - 3000) * (20m/100m));
            }
            else
            {
                tax = ((pay-34000) * (40m / 100m)) + 31000 * (20m / 100m);
            }

            return tax;
        }
        static bool IsValidEmployeeNumber(string employeeNumber)
        {
            if ((employeeNumber == null) 
                ||(employeeNumber.Length != 6) 
                ||(employeeNumber[0] != 'E'))
            {

                return false;

            }
            for (int i = 1; i < employeeNumber.Length; i++) // Note you could use TryParse with substring here..
            {
                if (!char.IsDigit(employeeNumber[i]))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Parses hours worked from a string.
        /// </summary>
        /// <param name="hours" the string input for the payrate></param>
        /// <returns> -1 if the payrate is invalid, the hours worked otherwise <returns>
        static double ParseValidHours(string hoursInput)
        {
            double hoursWorked=-1;
            if ((hoursInput == null)
                || !double.TryParse(hoursInput, out hoursWorked)   
                || (hoursWorked > 50)
                || (hoursWorked < 10))
            {
                
                return -1;

            }          
            return hoursWorked;
        }
/// <summary>
/// Parses a payrate from a string.
/// </summary>
/// <param name="payRateInput" the string input for the payrate></param>
/// <returns> -1 if the payrate is invalid, the pay rate otherwise <returns>
        static double ParseValidPayRate(string payRateInput)
        {
            double payRate;
            if ((payRateInput == null)
                || !double.TryParse(payRateInput, out payRate)
                || (payRate > 65)
                || (payRate < 10))
            {
                return -1;

            }
            return payRate;
        }

    }
}