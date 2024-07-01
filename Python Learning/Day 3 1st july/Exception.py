# Exception handling in python
# Python has many built-in exceptions that are raised when your program encounters an error (something in the program goes wrong).
# When these exceptions occur, the Python interpreter stops the current process and passes it to the calling process until it is handled.
# If not handled, the program will crash.

# In python, exceptions can be handled using a try statement.
# The critical operation which can raise an exception is placed inside the try clause.
# The code that handles the exceptions is written in the except clause.
# We can thus choose what operations to perform once we have caught the exception.
# finally block is executed no matter what.

# Example of Exception Handling
try:
    a = 10/0
    print(a)
except ZeroDivisionError:
    print("You are dividing by zero")
except:
    print("Any other exception")
finally:
    print("This block will always be executed")
    
    
# Custom Exception
# You can create your exception in python.
# In python, users can define custom exceptions by creating a new class.
# This exception class has to be derived, either directly or indirectly, from the built-in Exception class.
# Most of the built-in exceptions are also derived from this class.

# Example of Custom Exception
class MyError(Exception):
    def __init__(self, value):
        self.value = value
    def __str__(self):
        return str(self.value)

try:
    raise(MyError(3*2))
except MyError as error:
    print('A New Exception occured: ',error)



