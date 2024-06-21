// Encapsulation: Define the Person class with private properties and methods
class Person {
    #name;
    #age;

    constructor(name, age) {
        this.#name = name;
        this.#age = age;
    }

    // Public method to access private property
    getName() {
        return this.#name;
    }

    // Public method to access private property
    getAge() {
        return this.#age;
    }

    // Abstraction: Public method to provide a general greeting functionality
    greet() {
        console.log(`Hello, my name is ${this.#name} and I am ${this.#age} years old.`);
    }
}

// Inheritance: Define the Student class that extends the Person class
class Student extends Person {
    #studentID;

    constructor(name, age, studentID) {
        super(name, age); // Call the parent constructor
        this.#studentID = studentID;
    }

    // Polymorphism: Override the greet method
    greet() {
        console.log(`Hello, I am ${this.getName()}, a student with ID: ${this.#studentID}.`);
    }

    // Additional method specific to Student
    study() {
        console.log(`${this.getName()} is studying. Their student ID is ${this.#studentID}.`);
    }
}

const student1 = new Student('John Doe', 20, 'S12345');
console.log(student1.getName()); 
console.log(student1.getAge());  
student1.greet(); 


student1.study(); 

