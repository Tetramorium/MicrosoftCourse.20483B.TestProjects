using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReadWriteLocalData.Model;

namespace ReadWriteLocalData.Controller
{
    public class LocalDataController
    {
        //https://www.c-sharpcorner.com/uploadfile/mahesh/listbox-in-wpf/
        //https://spin.atomicobject.com/2013/12/11/wpf-data-binding-debug/
        //https://www.newtonsoft.com/json

        private string tempDirectoryPath = Path.GetTempPath() + @"\ReadWriteLocalData";
        private const string tempLogPath = @"\Logs";
        private const string tempFileName = @"\log.txt";

        public ObservableCollection<Log> Logs { get; set; }

        public LocalDataController()
        {
            Directory.CreateDirectory(tempDirectoryPath + tempLogPath);

            Logs = new ObservableCollection<Log>();
        }

        public void Write(Log _NewLog)
        {
            File.AppendAllText(tempDirectoryPath + tempLogPath + tempFileName, JsonConvert.SerializeObject(_NewLog) + Environment.NewLine);
            Logs.Add(_NewLog);
        }

        public void Read()
        {
            if (File.Exists(tempDirectoryPath + tempLogPath + tempFileName))
            {
                string[] str = File.ReadAllLines(tempDirectoryPath + tempLogPath + tempFileName);

                for (int i = 0; i < str.Length; i++)
                {
                    Logs.Add(JsonConvert.DeserializeObject<Log>(str[i]));
                }
            }

            if (Logs.Any())
                Log.HighestId = Logs.Max(e => e.LogId);          
        }
    }
}
