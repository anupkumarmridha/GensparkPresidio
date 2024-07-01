# class in python
# class Student:
#     def __init__(self, name, age):
#         self.name = name
#         self.age = age

#     def display(self):
#         print("Name: ", self.name)
#         print("Age: ", self.age)
    
#     def __str__(self):
#         return "Name: "+self.name+" Age: "+str(self.age)
    
#     def __del__(self):
#         print("Destructor called")
    
# s1 = Student("John", 22)
# s1.display()
# print(s1)
# del s1

# Inheritance in python

class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def display(self):
        print("Name: ", self.name)
        print("Age: ", self.age)
    
    def __str__(self):
        return "Name: "+self.name+" Age: "+str(self.age)
    
    def __del__(self):
        print("Destructor called")

# single inheritance
   
class Student(Person):
    def __init__(self, name, age, rollno):
        super().__init__(name, age)
        self.rollno = rollno

    def display(self):
        super().display()
        print("Rollno: ", self.rollno)
    
    def __str__(self):
        return super().__str__()+" Rollno: "+str(self.rollno)
    
    def __del__(self):
        print("Destructor called")

s1 = Student("John", 22, 101)
# s1.display()
print(s1)
del s1
# Destructor called

# multiple inheritance
class Address:
    def __init__(self, city, state):
        self.city = city
        self.state = state

    def display(self):
        print("City: ", self.city)
        print("State: ", self.state)
    
    def __str__(self):
        return "City: "+self.city+" State: "+self.state
    
    def __del__(self):
        print("Destructor called")

class Employee(Person, Address):
    def __init__(self, name, age, city, state, empid):
        Person.__init__(self, name, age)
        Address.__init__(self, city, state)
        self.empid = empid

    def display(self):
        Person.display(self)
        Address.display(self)
        print("Empid: ", self.empid)
    
    def __str__(self):
        return Person.__str__(self)+" "+Address.__str__(self)+" Empid: "+str(self.empid)
    
    def __del__(self):
        print("Destructor called")

e1 = Employee("John", 22, "Delhi", "Delhi", 101)
# e1.display()
print(e1)
del e1
# Destructor called


# multilevel inheritance
class A:
    def display(self):
        print("A class")
    
    def __del__(self):
        print("Destructor called")
    
class B(A):
    def display(self):
        print("B class")
    
    def __del__(self):
        print("Destructor called")

class C(B):
    def display(self):
        print("C class")
    
    def __del__(self):
        print("Destructor called")
        
c1 = C()
c1.display()
del c1





