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
        /// <param name="persons">Перечисление людей для инициализации списка</param>
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
        /// Добавляет указанного человека в список
        /// </summary>
        /// <param name="person">Объект Person для добавления</param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если параметр <paramref name="person"/> равен null
        /// </exception>
        public void Add(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(
                    nameof(person),
                    "Person cannot be null");
            }

            _persons.Add(person);
        }

        /// <summary>
        /// Удаляет указанного человека из списка
        /// </summary>
        /// <param name="person">Объект Person для удаления</param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если параметр <paramref name="person"/> равен null
        /// </exception>
        public void Remove(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(
                    nameof(person), 
                    "Person cannot be null");
            }
            _persons.Remove(person);
        }

        /// <summary>
        /// Удаляет человека из списка по индексу
        /// </summary>
        /// <param name="index">Индекс человека в списке</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если параметр <paramref name="index"/>
        /// меньше 0 или больше/равен размеру списка
        /// </exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _persons.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Index can't be less 0 or above {_persons.Count - 1}!");
            }

            _persons.RemoveAt(index);
        }

        /// <summary>
        /// Находит человека по заданному индексу
        /// </summary>
        /// <param name="index">Индекс человека в списке</param>
        /// <returns>Объект класса Person по индексу</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Возникает, если параметр <paramref name="index"/>
        /// меньше 0 или больше/равен размеру списка
        /// </exception>
        public Person FindByIndex(int index)
        {
            if (index < 0 || index >= _persons.Count)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(index),
                    $"Index can't be less 0 or above {_persons.Count - 1}!");
            }

            return _persons[index];
        }

        /// <summary>
        /// Находит индекс указанного человека в списке
        /// </summary>
        /// <param name="person">Объект Person для поиска</param>
        /// <returns>Индекс первого вхождения человека в список</returns>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если параметр <paramref name="person"/> равен null
        /// </exception>
        public int IndexOf(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(
                    nameof(person),
                    "Person cannot be null");
            }

            return _persons.IndexOf(person);
        }

        /// <summary>
        /// Очищает список людей
        /// </summary>
        public void Clear()
        {
            _persons.Clear();
        }
    }
}

