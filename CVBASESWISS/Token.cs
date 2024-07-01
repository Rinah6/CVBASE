using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBASESWISS
{
    class Token
    {
        private static int isCO = 0;

        private static List<string> stringList = new List<string>();
        private static string Username="";
        private static string Password="";
        private static bool AUTHO = false;
        private static bool ISA = false;

        public static int getisCO()
        {
            return isCO;
        }
        public static void setISCO(int RisCO)
        {
            isCO = RisCO;
        }
        public static void setName(string login, string password)
        {
            Username = login;
            Password = password;
        }
        public static string getName()
        {
            return Username;
        }
        public static string getPass()
        {
            return Password;
        }
        public static List<string> getLST()
        {
            return stringList;
        }
        public static void setLST(List<string> RstringList)
        {
            stringList = RstringList;
        }

        public static bool getAUTHO()
        {
            return AUTHO;
        }
        public static void setAUTHO(bool RAUTHO)
        {
            AUTHO = RAUTHO;
        }

        public static bool getISA()
        {
            return ISA;
        }
        public static void setISA(bool RISA)
        {
            ISA = RISA;
        }
    }
}
