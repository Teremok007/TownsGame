using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace CityGame.Models
{
    public static class Game
    {

        public static List<LogItem> AnswerLog = new List<LogItem>();
        public static HashSet<string> Cities = new HashSet<string>();
        public static HashSet<string> UsedCity = new HashSet<string>();


        static Game()
        {
            LoadCities();
        }

        private static void LoadCities()
        {
            string cityFileName = HostingEnvironment.MapPath(@"~/App_Data/Cities.txt");
            string[] stringCityArr = File.ReadAllLines(cityFileName);

            foreach(var cityName in stringCityArr)
            {
                Cities.Add(cityName.ToUpper());
            }
        }

        private static object _lockObject = new object();

        public static void AddLog(LogItem log)
        {
            lock (_lockObject)
            {
                AnswerLog.Add(log);
                UsedCity.Add(log.CityName);
            }
        }

        public static char StartLetter(char def = Char.MinValue)
        {
            return Game.AnswerLog.Count > 0 ? Game.AnswerLog.Last().CityName.Last() : def;
        }

    }
}