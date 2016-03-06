using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SupinfoNote.Uni10.Core.JsonModels
{
    public class News
    {

        public static List<News> GetNews(string json)
        {
            JObject jObject = JObject.Parse(json);
            var array = jObject["response"].AsJEnumerable();
            return array.Select(jtok => new News
            {
                Title = (string)jtok["title"],
                Type = (string)jtok["type"],
                Start = (string)jtok["start"],
                Content = (string)jtok["content"],
                Url = (string)jtok["url"],
                Campus = (string)jtok["campus"]
            }).ToList();
        }

        public News()
        {

        }

        public string Title { get; set; }
        public string Type { get; set; }
        public string Start { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string Campus { get; set; }
    }
}
