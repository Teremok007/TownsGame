using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityGame.Models
{
    public class CityViewModel : IValidatableObject
    {
        public List<LogItem> AnswerLog { get; set; }

        private string city;
        public string City {
            get
            {
                return city;
            }
            set
            {
                city = value.ToUpper().Replace('Ё', 'Е').Replace('Й','И');               
            }
        }

        public string GamerName { get; set; }

        public DateTime Date { get; set; }

        private List<ValidationResult> validList = new List<ValidationResult>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            validList.Clear();
            CheckValidCityName();
            CheckFirstLetter();
            CheckUsedCity();
            CheckCityInList();
            return validList;
        }

        private void CheckValidCityName()
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                validList.Add(new ValidationResult("Название города не должно быть пустым."));
            }
        }

        private void CheckUsedCity()
        {
            if (Game.UsedCity.Contains(city))
            {
                validList.Add(new ValidationResult($"Название города {city} уже было использовано."));
            }
        }

        private void CheckFirstLetter()
        {
            char lastLetter = Game.LastLetter(city[0]);
            if (city?.First() != lastLetter)
            {
                validList.Add(new ValidationResult($"Название города должно начинаться с буквы '{lastLetter}'"));
            }
        }
        
        private void CheckCityInList()
        {
            if (!Game.Cities.Contains(city))
            {
                validList.Add(new ValidationResult($"Название города '{city}' не существует."));
            }
        }
    }
}