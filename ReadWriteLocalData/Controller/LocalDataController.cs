using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLocalData.Controller
{
    public class LocalDataController
    {
        private string tempDirectoryPath = Path.GetTempPath() + @"\ReadWriteLocalData";
        private string tempLogPath = @"\Logs";
        private string tempFileName = @"\log.txt";

        public ObservableCollection<string> Logs { get; set; }

        public LocalDataController()
        {
            Directory.CreateDirectory(tempDirectoryPath + tempLogPath);                   
        }

        public void Write(string str)
        {
            File.AppendAllText(tempDirectoryPath + tempLogPath + tempFileName, str + Environment.NewLine);
        }

        public void Read()
        {
            if (File.Exists(tempDirectoryPath + tempLogPath + tempFileName))
                this.Logs = new ObservableCollection<string>(File.ReadAllLines(tempDirectoryPath + tempLogPath + tempFileName));
        }
    }
}
