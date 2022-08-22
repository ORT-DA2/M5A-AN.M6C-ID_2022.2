using System;
using System.Collections;
using Domain;
using System.Collections.Generic;

namespace Logic.Interface
{
    public interface IPersonLogic
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        Person GetByName(string name);
    }
}
