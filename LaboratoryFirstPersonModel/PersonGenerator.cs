using LaboratoryFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryFirst
{
    /// <summary>
    /// Создает случайного человека
    /// </summary>
    /// <returns>Объект класса Person со случайными значениями полей</returns>
    public class PersonGenerator
    {
        /// <summary>
        /// Создает случайного человека
        /// </summary>
        /// <returns>Объект класса Person со случайными значениями полей</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();

            string[] maleNames = ReadFile("Data/male_names.txt");
            string[] femaleNames = ReadFile("Data/female_names.txt");
            string[] lastNames = ReadFile("Data/lastnames.txt");

            Sex sex = random.Next(2) == 0 ? Sex.Male : Sex.Female;
            string firstName = sex == Sex.Male
                ? maleNames[random.Next(maleNames.Length)]
                : femaleNames[random.Next(femaleNames.Length)];

            string lastName = lastNames[random.Next(lastNames.Length)];
            if (sex == Sex.Female)
            {
                lastName += "а";
            }

            int age = random.Next(Person.MinAge, Person.MaxAge);

            return new Person(firstName, lastName, age, sex);
        }

        /// <summary>
        /// Метод считывания строк в файле
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Массив слов</returns>
        private static string[] ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                return Array.Empty<string>();
            }
            return File.ReadAllLines(path)
                .Where(value => !string.IsNullOrWhiteSpace(value))
                .ToArray();
        }
    }
}
