using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sabirov.BarsGroup.Task6.IEnumerable.Models
{
    public class LocalFileLogger<T> : ILogger
    {
        public static string path = "./logs.txt";
        private static void CreateFile(string msg)
        {
            File.AppendAllText(path, msg);
        }
        public void LogError(string message, Exception ex)
        {
            string msg = $"\n[Error] : [{typeof(T)}] : {message}. {ex.Message}\n";
            CreateFile(msg);
            Console.WriteLine(msg);
            
        }

        public void LogInfo(string message)
        {
            string msg = $"\n[Info]: [{typeof(T)}] : {message}\n";
            CreateFile(msg);
            Console.WriteLine(msg);
        }

        public void LogWarning(string message)
        {
            string msg = $"\n[Warning] : [{typeof(T)}] : {message}\n";
            CreateFile(msg);
            Console.WriteLine(msg);
        }
    }
}
