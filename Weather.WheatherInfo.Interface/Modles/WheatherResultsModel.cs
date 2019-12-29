using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.WheatherInfo.Accuweather.Interface.Models
{
    //U can uncomments some properties if you need
    public class Metric
    {
        public double Value { get; set; }
        //public string Unit { get; set; }
        //public int UnitType { get; set; }
    }

    public class Imperial
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Metric Metric { get; set; }
        //public Imperial Imperial { get; set; }
    }

    public class WheatherResultsModel
    {
        public Temperature Temperature { get; set; }
        //public DateTime LocalObservationDateTime { get; set; }
        //public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        //public int WeatherIcon { get; set; }
        //public bool HasPrecipitation { get; set; }
        //public object PrecipitationType { get; set; }
        //public bool IsDayTime { get; set; }
        //public string MobileLink { get; set; }
        //public string Link { get; set; }
    }
}
