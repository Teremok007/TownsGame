using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CityGame.Models;
using System.Data.SqlServerCe;
using System.Web.Hosting;


namespace CityGame.DAL
{
    public class SqlCeCitiesRepository : ICitiesRepository
    {
        private string _connectionString = string.Format("Data Source = {0}", HostingEnvironment.MapPath(@"~/App_Data/CityGame.sdf"));            

        public HashSet<string> GetCities()
        {
            using (SqlCeConnection connection = new SqlCeConnection(_connectionString))
            {
                using (SqlCeCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        SELECT Id, [Name] as Name
                        FROM Cities";

                    connection.Open();

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        return ParserCity(reader);
                    }
                }
            }
        }

        private HashSet<string> ParserCity(SqlCeDataReader reader)
        {
            HashSet<string> cities = new HashSet<string>();
            while (reader.Read())
            {
                var city = ParceCity(reader);
                cities.Add(city);
            }
            return cities;
        }

        private string ParceCity(SqlCeDataReader reader)
        {
            return (string)reader["Name"];
        }
    }
}