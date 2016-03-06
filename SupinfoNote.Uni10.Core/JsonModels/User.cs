using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json.Linq;

namespace SupinfoNote.Uni10.Core.JsonModels
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
            Token = (string)jUser["token"];
            Ects = (int)jUser["ects"];
            SuccessPoints = (double)jUser["success_points"];
        }

        public void ConvertStringToImage()
        {
            try
            {
                Picture = new BitmapImage(new Uri($"http://www.campus-booster.net/actorpictures/{BoosterId}.jpg"));
            }
            catch (Exception ex)
            {
            }
        }

        public User()
        {
        }

        public int BoosterId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Program { get; set; }
        public string ClassId { get; set; }
        public BitmapImage Picture { get; set; }
        public string Token { get; set; }
        public int Ects { get; set; }
        public double SuccessPoints { get; set; }
    }
}
