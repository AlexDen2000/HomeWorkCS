using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWorkCS
{
    public struct Departmant
    {
        string name;
        DateTime dTCreate;
        private int countWorker;
        private List<Worker> listWorker;
        public string Name { get => name; set => name = value; }
        public DateTime DTCreate { get => dTCreate; set => dTCreate = value; }
        public int CountWorker
        {
            get
            {
                countWorker = listWorker.Count;
                return countWorker;
            }
        }
        public List<Worker> ListWorker 
        { 
            get 
            {
                for (int i = 0; i < listWorker.Count; i++)
                {
                    var str = listWorker[i];
                    str.DepartmantName = name;
                    listWorker[i] = str;
                }
                return listWorker;
            } 
        }

        

        public Departmant(string name)
        {
            this.name = name;
            dTCreate = System.DateTime.Now;
            listWorker = new List<Worker>();
            countWorker = 0;
        }
    }
}
