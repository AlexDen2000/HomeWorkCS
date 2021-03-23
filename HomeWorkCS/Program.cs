using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Collections;

namespace HomeWorkCS
{

    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = @"inputNumber.txt";
            Console.WriteLine("Загружаю число из файла...");
            int number = ReadNumber(inputFile);
            int[][] result = new int[CountGroup(number)][];
            Console.WriteLine("Число в файле = " + number);
            Console.WriteLine();
            Console.WriteLine("Выберите режим работы: \n" + "1 - Показать только кол-во групп\n" +
                "2 - Выполнить алгоритм подсчета групп чисел методом перебора значений\n" +
                "с последующей архивацией или сохранением в файл\n");
            int[] range = new int[number - 2];
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Групп чисел: " + CountGroup(number));
                    break;
                case "2":
                    Console.WriteLine("Формирую массив чисел от 1 до вашего числа");
                    result = ReturnList(number);
                    Console.WriteLine("Производим запись результатов в файл output.csv");
                    string file = "output.csv";
                    SaveToFile(file, result);
                    Console.WriteLine("Сохранение в файл завершено!\n");

                    Console.WriteLine("Заархивировать полученный файл? \n" +
                        "1 - Да\n" +
                        "Любая клавиша - Нет, просто выйти из программы");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Compressig(file, "archivedOutput.zip");
                            Console.WriteLine("Файл заархивирован. Ищите его в папке с exe файлом");
                            break;
                        default:
                            break;
                    }
                    break;
            }
        }
        static int ReadNumber(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл данных inputNumber.txt не найден. Создаю файл по умолчанию");
                using (StreamWriter sw = new StreamWriter("inputNumber.txt", true, Encoding.Unicode))
                {
                    sw.WriteLine("50");
                }
            }
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                return int.Parse(sr.ReadLine());
            }
        }
        static int CountGroup(int number)
        {
            int count = 1;
            while (number > 1)
            {
                number /= 2;
                count++;
            }
            return count;
        }
        static int[][] ReturnList(int number)
        {
            int[][] groups = new int[CountGroup(number)][];
            groups[0] = new int[] { 1 };
            int indexGroup = 1;
            int[] numbers = new int[number];
            for (int i = 0; i < number; i++)
                numbers[i] = i + 1;
            int[] group = new int[number];
            int index1;
            while ((index1 = Array.BinarySearch(numbers, 1)) != number - 1)
            {
                Array.Copy(numbers, group, number);
                int countGroup = 0;
                for (int i = index1 + 1; i < number; i++)
                {
                    if (group[i] != 0) 
                    {
                        for (int j = i + 1; j < number; j++)
                            if (group[j] % group[i] == 0)
                                group[j] = 0;
                        numbers[i] = 0;
                        countGroup++;
                    }
                }
                Array.Sort(group);
                Array.Sort(numbers);
                int[] gr = new int[countGroup];
                Array.Copy(group, Array.BinarySearch(group, 1) + 1, gr, 0, countGroup);
                groups[indexGroup] = gr;
                indexGroup++;
            }
            return groups;
        }
        static void SaveToFile(string name, int[][] array)
        {
            if (File.Exists(name))
            {
                File.Delete(name);
            }
            using (StreamWriter sw = new StreamWriter(name, true, Encoding.Unicode))
            {
                string strArray;
                for (int i = 0; i < array.Length; i++)
                {
                    strArray = null;
                    for (int j = 0; j < array[i].Length; j++) 
                    {
                        strArray += $"{array[i][j]}\t";
                    }
                    sw.WriteLine(strArray);
                }
                
            }
        }
        static void Compressig(string source, string output)
        {
            if (!File.Exists(source)) Console.WriteLine("Файл не существует! Создайте файл для архивации или проверьте правильность пути");
            else
            {
                using (FileStream fs = new FileStream(source, FileMode.Open))
                {
                    using (FileStream nf = File.Create(output))
                    {
                        using (GZipStream gs = new GZipStream(nf, CompressionMode.Compress))
                        {
                            fs.CopyTo(nf);
                        }
                    }
                }
            }
        }
    }
}

