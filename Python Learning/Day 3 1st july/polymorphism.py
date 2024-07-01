# polymorphism in python with example

# Polymorphism in python
# Polymorphism is an ability (in OOP) to use a common interface for multiple forms (data types).
# Suppose, we need to color a shape, there are multiple shape options (rectangle, square, circle).
# However we could use the same method to color any shape. This concept is called Polymorphism.
# Polymorphism is based on the greek words Poly (many) and morphism (forms).
# We will create a structure of a class with a method that will be overridden by a subclass.
# In python types of polymorphism are:
# 1. Duck Typing
# 2. Operator Overloading
# 3. Method Overloading
# 4. Method Overriding

# 1. Duck Typing
# If it looks like a duck, swims like a duck, and quacks like a duck, then it probably is a duck.
# In python, we can use any object in the same way, regardless of its class.
# If an object implements a method, then we can use that method on that object.
# This is called duck typing.
# Duck typing is a concept related to dynamic typing, where the type or class of an object is less important than the methods it defines.
# When you use duck typing, you do not check types at all. Instead, you check for the presence of a given method or attribute.

# Example of Duck Typing
class Parrot:
    def fly(self):
        print("Parrot can fly")
    
    def swim(self):
        print("Parrot can't swim")
        
class Penguin:
    def fly(self):
        print("Penguin can't fly")
    
    def swim(self):
        print("Penguin can swim")
        
# common interface
def flying_test(bird):
    bird.fly()

# instantiate objects
blu = Parrot()
peggy = Penguin()

# passing the object
flying_test(blu)
flying_test(peggy)


# 2. Operator Overloading
# Operator Overloading means giving extended meaning beyond their predefined operational meaning.
# For example operator + is used to add two integers as well as join two strings and merge two lists.
# It is achievable because ‘+’ operator is overloaded by int class and str class.
# You might have noticed that the same built-in operator or function shows different behavior for objects of different classes.
# This is called Operator Overloading.
# Python operators work for built-in classes. But the same operator behaves differently with different types.
# For example, the + operator will perform arithmetic addition on two numbers, merge two lists, or concatenate two strings.

# Example of Operator Overloading

class Point:
    def __init__(self, x=0, y=0):
        self.x = x
        self.y = y
        
    def __str__(self):
        return "({0},{1})".format(self.x, self.y)
    
    def __add__(self, other):
        x = self.x + other.x
        y = self.y + other.y
        return Point(x, y)

p1 = Point(2, 3)
p2 = Point(-1, 2)

print(p1 + p2)

# 3. Method Overloading
# Method Overloading is the ability to define multiple methods of the same name, but with different signatures.
# Method overloading is not possible in Python.
# We may overload the methods but can only use the latest defined method.
# In Python, we can define a method in such a way that there are multiple ways to call it.
# However, the latest defined method will be used.
# Example of Method Overloading

class Human:
    def sayHello(self, name=None):
        if name is not None:
            print("Hello " + name)
        else:
            print("Hello ")
    def __str__(self) -> str:
        return "This is a human class"
    
obj = Human()
obj.sayHello()
obj.sayHello("John")

# 4. Method Overriding
# Method overriding is a feature that allows a subclass to provide a specific implementation of a method that is already provided by its superclass.
# When a method in a subclass has the same name, same parameters or signature, and same return type as a method in its super-class, then the method in the subclass is said to override the method in the super-class.
# The version of a method that is executed will be determined by the object that is used to invoke it.
# If an object of a parent class is used to invoke the method, then the version in the parent class will be executed, but if an object of the subclass is used to invoke the method, then the version in the child class will be executed.
# In Python, method overriding is an object-oriented programming feature that allows a subclass to provide a specific implementation of a method that is already provided by its superclass.

# Example of Method Overriding

class Parent:
    def show(self):
        print("Parent method")
        
class Child(Parent):
    def show(self):
        print("Child method")
        
obj = Child()
obj.show()

obj1 = Parent()
obj1.show()

# In the above example, we have two classes Parent and Child. The show() method is defined in both the Parent and Child classes.
# When we call the show() method using the object of the Child class, the Child class version of the method is called.
# When we call the show() method using the object of the Parent class, the Parent class version of the method is called.
