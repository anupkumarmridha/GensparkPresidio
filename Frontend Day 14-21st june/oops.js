function employeeDetails(employeeName,employeeSalary){
    this.employeeName=employeeName
    this.employeeSalary=employeeSalary
    this.displayDetails=()=>{
        return "Employee name is "+this.employeeName+" and salary is "+this.employeeSalary
    }
}
const firstEmployee= new employeeDetails('John',20000)
const secondEmployee= new employeeDetails('Mary',30000)

// console.log(firstEmployee.displayDetails())
// console.log(secondEmployee.displayDetails())
console.log(firstEmployee.employeeName)
console.log(secondEmployee.employeeName)