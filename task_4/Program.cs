using System;

namespace task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(A(3,5));
        }
        /// <summary>
        /// Вычисляет функцию Аккермана
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static long A(long m, long n)
        {
            if (m == 0) return n + 1;
            if (m > 0 && n == 0) return A(m - 1, 1);
            if (n > 0 && m > 0) return A(m - 1, A(m, n - 1));
            return A(n, m);
        }
    }
}
