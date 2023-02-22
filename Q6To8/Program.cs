namespace Q6To8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] chars = { '&', '%', '$' };

            string text = "$&$$abd%$as&&";
            
            Console.WriteLine(InsertCharEveryThird("Hello, World!", '-')) ;
            Console.WriteLine(text);
            Console.WriteLine(RemoveChars(text,chars));

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
                if ((i % 3 == 0)&&(i!=0))
                    newText += c.ToString();
            }

            return newText;
        }
        /// <summary>
        /// q7 Removes the specified characters from the text string.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="charsToRemove"></param>
        /// <returns></returns>
        public static string RemoveChars(string text,char[] charsToRemove)
        {
            
            for (int i = 0; i < charsToRemove.Length; i++)
            {
                text= text.Replace(charsToRemove[i].ToString(),"");
            }
            return text;

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
    }
}