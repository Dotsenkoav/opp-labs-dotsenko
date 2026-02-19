namespace LaboratorySecondPersonModel
{
    /// <summary>
    /// Класс генерации случайного человека
    /// </summary>
    public class PersonGenerator
    {
        // Не бейте за static поле

        /// <summary>
        /// Экземпляр класса Random для случайной генерации в методах
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Метод для заполнения полей базового класса Person
        /// </summary>
        /// <param name="person">Объект человека</param>
        /// <param name="sex">Пол</param>
        private static void FillRandomPerson(PersonBase person,
            Sex? sex = null)
        {
            //TODO: duplication
            string[] maleNames = ReadFile("Data/male_names.txt");
            string[] femaleNames = ReadFile("Data/female_names.txt");
            string[] lastNames = ReadFile("Data/lastnames.txt");

            Sex selectedSex = sex.HasValue 
                ? sex.Value 
                : (Sex)_random.Next(2);

            string firstName = selectedSex == Sex.Male
                ? maleNames[_random.Next(maleNames.Length)]
                : femaleNames[_random.Next(femaleNames.Length)];

            string lastNameBase = lastNames[_random.Next(lastNames.Length)];
            string lastName = CorrectLastName(lastNameBase, selectedSex);

            person.FirstName = firstName;
            person.LastName = lastName;
            person.Sex = selectedSex;
        }

        /// <summary>
        /// Метод случайно заполняющий поля класса Adult
        /// </summary>
        /// <param name="adult">Экземпляр класса Adult</param>
        private static void FillRandomAdult(Adult adult)
        {
            //TODO: duplication
            string[] jobPlaces = ReadFile("Data/jobs.txt");

            adult.PlaceOfJob = jobPlaces[_random.Next(jobPlaces.Length)];

            adult.Age = _random.Next(adult.MinAge, adult.MaxAge);

            adult.PassportSeries =
                PassportDataGeneration(Adult.QuantitySeriesDigits);
            adult.PassportNumber =
                PassportDataGeneration(Adult.QuantityPassportDigits);

            if (_random.Next(2) == 0)
            {
                Sex partnerSex = adult.Sex == Sex.Male ?
                    Sex.Female : Sex.Male;

                Adult partner = GetRandomAdult(partnerSex);

                partner.LastName = 
                    CorrectLastName(adult.LastName, partnerSex);

                adult.Partner = partner;
            }
        }

        /// <summary>
        /// Метод генерации данных для паспорта
        /// </summary>
        /// <param name="quantityDigits">Длина числа</param>
        /// <returns>Строку (серию или номер паспорта)</returns>
        private static string PassportDataGeneration(int quantityDigits)
        {
            string passportData = "";

            for (int i = 0; i < quantityDigits; i++)
            {
                passportData += _random.Next(0, 10).ToString();
            }

            return passportData;
        }

        /// <summary>
        /// Метод случайно заполняющий поля класса Child
        /// </summary>
        /// <param name="child">Экземпляр класса Child</param>
        private static void FillRandomChild(Child child)
        {
            //TODO: duplication
            string[] placeOfStudy = ReadFile("Data/study_places.txt");

            child.Age = _random.Next(child.MinAge, child.MaxAge);

            if (child.Age >= 6)
            {
                child.PlaceOfStudy =
                    placeOfStudy[_random.Next(placeOfStudy.Length)];
            }
            else
            {
                child.PlaceOfStudy = null;
            }

            Adult mother = GetRandomAdult(Sex.Female);
            child.Mother = mother;

            Adult father = GetRandomAdult(Sex.Male);
            child.Father = father;

            mother.LastName = CorrectLastName(father.LastName, Sex.Female);
            child.LastName = CorrectLastName(father.LastName, child.Sex);
        }

        /// <summary>
        /// Метод получения рандомного взрослого
        /// </summary>
        /// <param name="sex">Пол</param>
        /// <returns>Объект класса Adult</returns>
        public static Adult GetRandomAdult(Sex? sex = null)
        {
            Adult randomAdult = new Adult();
            FillRandomPerson(randomAdult, sex);
            FillRandomAdult(randomAdult);
            return randomAdult;
        }
        
        /// <summary>
        /// Метод получения рандомного ребёнка
        /// </summary>
        /// <returns>Объект класса Child</returns>
        public static Child GetRandomChild()
        {
            Child randomChild = new Child();
            FillRandomPerson(randomChild);
            FillRandomChild(randomChild);
            return randomChild;
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

        /// <summary>
        /// Метод корректирования фамилии под пол
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="targetSex">Требуемый пол</param>
        /// <returns>Строку с фамилией</returns>
        private static string CorrectLastName(string lastName, Sex targetSex)
        {
            if (targetSex == Sex.Female)
            {
                if (lastName.EndsWith("а"))
                    return lastName;
                return lastName + "а";
            }

            if (targetSex == Sex.Male && lastName.EndsWith("а"))
            {
                return lastName.Substring(0, lastName.Length - 1);
            }

            return lastName;
        }
    }
}
