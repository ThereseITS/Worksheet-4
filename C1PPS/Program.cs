/*Program name: Worksheet 4 Part 3 : 
  Author      : Therese Hume
  Date        : Updated Feb 2025
  Purpose     : Demonstrate a  method to validate PPS numbers*/
using System.Text.RegularExpressions;

namespace C1PPS
{
    using static System.Console;
    internal class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine(IsValidPPSN("3111350W "));//true
            Console.WriteLine(IsValidPPSN("1234567A"));//false
            Console.WriteLine(IsValidPPSN("1234567t"));//true
            Console.WriteLine(IsValidPPSN("1234567"));//false
            Console.WriteLine(IsValidPPSN("123456A7"));//false
            Console.WriteLine(IsValidPPSN("123456AT"));//false
            Console.WriteLine(IsValidPPSN("123456A"));//false
            
        }
        

        /// <summary>
        /// This method checks a PPS number and returns true if valid, false otherwise. 
        /// </summary>
        /// <param name="pps"></param>
        /// <returns>bool</returns>
        static bool IsValidPPSN(string pps)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int num = 0;
           
            pps = pps.TrimEnd().ToUpper();

         /*   Regex r = new Regex("[0-9]{7}[A-Z]{1,2}");   Alternative way of checking format using regular expressions   
            if (!r.IsMatch(pps)) { return false; }*/

            if ((pps != null) 
                && ((pps.Length == 8) || (pps.Length == 9))
                && int.TryParse(pps.Substring(0,7), out num))// Check format: ensure not null, correct length, and starts with 7 digits
            {
                int checkSum = SumWeightedValues(pps);

                if ((pps.Length == 9) && (pps[8] != 'W') && (pps[8] != ' ')) // extra weighted position 9
                {
                    checkSum += (alphabet.IndexOf(pps[8]) + 1) * 9;
                }

                int index = (checkSum % 23) - 1;

              
                if (((index == -1) && (pps[7] == 'W')) 
                 || ((index >= 0) && (index < 26) && (pps[7] == alphabet[index])))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get the sum of the weighted values for the checksum of a PPS number
        /// </summary>
        /// <param name="pps"></param>
        /// <returns></returns>
        static int SumWeightedValues(string pps)
        {
            int checkSum = 0;
            int weighting = 8;

           for (int i = 0; i <= 6; i++)
            {
                int num = (int) Char.GetNumericValue(pps[i]);

                // Ensures that all the characters are numeric, and if not return an error code of -1

               
               checkSum += num * weighting;
                               
                weighting--;
            }

            return checkSum;
        }
        
    }

}