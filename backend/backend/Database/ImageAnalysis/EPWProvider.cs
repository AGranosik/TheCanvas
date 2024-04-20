using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace llm_sandbox
{
    public class EPWProvider
    {
        public static string GetTestSun1()
        {
            string filePath = "files/sun1.txt";  // Path to your EPW file
            string lines = File.ReadAllText(filePath);
            return lines;
        }
        public static string GetTestSun2()
        {
            string filePath = "files/sun2.txt";  // Path to your EPW file
            string lines = File.ReadAllText(filePath);
            return lines;
        }
        public static string GetTestEPW()
        {
            string filePath = "files/ESP_Gerona.081840_SWEC.ddy";  // Path to your EPW file
            string lines = File.ReadAllText(filePath);
            return lines;
        }
        public static string GetTestEPW2()
        {
            string filePath = "files/ESP_CT_San.Lorenzo.081860_TMYx.ddy";  // Path to your EPW file
            string lines = File.ReadAllText(filePath);
            return lines;
        }
    }
}
