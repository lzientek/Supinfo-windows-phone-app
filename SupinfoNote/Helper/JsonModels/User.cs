using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SupinfoNote.Helper.JsonModels
{
    public class User
    {
        public User(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken jUser = jObject["response"];
            BoosterId = (int)jUser["booster_id"];
            Firstname = (string)jUser["firstname"];
            Lastname = (string)jUser["lastname"];
            Program = (string)jUser["program"];
            ClassId = (string)jUser["class_id"];
            Picture = (string)jUser["picture"];
            Token = (string)jUser["token"];
            Ects = (int)jUser["ects"];
            SuccessPoints = (double)jUser["success_points"];
        }

        public int BoosterId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Program { get; set; }
        public string ClassId { get; set; }
        public string Picture { get; set; }
        public string Token { get; set; }
        public int Ects { get; set; }
        public double SuccessPoints { get; set; }
    }
}
