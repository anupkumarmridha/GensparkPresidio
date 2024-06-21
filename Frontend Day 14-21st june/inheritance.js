class Employee
{
    constructor(name,designation,salary)
    {
        this.name=name
        this.designation=designation
        this.salary=salary
    }
    greet()
    {
        console.log("Hello welcome iam communicationg through parent class")
    }
}

class Manager extends Employee
{
    constructor(name,salary,designation,empId)
    {
        super(name,designation,salary)
        this.empId=empId
    }
    displayInformation()
    {
        console.log(`The name of employee is ${this.name} salary is ${this.salary}
            Designation is ${this.designation} and Employee ID is ${this.empId}`)
    }
}

let manager=new Manager('John','HR Manager',50000,100)
manager.greet()
manager.displayInformation()