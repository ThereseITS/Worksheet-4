namespace C1PPS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsAPPSN("1234567TW"));
        }

        static bool IsAPPSN(string pps)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            alphabet= alphabet.ToUpper();
           
            if ((pps.Length == 8) || (pps.Length == 9))
            {
                int checkSum = SumWeightedValues(pps);

                if ((pps.Length == 9) && (pps[8] != 'W') && (pps[8] != ' '))
                {
                    checkSum += (alphabet.IndexOf(pps[8]) + 1) * 9;
                }
                int index = (checkSum%23) - 1;

                if ((index < 26) && (pps[7] == alphabet[index])) 
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Get the sum of the weighted values
        /// </summary>
        /// <param name="pps"></param>
        /// <returns></returns>
        static int SumWeightedValues(string pps)
        {
            int checkSum = 0;
            int weighting = 8;

           for (int i = 0; i <= 6; i++)
            {
                int num = (int)Char.GetNumericValue(pps[i]);
                checkSum += num * weighting;              
                weighting--;
            }

            return checkSum;
        }
        //nine characters in length, consisting of 7 digits in positions 1 to 7, followed by a check character in position 8, with either a space or the letter “W” in position 9
    }
}