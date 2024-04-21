namespace EmployeeManagmentModelLibery
{
    public class EmployeeModel
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Department { get; private set; }
        public decimal Salary { get; private set; }
        public EmployeeModel(string name, string department, decimal salary)
        {
            Id = 0;
            Name = name;
            Department = department;
            Salary = salary;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public void SetName(string newName)
        {
            Name = newName;
        }
        public void SetDepartment(string newDepartmentName)
        {
            Department = newDepartmentName;
        }
        public void SetSalary(decimal newSalary)
        {
            Salary = newSalary;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Department: {Department}, Salary:{Salary}";
        }

    }
}
