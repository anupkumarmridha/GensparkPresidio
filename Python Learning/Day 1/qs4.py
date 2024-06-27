#4) Take name, age, date of birth and phone print details in proper format
class Person:
    def __init__(self, name, age, dob, phone):
        self.name = name
        self.age = age
        self.dob = dob
        self.phone = phone
    def __str__(self):
        return f"\n Name: {self.name},\n Age: {self.age},\n DOB: {self.dob},\n Phone: {self.phone}"
name = input("Enter your name: ")
age = input("Enter your age: ")
dob = input("Enter your DOB: ")
phone = input("Enter your phone: ")
p = Person(name, age, dob, phone)
print(p)