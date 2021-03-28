using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkCS
{
    public struct Worker
    {
        int salary, age, iD;
        string firstName, secondName, departmantName;

        public int Salary { get => salary; set => salary = value; }
        public int Age { get => age; set => age = value; }
        public int ID { get => iD;}
        public string FirstName { get => firstName; set => firstName = value; }
        public string SecondName { get => secondName; set => secondName = value; }
        public string DepartmantName { get => departmantName; set => departmantName = value; }

        public void RandomFill()
        {
            Random randomize = new Random();
            string[] secondname = new string[] { "Иванов", "Петров", "Романов", "Николаев", "Хичкок" };
            string[] firstname = new string[]  { "Петр", "Иван", "Дмитрий", "Сергей", "Евгений" };

            salary = randomize.Next(10_000, 40_000);
            Age = randomize.Next(18, 65);
            FirstName = firstname[randomize.Next(0,5)];
            SecondName = secondname[randomize.Next(0, 5)];
        }
        
        public Worker(string depName, int id)
        {
            departmantName = depName;
            salary = 0;
            age = 0;
            iD = id;
            firstName = "firstName";
            secondName = "secondName";
        }
    }
}
