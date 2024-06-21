
// Base Person class (prototype-based inheritance)
function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
}

// Encapsulation: Using prototype to define methods
Person.prototype.getFullName = function() {
    return `${this.firstName} ${this.lastName}`;
};

// Student class inherits from Person
function Student(firstName, lastName, age, studentId, courses) {
    // Inheritance
    Person.call(this, firstName, lastName, age);
    this.studentId = studentId;
    this.courses = courses; // Encapsulation
}

// Inheritance: Linking prototypes
Student.prototype = Object.create(Person.prototype);
Student.prototype.constructor = Student;

// Abstraction: Hiding implementation details
Student.prototype.getCourses = function() {
    return this.courses.join(', ');
};

Student.prototype.addCourse = function(course) {
    this.courses.push(course);
};

// Polymorphism: Overriding method
Student.prototype.getFullName = function() {
    return `${this.firstName} ${this.lastName}, ID: ${this.studentId}`;
};


const student1 = new Student('John', 'Doe', 21, 'S12345', ['Math', 'Physics']);
console.log(student1.getFullName()); 
console.log(student1.getCourses());  
student1.addCourse('Chemistry');
console.log(student1.getCourses());  

const student2 = new Student('Jane', 'Smith', 22, 'S67890', ['Biology', 'Chemistry']);
console.log(student2.getFullName()); 
console.log(student2.getCourses());  
student2.addCourse('Math');
console.log(student2.getCourses());  
