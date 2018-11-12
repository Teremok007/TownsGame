using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGame.Models;
using System.Web.Hosting;

namespace CityGame.DAL
{
    public class TxtFileCitiesRepository : ICitiesRepository
    {
        public HashSet<string> GetCities()
        {
            HashSet<string> _cities = new HashSet<string>();
            string cityFileName = HostingEnvironment.MapPath(@"~/App_Data/Cities.txt");
            string[] stringCityArr = File.ReadAllLines(cityFileName);

            int i = 1;
            foreach (var cityName in stringCityArr)
            {
                _cities.Add(cityName);
            }
            return _cities;
        }
    }
}