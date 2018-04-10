using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLocalData.Model
{
    public class Log
    {
        private static int highestId;

        public static int HighestId
        {
            get { return highestId++; }
            set { highestId = value; }
        }

        //https://www.newtonsoft.com/json/help/html/JsonPropertyRequired.htm

        [JsonProperty(Required = Required.Always)]
        public int LogId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Message { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime Date { get; set; }

        public Log(string _Message)
        {
            this.Message = _Message;
            this.Date = DateTime.Now;
            this.LogId = HighestId;
        }
    }
}
