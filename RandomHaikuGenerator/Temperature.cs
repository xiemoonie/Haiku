using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomHaikuGenerator
{
    public class TempIsZeroException : Exception
    {
        public TempIsZeroException(string message) : base(message)
        {
        }
    }
    public class Temperature
    {
        string sentence = "TOcoolToBEtRUE";
        string dataFromTemperature = "6F163A3B";
        string pathSentence = @"C:\Users\Carola\Documents\MyHexadecimal.txt";
        string pathTemp = @"C:\Users\Carola\Documents\MyTemperatura.txt";

        public void writesSentence()
        {
            if (File.Exists(pathSentence))
            {
                File.Delete(pathSentence);
            }
            FileStream? file = null;
            FileInfo fileinfo = new FileInfo(pathSentence);
            try
            {
                file = fileinfo.OpenWrite();
                file.Write(StringToCrazyByteArray(sentence));

            }
            finally
            {

                file?.Close();
            }
        }
        public void writesHaxadecimal()
        {
            if (File.Exists(pathTemp))
            {
                File.Delete(pathTemp);
            }
            FileStream? file = null;
            FileInfo fileinfo = new FileInfo(pathTemp);
            try
            {
                file = fileinfo.OpenWrite();
                file.Write(StringToByteArray(dataFromTemperature));
            }
            finally
            {

                file?.Close();
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        public static byte[] StringToCrazyByteArray(string hex)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(hex);

            return byteArray;
        }

        public void showTemp()
        {
            StreamReader streamTemp = new StreamReader(pathTemp);
            StreamReader streamSentence = new StreamReader(pathSentence);
            string da = streamTemp.ReadToEnd().PadLeft(8,'0');
            string data = streamSentence.ReadToEnd();
          

            streamSentence.Close();
            streamTemp.Close();
            foreach(char d in data)
            {
            Console.WriteLine("letter " +d);
            }
           
            
            foreach (char d in da)
            {
                int n = (int)Convert.ToUInt32(d);
                Console.WriteLine("other " +n.ToString("X"));
         
            }
            
        }

        [Serializable]
        public class InvalidDepartmentException : Exception
        {
            public InvalidDepartmentException() : base() { }
            public InvalidDepartmentException(string message) : base(message) { }
            public InvalidDepartmentException(string message, Exception inner) : base(message, inner) { }
        }
    }
}