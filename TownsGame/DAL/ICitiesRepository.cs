using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CityGame.Models;

namespace CityGame.DAL
{
    interface ICitiesRepository
    {
        HashSet<string> GetCities();
    }
}
