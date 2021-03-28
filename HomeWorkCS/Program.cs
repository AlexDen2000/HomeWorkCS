using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace HomeWorkCS
{
    class Program
    {
        static List<Departmant> listDepartmant = new List<Departmant>();
        static void Main(string[] args)
        {

            AddDepartment("IT");
            AddDepartment("HR");
            AddDepartment("Economix");
            AddWorker("IT");
            AddWorker("IT");
            AddWorker("IT");
            FillToRandom("IT", 1);
            DeliteDepartmant("HR");
            DeliteWorker("IT", 0);

            SerializeDepartmantToXML(listDepartmant[0], "Test1.xml");
            SerializeDepartmantListToXML(listDepartmant, "Test.xml");
            SerializeDepartmantListToJSON(listDepartmant, "Test.json");
        }
        static void AddDepartment(string nameDepartmant)
        {
            listDepartmant.Add(new Departmant(nameDepartmant));
        }
        static void DeliteDepartmant(string nameDepartmant)
        {
            for (int i = 0; i < listDepartmant.Count; i++)
            {
                if (listDepartmant[i].Name == nameDepartmant)
                {
                    listDepartmant.RemoveAt(i);
                }
            }
        }
        static void FillToRandom(string nameDepartmant, int ID)
        {
            for (int i = 0; i < listDepartmant.Count; i++)
            {
                if (listDepartmant[i].Name == nameDepartmant)
                {
                    for (int j = 0; j < listDepartmant.Count; j++)
                    {
                        if (listDepartmant[i].ListWorker[j].ID == ID)
                        {
                            var str = listDepartmant[i].ListWorker[j];
                            str.RandomFill();
                            listDepartmant[i].ListWorker[j] = str;
                        }
                    }
                }
            }
        }
        static void AddWorker(string nameDepartmant)
        {
            for (int i = 0; i < listDepartmant.Count; i++)
            {
                if (listDepartmant[i].Name == nameDepartmant) 
                {
                    listDepartmant[i].ListWorker.Add(new Worker(nameDepartmant, listDepartmant[0].CountWorker));
                }
            }
        }
        static void DeliteWorker(string nameDepartmant, int ID)
        {
            for (int i = 0; i < listDepartmant.Count; i++)
            {
                if (listDepartmant[i].Name == nameDepartmant)
                {
                    for (int j = 0; j < listDepartmant.Count; j++)
                    {
                        if (listDepartmant[i].ListWorker[j].ID == ID)
                        {
                            listDepartmant[i].ListWorker.RemoveAt(j);
                        }
                    }
                }
            }
        }
        static void SerializeDepartmantToXML(Departmant dep, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Departmant));
            Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fStream, dep);
            fStream.Close();
        }
        static Departmant DeserializeDepartmantOnXML(string path)
        {
            Departmant tempDepartman = new Departmant();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Departmant));
            Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            //tempDepartman = xmlSerializer.Deserialize(fStream) as Departmant;
            fStream.Close();
            return tempDepartman;
        }
        static void SerializeDepartmantListToXML(List<Departmant> СoncreteDepartmantList, string Path)
        {
            // Создаем сериализатор на основе указанного типа 
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Departmant>));
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, СoncreteDepartmantList);
            }
        }
        static List<Departmant> DeserializeDepartmantListOnXML(string Path)
        {
            List<Departmant> tempDepartmantCol = new List<Departmant>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Departmant>));
            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            tempDepartmantCol = xmlSerializer.Deserialize(fStream) as List<Departmant>;
            fStream.Close();
            return tempDepartmantCol;
        }
        static void SerializeDepartmantListToJSON(List<Departmant> СoncreteDepartmantList, string Path)
        {
            string json = JsonConvert.SerializeObject(СoncreteDepartmantList);
            File.WriteAllText(Path, json);
        }
        
    }
}
