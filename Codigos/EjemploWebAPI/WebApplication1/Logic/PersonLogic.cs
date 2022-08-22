using Domain;
using Logic.Interface;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class PersonLogic : IPersonLogic
    {
        public IEnumerable<Person> GetAll()
        {
            Person person = new Person()
            {
                Id = 1,
                Name = "Nicolás",
                Age = 25
            };
            Person person2 = new Person()
            {
                Id = 2,
                Name = "Eustaquio",
                Age = 67
            };
            Person person3 = new Person()
            {
                Id = 3,
                Name = "Jacinta",
                Age = 40
            };
            List<Person> people = new List<Person>
            {
                person,
                person2,
                person3
            };
            return people;
        }

        public Person GetById(int id)
        {
            if (id == 1)
                return new Person()
                {
                    Id = id,
                    Name = "Nicolás",
                    Age = 25
                };
            else return null;
        }

        public Person GetByName(string name)
        {
            return new Person()
            {
                Id = 1,
                Name = name,
                Age = 25
            };
        }
    }
}
