using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndritzHydro.Tuccos.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public IList<Employee> Employees { get; private set; }
    }
}
