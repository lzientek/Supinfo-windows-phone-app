using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SupinfoNote.Helper.JsonModels
{
   public class Planning
    {
       public static List<Planning> GetPlanning(string json)
       {
            JObject jObject = JObject.Parse(json);
            var array = jObject["response"]["events"].AsJEnumerable();
            return array.Select(jtok => new Planning()
            {
                Uid = (string)jtok["uid"],
                Summary = (string)jtok["summary"],
                Description = (string)jtok["description"],
                Dtstart = (string)jtok["dtstart"],
                Dtend = (string)jtok["dtend"],
                Timezone = (string)jtok["timezone"],
                Location = (string)jtok["location"]
            }).ToList();
        }
        public string Uid { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Dtstart { get; set; }
        public string Dtend { get; set; }
        public string Timezone { get; set; }
        public string Location { get; set; }
    }
}
