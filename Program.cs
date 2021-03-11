using System;

namespace HomeWork_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Students();
            student.name = "Alexander";
            student.height = 180;
            student.age = 18;
            student.ballHistory = 70;
            student.ballLanguage = 68;
            student.ballMatematics = 59;
            Console.WriteLine("name = " + student.name + " age = " + student.age + " height = " + student.height + " Средний балл = " + student.SrBall());
            Console.WriteLine("имя = {0}, рост = {1}, возраст = {2}, ср. балл = {3}",student.name,student.height,student.age,student.SrBall());
            Console.WriteLine($"имя = {student.name}, рост = {student.height}, возраст = {student.age}, ср. балл = {student.SrBall()}");
        }
        
    }
}
