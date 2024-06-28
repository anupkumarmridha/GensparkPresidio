# 2) Functions in Python

# Functions are reusable blocks of code that perform a specific task.
# Functions are defined using the def keyword followed by the function name and parentheses.
# Functions can take parameters or arguments.
# Functions can return values using the return keyword.
# Functions can have default arguments.
# Functions can have variable-length arguments.
# Functions can have keyword arguments.
# Functions can be called with named arguments.
# Functions can be called with positional arguments.
# Functions can be called with keyword arguments.
# Functions can be called with default arguments.
# Functions can be called with variable-length arguments.

# Function Definition
def greet():
    print("Hello, World!")

# Function Call
greet()

# Function Definition with Parameters
def greet_with_name(name):
    print("Hello, " + name + "!")

# Function Call with Arguments
greet_with_name("Anup")

# Function Definition with Default Arguments

def greet_with_default_name(name="World"):
    print("Hello, " + name + "!")

# Function Call with Default Arguments
greet_with_default_name()

# # Functions can return values using the return keyword.

def add(a, b):
    return a + b

result = add(2, 3)
print(result)

# Functions can have variable-length arguments.

def add(*args):
    result = 0
    for arg in args:
        result += arg
    return result

result = add(2, 3, 4, 5)
print(result)

# Functions can have keyword arguments.

def add(*args, **kwargs):
    result = 0
    for arg in args:
        result += arg
    for key in kwargs:
        result += kwargs[key]
    return result
result = add(2, 3, 4, 5, a=6, b=7)
print(result)

# example of calling function with keyargs
def greet(*args, **kwargs):
    print("Hello, " + kwargs["name"] + "!")
greet(name="Anup")

def greet_with_name(name="World", greeting="Hello"):
    print(greeting + ", " + name + "!")

greet_with_name(greeting="Hi", name="Anup")


