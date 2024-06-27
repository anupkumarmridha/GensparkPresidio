#5) Add validation the entered  name, age, date of birth and phone print details in proper format
import datetime

class Person:
    def __init__(self, name, age, dob, phone):
        self.name = name
        self.age = age
        self.dob = dob
        self.phone = phone
    def __str__(self):
        return f"\n Name: {self.name},\n Age: {self.age},\n DOB: {self.dob},\n Phone: {self.phone}"
    
    def is_date(self, date_str):
        try:
            datetime.datetime.strptime(date_str, "%d-%m-%Y")
            return True
        except ValueError:
            return False


    def validate(self):
        if self.name.isalpha() and self.age.isdigit() and self.is_date(self.dob) and self.phone.isdigit():
            return True
        else:
            return False

# name = input("Enter your name: ")
# age = input("Enter your age: ")
# dob =input("Enter your DOB: ")
# phone = input("Enter your phone: ")
# p = Person(name, age, dob, phone)
p=Person("Rahul", "25", "12-12-1995", "1234567890")
if p.validate():
    print(p)
else:
    print("Invalid input")
