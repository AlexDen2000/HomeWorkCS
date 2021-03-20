using System;

namespace task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Progression(4, 6));
            Console.WriteLine(Progression(3, 5, 7, 9, 11));
            Console.WriteLine(Progression(1, 4, 9, 16, 25, 36));
            Console.WriteLine(Progression(50, 25, 12.5, 6.25, 3.125));
        }
        /// <summary>
        /// Метод для определия является ли некоторое кол-во чисел ариф. или геом. прогрессией
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static string Progression(params double[] arr)
        {
            if (arr.Length < 3)
                return "Мало данных";
            if (ArithmeticProgression(arr) == true)
                return "Является арифметической прогрессией";
            if (GeometricProgression(arr) == true)
                return "Является геометрической прогрессией";
            return "Не является прогрессией";
        }
        /// <summary>
        /// Метод для определия является ли некоторое кол-во чисел ариф. прогрессией
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool ArithmeticProgression(params double[] arr)
        {
            double d = arr[1] - arr[0];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (arr[i] + d != arr[i + 1])
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Метод для определия является ли некоторое кол-во чисел геом. прогрессией
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool GeometricProgression(params double[] arr)
        {
            double d = arr[1] / arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] * d != arr[i + 1])
                    return false;
            }
            return true;
        }
    }
}
