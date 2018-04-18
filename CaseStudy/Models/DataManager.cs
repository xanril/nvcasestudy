using System;
using System.Collections.Generic;

namespace CaseStudy.Models
{
    class DataManager
    {
        private static DataManager instance;
        public static DataManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }

            return instance;
        }

        
        

        private DataManager()
        {

        }

        public void LoadData()
        {
        
        }        
    }
}
