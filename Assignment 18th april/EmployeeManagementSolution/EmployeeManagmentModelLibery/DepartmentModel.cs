using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagmentModelLibery
{
    public class DepartmentModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public DepartmentModel(string name)
        {
            Id = 0;
            Name = name;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetName(string newName)
        {
            Name = newName;
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
