using System;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DeletedSimilarSimvols("HHHHHHi        wwwwworllllddd"));
        }
        /// <summary>
        /// Метод для удаления всех кратных рядом стоящих символов
        /// </summary>
        /// <param name="str">исследуемая сторока</param>
        /// <returns></returns>
        static string DeletedSimilarSimvols(string str)
        {
            string outStr=null;
            char[] ch = new char[1];
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (ch[count]==str[i])
                {
                    ch[count] = str[i];
                }
                else
                {
                    Array.Resize(ref ch, ch.Length + 1);
                    count++;
                    ch[count] = str[i];
                }
            }
            foreach (char c in ch)
                outStr += c;
            return outStr;
        }
    }
}
