using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using CityGame.DAL;

namespace CityGame.Models
{
    public static class Game
    {
        private static ICitiesRepository _cityRepo;
        public static List<LogItem> AnswerLog = new List<LogItem>();
        public static HashSet<string> Cities;
        public static HashSet<string> UsedCity = new HashSet<string>();


        static Game()
        {
            _cityRepo = new SqlCeCitiesRepository();
            Cities = _cityRepo.GetCities();
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

        public static char LastLetter(char def = Char.MinValue)
        {
            return Game.AnswerLog.Count > 0 ? Game.AnswerLog.Last().CityName.Last(c => (c != 'Ь') && (c != 'Ъ')) : def;
        }

    }
}