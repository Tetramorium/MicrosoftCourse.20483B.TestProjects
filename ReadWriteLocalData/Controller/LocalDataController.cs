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
        private const string tempFileNameTemp = @"\TempLog.txt";

        public ObservableCollection<Log> Logs { get; set; }

        public LocalDataController()
        {
            Directory.CreateDirectory(tempDirectoryPath + tempLogPath);

            Logs = new ObservableCollection<Log>();
        }

        // TODO Specify a drive other than SSD to avoid damage
        // Maybe let the user decide where to log
        // https://superuser.com/a/848291

        public void Write(Log _NewLog)
        {
            File.AppendAllText(tempDirectoryPath + tempLogPath + tempFileName, JsonConvert.SerializeObject(_NewLog) + Environment.NewLine);
            Logs.Add(_NewLog);
        }

        public void ReadWithStream()
        {
            if (File.Exists(tempDirectoryPath + tempLogPath + tempFileName))
            {
                bool caughtException = false;

                using (StreamReader sr = new StreamReader(tempDirectoryPath + tempLogPath + tempFileName))
                {
                    using (var sw = new StreamWriter(tempDirectoryPath + tempLogPath + tempFileNameTemp))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            try
                            {
                                Logs.Add(JsonConvert.DeserializeObject<Log>(line));
                                sw.WriteLine(line);
                            }
                            catch (Exception e)
                            {
                                caughtException = true;
                            }
                        }
                    }
                }

                if (caughtException)
                {
                    File.Delete(tempDirectoryPath + tempLogPath + tempFileName);
                    File.Move(tempDirectoryPath + tempLogPath + tempFileNameTemp, tempDirectoryPath + tempLogPath + tempFileName);
                }
                else
                {
                    File.Delete(tempDirectoryPath + tempLogPath + tempFileNameTemp);
                }

                if (Logs.Any())
                    Log.HighestId = Logs.Max(e => e.LogId);
            }
        }

        public void ReadWithFile()
        {
            if (File.Exists(tempDirectoryPath + tempLogPath + tempFileName))
            {
                string[] str = File.ReadAllLines(tempDirectoryPath + tempLogPath + tempFileName);
                bool caughtException = false;

                using (var sw = new StreamWriter(tempDirectoryPath + tempLogPath + tempFileNameTemp))
                {
                    for (int i = 0; i < str.Length; i++)
                    {
                        try
                        {
                            Logs.Add(JsonConvert.DeserializeObject<Log>(str[i]));
                            sw.WriteLine(str[i]);
                        }
                        catch (Exception e)
                        {
                            caughtException = true;
                        }
                    }
                }

                if (caughtException)
                {
                    File.Delete(tempDirectoryPath + tempLogPath + tempFileName);
                    File.Move(tempDirectoryPath + tempLogPath + tempFileNameTemp, tempDirectoryPath + tempLogPath + tempFileName);
                }
                else
                {
                    File.Delete(tempDirectoryPath + tempLogPath + tempFileNameTemp);
                }
            }

            if (Logs.Any())
                Log.HighestId = Logs.Max(e => e.LogId);
        }
    }
}
