using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_02
{
    class Students
    {
        public string name;
        public int age, height;
        public int ballHistory, ballMatematics, ballLanguage;
        
        public double SrBall()
        {
            return ((ballHistory + ballLanguage + ballMatematics) / 3);
        }

      
    }
}
