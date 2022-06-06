using HardcoreFramework.Models;
using System;

namespace HardcoreFramework.Service
{
    public class ComputeEngineCreator
    {
        public static ComputeEngine WithCredentialsFromProperty()
        {
            //Environment.SetEnvironmentVariable("enviroment", "dev");

            if (Environment.GetEnvironmentVariable("enviroment").Equals("dev"))
            {
                return TestDataReader.GetForm("D:/HardcoreFramework/HardcoreFramework/Properties/DevConfig.json").Result;
            }
            else if (Environment.GetEnvironmentVariable("enviroment").Equals("qa"))
            {
                return TestDataReader.GetForm("D:/HardcoreFramework/HardcoreFramework/Properties/QAConfig.json").Result;
            }

            return null;
        }
    }
}
