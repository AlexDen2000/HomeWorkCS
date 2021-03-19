using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinWord("A ББ ВВВ ГГГГ ДДДД    ДД ЕЕ ЖЖ ЗЗЗ"));
            string[] words = MaxWord("A ББ ВВВ ГГГГ ДДДД    ДД ЕЕ ЖЖ ЗЗЗ");
            foreach(string word in words)
            Console.Write(word+"\t");
        }
        /// <summary>
        /// Метод для вычисления слова минимальной длины
        /// </summary>
        /// <param name="str"> строка со словами для обработки</param>
        /// <returns></returns>
        static string MinWord(string str)
        {
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }

            char[] chars = { ' ' };
            string[] word = str.Split(chars);
            int minLength = int.MaxValue;

            foreach (string st in word)
            {
                if (st.Length < minLength)
                {
                    minLength = st.Length;
                }
            }
            foreach(string st in word)
            {
                if (st.Length == minLength)
                {
                    return st;
                }     
            }
            return "0";
        }
        /// <summary>
        /// Метод для вычисления слов максимальной длины
        /// </summary>
        /// <param name="str">строка для обследования</param>
        /// <returns></returns>
        static string[] MaxWord(string str)
        {
            while (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
            }

            char[] chars = { ' ' };
            string[] word = str.Split(chars);
            string[] wordMaxLength = new string[1];
            int maxLength = int.MinValue;
            int count = 0;

            foreach (string st in word)
            {
                if (st.Length > maxLength)
                {
                    maxLength = st.Length;
                }
            }
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Length == maxLength)
                {
                    wordMaxLength[count] = word[i];
                    Array.Resize(ref wordMaxLength, wordMaxLength.Length + 1);
                    count++;
                }
            }
            return wordMaxLength;
        }
    }
}
