﻿namespace q4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RemoveEveryThree("abcdefghijklmno"));
        }
        /// <summary>
        /// This method removes a string of length 3 every third letter - it doesn't use string methods, so try a version that does.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        static string RemoveEveryThree(string s)
        {
            string s1 = "";
            
            for(int i=0;i<s.Length;i++)
            { 
                if ((i%3==0)&& ((i/3)%2 !=0))
                {
                   
                    i+=2;
                         
                }
                else
                {
                  
                    s1 += s[i];
                    
                }
            
            }
            return s1;
        }
    }
}