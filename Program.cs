using System;

namespace HomeWorkCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string name1, name2;
            int userTry,maxValue = 4;
            Console.WriteLine("Введите имя 1 игрока: ");
            name1 = Console.ReadLine();
            Console.WriteLine("Введите имя 2 игрока: ");
            name2 = Console.ReadLine();
            Console.WriteLine($"Максимальное число для вычитания равно {maxValue} ");
            while (true)
            {
                Random randomize = new Random();
                int gameNumber = randomize.Next(12, 121);
                Console.WriteLine($"Число равно {gameNumber} ");
                while (gameNumber > 0)
                {
                    Console.WriteLine($"Введите число для {name1} игрока : ");
                    while (true)
                    {
                        userTry = int.Parse(Console.ReadLine());
                        if (maxValue < userTry)
                        {
                            Console.WriteLine("повторите ввод, Ваше число оказалось больше допустимого: ");
                            continue;
                        }
                        else
                        {
                            gameNumber -= userTry;
                            break;
                        }
                    }
                    
                    
                    if (gameNumber > 0)
                    {
                        Console.WriteLine($"Число равно {gameNumber} ");
                    }
                    else
                    {
                        Console.WriteLine($" {name1} игрок Win! ");
                        break;
                    }

                    Console.WriteLine($"Введите число для {name2} игрока : ");
                    while (true)
                    {
                        userTry = int.Parse(Console.ReadLine());
                        if (maxValue < userTry)
                        {
                            Console.WriteLine("повторите ввод, Ваше число оказалось больше допустимого: ");
                            continue;
                        }
                        else
                        {
                            gameNumber -= userTry;
                            break;
                        }
                    }

                    if (gameNumber > 0)
                    {
                        Console.WriteLine($"Число равно {gameNumber} ");
                    }
                    else
                    {
                        Console.WriteLine($" {name2} игрок Win! ");
                        break;
                    }
                }
                Console.WriteLine(" Хотите реванш? (+/-) ");
                if (Console.ReadLine() != "+")
                    break;
            }
        }
    }
}
