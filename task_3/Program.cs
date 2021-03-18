using System;

namespace task_3
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Что Вы хотите:\nумножить число на матрицу{1},\nскладывать или вычитать матрицы{2},\nперемножать матрицы{3}\n ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        Console.WriteLine("Введите число строк матрицы: ");
                        int str = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите число столбцов матрицы: ");
                        int stol = Convert.ToInt32(Console.ReadLine());
                        int[,] matrix = new int[str, stol];
                        randomFill(matrix);
                        matrixOutPut(matrix);
                        Console.WriteLine("\nВведите число на которое хотите умножить матрицу: ");
                        int multiplier = Convert.ToInt32(Console.ReadLine());
                        multiplication(matrix, multiplier);
                        matrixOutPut(matrix);
                        break;
                    }
                case 2:
                    {
                        int str1, str2, stol1, stol2;
                        do
                        {
                            Console.WriteLine("Введите число строк 1 матрицы: ");
                            str1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число столбцов 1 матрицы: ");
                            stol1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число строк 2 матрицы: ");
                            str2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число столбцов 2 матрицы: ");
                            stol2 = Convert.ToInt32(Console.ReadLine());
                            if (str1 == str2 && stol1 == stol2)
                                break;
                            Console.WriteLine("Вы ошиблись складовать или вычитать матрицы можно только одной размерности!");
                        } while (true);

                        int[,] matrix1 = new int[str1, stol1];
                        randomFill(matrix1);
                        int[,] matrix2 = new int[str2, stol2];
                        randomFill(matrix2);
                        Console.WriteLine();
                        matrixOutPut(matrix1);
                        Console.WriteLine();
                        matrixOutPut(matrix2);
                        int[,] matrixResult = new int[str1, stol1];
                        do
                        {
                            Console.WriteLine("\nсложить или вычисть?");
                            char znak = Convert.ToChar(Console.ReadLine());                           
                            if (znak == '+' || znak == '-')
                            {
                                if (znak == '+')
                                    matrixResult = summation(matrix1, matrix2);
                                else
                                    matrixResult = subtraction(matrix1, matrix2);
                                break;
                            }
                            Console.WriteLine("Вы ошиблись вводить можно только + или -");
                        } while (true);
                        Console.WriteLine();
                        matrixOutPut(matrixResult);
                       
                        break;
                    }
                case 3:
                    {
                        int str1, str2, stol1, stol2;

                        do
                        {
                            Console.WriteLine("Введите число строк 1 матрицы: ");
                            str1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число столбцов 1 матрицы: ");
                            stol1 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число строк 2 матрицы: ");
                            str2 = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите число столбцов 2 матрицы: ");
                            stol2 = Convert.ToInt32(Console.ReadLine());
                            if (stol1 == str2)
                                break;
                            Console.WriteLine("Вы ошиблись, Количество столбцов в матрице 1 должно совпадать с количеством строк в матрице 2!");
                        } while (true);

                        int[,] matrix1 = new int[str1, stol1];
                        randomFill(matrix1);
                        int[,] matrix2 = new int[str2, stol2];
                        randomFill(matrix2);
                        Console.WriteLine();
                        matrixOutPut(matrix1);
                        Console.WriteLine();
                        matrixOutPut(matrix2);

                        int[,] matrixResult = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

                        matrixResult = multiplication(matrix1, matrix2);

                        Console.WriteLine();
                        matrixOutPut(matrixResult);
                        break;
                    }
                default:
                    break;
            }
        }
        static void matrixOutPut(int[,] ar)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    Console.Write(ar[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void randomFill(int[,] ar)
        {
            Random randomize = new Random();
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    ar[i, j] = randomize.Next(10);
                }
            }
        }
        static void multiplication(int[,] ar,int mul)
        {
            for (int i = 0; i < ar.GetLength(0); i++)
            {
                for (int j = 0; j < ar.GetLength(1); j++)
                {
                    ar[i, j] *= mul; 
                }
            }
        }
        static int[,] summation(int[,] ar1,int[,] ar2)
        {
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar1.GetLength(1); j++)
                {
                    ar1[i, j] += ar2[i, j];
                }
            }
            return ar1;
        }
        static int[,] subtraction(int[,] ar1, int[,] ar2)
        {
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar1.GetLength(1); j++)
                {
                    ar1[i, j] -= ar2[i, j];
                }
            }
            return ar1;
        }
        static int[,] multiplication(int[,] ar1, int[,] ar2)
        {
            int[,] result = new int[ar1.GetLength(0),ar2.GetLength(1)];
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar2.GetLength(1); j++)
                {
                    for (int k = 0; k < ar2.GetLength(0); k++)
                    {
                        result[i, j] += ar1[i, k] * ar2[k, j];
                    }
                }
            }
            return result;
        }
    }
}
