using System.Diagnostics.CodeAnalysis;
/*Program name: Worksheet 4 Part 2 q6-8 : 
  Author      : Therese Hume
  Date        : Updated Feb 2025
  Purpose     : Learning about strings */

namespace Q6To8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = { '&', '%', '$' };

            string text = "$&$$abd%$as&&";

            Console.WriteLine(InsertCharEveryThird("Hello, World!", '-')); 
            Console.WriteLine(InsertCharEveryThird2("abcdefghijkl", '-')) ;   
            Console.WriteLine(InsertCharEveryThird3("Hello, World!", '-'));

            Console.WriteLine(text);
            Console.WriteLine(RemoveChars(text,chars));
            Console.WriteLine(RemoveChars2(text,chars));
            Console.WriteLine(RemoveChars3(text,chars));
            
            
            PrintEveryThirdCharJ(text);

            text = "xy,xy,xy,xy,xy,x,ppp";
   
            foreach (string s in text.Split(',')) 
            { 
                Console.WriteLine(s);
            }

            Console.WriteLine($"The number of x and ys {CountXYs(text)}");

            string[] words = "the sun and the moon and the stars ".Split(" ");
           
            foreach (string s in words)
            {
                Console.WriteLine(s);
            }
            
        }
       
       /// <summary>
       /// q6 Inserts a specified char after every third character. Note that it does this for the last one as well.
       /// </summary>
       /// <param name="text"></param>
       /// <param name="c"></param>
       /// <returns></returns>
        public static string InsertCharEveryThird(string text, char c)
        {
            string newText = "";
            if(text!=null)
            for (int i = 0; i < text.Length; i++)
            {
                newText += text[i];
                if (((i+1) % 3 == 0)&&(i!=0))
                    newText += c.ToString();
            }
           
            return newText;
        }
/// <summary>
/// This version uses substrings.
/// </summary>
/// <param name="text"> the string to insert the chars into</param>
/// <param name="c"> the character to insert</param>
/// <returns> the amended string with the specified char placed after every third letter</returns>
        public static string InsertCharEveryThird2(string text, char c)
        {
            string newText = "";
            int nextPos=0;
            if (text != null)
            {
                for (int i = 0; i < (text.Length - 2); i += 3)
                {
                    newText += text.Substring(i, 3) + c.ToString();
                }
                
                newText += text.Substring(text.Length - text.Length % 3);// add the rest
               
            }
            return newText;
        }
        /// <summary>
        /// This version uses an array of characters- more efficient. See also what you can find out about the StringBuilder class.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string InsertCharEveryThird3(string text, char c)
        {
            string newText;
            char[] letters = text.ToCharArray();
            int extra = text.Length / 3;
            char[] newLetters = new char[extra+text.Length];
            int j= 0;
            if (text != null)
                for (int i = 0; i < (text.Length ); i++)
                {
                    newLetters[j] = text[i];
                    if (((i + 1) % 3 == 0) && (i != 0))
                    {
                        j++;
                        newLetters[j] = c;
                    }
                    j++;
                }
            newText = new string(newLetters);
            return newText;
        }
        /// <summary>
        /// q7 Removes the specified characters from the text string.There are a number of possibilities for this code.
        /// This version uses an array of chars.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charsToRemove"></param>
        /// <returns> new string with specified characters added</returns>
        /// 
        public static string RemoveChars(string text,char[] charsToRemove)
        {
            
            for (int i = 0; i < charsToRemove.Length; i++)
            {
                text= text.Replace(charsToRemove[i].ToString(),"");
            }
            return text;

        }

        public static string RemoveChars2(string text, char[] charsToRemove)
        {

            foreach (char c in charsToRemove)
            {
                text = text.Replace(c.ToString(), "");
            }
            return text;

        }
        public static string RemoveChars3(string text, char[] charsToRemove)
        {           
            charsToRemove.ToList().ForEach(c => { text = text.Replace(c.ToString(), ""); });                      
            return text;

        }
        static void PrintEveryThirdCharJ(string s)
        {
            int counter = 1;

            foreach (char c in s) 
            { 
                if (counter % 3 == 0) 
                    Console.WriteLine(c); 
                counter++; 
            }
        }
        static int CountXYs(string s)
        {
            int xy = 0;

            foreach (char c in s) 
                if (c == 'x' || c == 'y') 
                    xy++;
            return xy;
        }
        /// <summary>
        ///q8  A bit redundant but anyway....
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsADotCom(string text)
        {
            return (text.EndsWith(".com"));
        }
        string[] SplitSentence(string text, char c)
        {
            return text.Split(c);
        }


        public static int[] CountOccurrences(string s, char[] letters)
        {
            int[] counts = new int[letters.Length];

            for (int i = 0; i < letters.Length; i++)
            {
                foreach (char c in s)
                {
                    if (c == letters[i]) counts[i]++;
                }
            }
            return counts;
        }
    }
}