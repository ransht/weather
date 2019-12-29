using System;

namespace Wheather.Dal.Entities
{
    public class Favorite
    {
        public int Id { get; set; }

        //Used string because this is the datatype i get in the json file
        public string LocationId{ get; set; }
        public string LocalizedName{ get; set; }
        public string WeatherText { get; set; }
        public double TempInCelsius { get; set; }
    }
}
