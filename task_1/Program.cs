using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dohod = new int[12];
            int[] rashod = new int[12];
            int[] pribl = new int[12];
            int[] priblHubh = new int[12];

            #region заполнение массивов
            Random randomize = new Random();

            for (int i = 0; i < dohod.Length; i++)
            {
                dohod[i] = randomize.Next(1000, 10000);
            }

            for (int i = 0; i < rashod.Length; i++)
            {
                rashod[i] = randomize.Next(1000, 10000);
            }

            for (int i = 0; i < dohod.Length; i++)
            {
                pribl[i] = dohod[i] - rashod[i];
            }
            #endregion

            #region вывод массивов
            for (int i = 0; i < dohod.Length; i++)
            {
                Console.WriteLine($"{i + 1}\t {dohod[i]}\t {rashod[i]}\t {pribl[i]}");
            }
            #endregion

            Console.Write($"худшая прибль в месяцах №: ");

            #region нахождение месяцов с минимальной прибылью
            int[] mins = new int[3];
            int[] k1 = new int[pribl.Length - 2];
            int[] k2 = new int[pribl.Length - 1];
            int[] k3 = new int[pribl.Length];
            for (int i = 0; i < pribl.Length; i++)
            {
                if (pribl[i] < mins[0])
                {
                    mins[2] = mins[1];
                    mins[1] = mins[0];
                    mins[0] = pribl[i];
                }
                if ((pribl[i] != mins[0]) && (pribl[i] <= mins[1]))
                {
                    mins[2] = mins[1];
                    mins[1] = pribl[i];
                }
                if ((pribl[i] != mins[0]) && (pribl[i] != mins[1]) && (pribl[i] <= mins[2]))
                {
                    mins[2] = pribl[i];
                }
            }
            int n1 = 0, n2 = 0, n3 = 0;
            for (int i = 0; i < pribl.Length; i++)
            {
                if (pribl[i] == mins[0])
                {
                    k1[n1] = i + 1;
                    n1++;
                }
                if (pribl[i] == mins[1])
                {
                    k2[n2] = i + 1;
                    n2++;
                }
                if (pribl[i] == mins[2])
                {
                    k3[n3] = i + 1;
                    n3++;
                }
            }

            for (int i = 0; (i < k1.Length) && (k1[i] != 0); i++)
            {
                Console.Write($"{k1[i]}\t");
            }
            for (int i = 0; (i < k2.Length) && (k2[i] != 0); i++)
            {
                Console.Write($"{k2[i]}\t");
            }
            for (int i = 0; (i < k3.Length) && (k3[i] != 0); i++)
            {
                Console.Write($"{k3[i]}\t");
            }
            #endregion

            Console.Write($"\n месяцов с положительной прибылью: ");

            int count = 0;

            for (int i = 0; i < pribl.Length; i++)
            {
                if (pribl[i] > 0)
                {
                    count++;
                }
            }

            Console.Write(count);

        }
    }
}
