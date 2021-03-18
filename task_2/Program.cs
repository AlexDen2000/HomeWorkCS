using System;

namespace task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сколько хотите строк теругольника паскаля: ");
            int n = Convert.ToInt32(Console.ReadLine());

            #region создание массива
            int[][] array = new int[n][];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new int[i + 1];
                array[i][0] = 1;
                array[i][array[i].Length - 1] = 1;
            }
            for (int i = 2; i < array.Length; i++)
            {
                for (int j = 1; j < array[i].Length-1; j++)
                {
                    array[i][j] = array[i - 1][j - 1] + array[i-1][j];
                }
            }
            #endregion


            #region Вывод на экран массива
            Console.WriteLine("\nВаш треугольник паскаля: ");
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]+"\t");
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
