using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryOOP
{
    /// <summary>
    /// Класс описывающий сущность человека
    /// 
    /// </summary>
    internal class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private Sex _sex;
        /// <summary>
        /// Пол человека
        /// </summary>
        public enum Sex
        {
            /// <summary>
            /// Женский
            /// </summary>
            Female,
            /// <summary>
            /// Мужской
            /// </summary>
            Male
        }

        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="sex">Пол</param>
        public Person(string firstName, string lastName, int age, Sex sex)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _sex = sex;
        }
    }
}
