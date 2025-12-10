namespace LaboratoryFirst
{
    /// <summary>
    /// Класс, работающий со списком людей (объектами класса Person)
    /// </summary>
    internal class PersonList
    {
        /// <summary>
        /// Список людей, принимает объекта класса Person
        /// </summary>
        private List<Person> _persons;
        
        /// <summary>
        /// Конструктор класса по умолчанию
        /// </summary>
        public PersonList()
        {
            _persons = new List<Person>();
        }

        /// <summary>
        /// Создает новый список людей с указанными элементами
        /// </summary>
        /// <param name="persons">
        /// Перечисление людей для инициализации списка</param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если параметр <paramref name="persons"/> равен null
        /// </exception>
        public PersonList(IEnumerable<Person> persons)
        {
            if (persons == null)
            {
                throw new ArgumentNullException(nameof(persons));
            }

            _persons = new List<Person>(persons);   
        }

        /// <summary>
        /// Возвращает количество людей в списке
        /// </summary>
        public int Count
        {
            get { return _persons.Count; }
        }

        /// <summary>
        /// Добавляет человека в список
        /// </summary>
        /// <param name="person">Объект класса Person</param>
        public void Add(Person person)
        {
            _persons.Add(person);
        }

        /// <summary>
        /// Удаляет человека из списка
        /// </summary>
        /// <param name="person">Объект класса Person</param>
        public void Remove(Person person)
        {
            _persons.Remove(person);
        }

        /// <summary>
        /// Удаляет человека из списка по индексу
        /// </summary>
        /// <param name="index">Индекс</param>
        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            _persons.RemoveAt(index);
        }

        /// <summary>
        /// Находит человека по инлдексу
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Объект человека</returns>
        public Person FindByIndex(int index)
        {
            ValidateIndex(index);
            return _persons[index];
        }

        /// <summary>
        /// Находит индекс указанного человека в списке
        /// </summary>
        /// <param name="person">Объект Person для поиска</param>
        /// <returns>Индекс первого вхождения человека в список</returns>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если параметр <paramref name="person"/> не найден
        /// </exception>
        public int IndexOf(Person person)
        {
            if (_persons.Contains(person))
            {
                return _persons.IndexOf(person);
            }
            else
            {
                throw new ArgumentException("Данный человек не найден");
            }
        }

        /// <summary>
        /// Очищает список людей
        /// </summary>
        public void Clear()
        {
            _persons.Clear();
        }

        /// <summary>
        /// Метод, проверяющий коректность индекса
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, в случае выхода индекса за диапазон</exception>
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _persons.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Индекс должен быть от 0 до {_persons.Count - 1}");
            }
        }
    }
}

