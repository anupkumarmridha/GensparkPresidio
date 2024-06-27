
# Iterations in Python
#    For loop

print("For loop")
for i in range(5):
    print(i)

#    While loop
print("While loop")
i=0
while i<5:
    print(i)
    i+=1
#    Loop control statements
#    Break statement
print("Break statement")
for i in range(5):
    if i==3:
        break
    print(i)
    
#    Continue statement
print("Continue statement")
for i in range(5):
    if i==3:
        continue
    print(i)

#    Pass statement
print("Pass statement")
for i in range(5):
    pass
    
#    Looping through a string

print("Looping through a string")
for i in "Hello":
    print(i)

    
#    Looping through a list
# In Python, a list is a collection that is ordered and changeable.
# In Python, a list can contain elements of different data types.
# In Python, a list is created by placing all the items (elements) inside square brackets [], separated by commas.
# In Python, a list can have any number of items and they may be of different types (integer, float, string, etc.).
print("Looping through a list")
for i in [10,20,30,40]:
    print(i)

#    Looping through a tuple
print("Looping through a tuple")
for i in (10,20,30,40):
    print(i)

#    Looping through a dictionary
# In Python, a dictionary is a collection that is unordered, changeable, and indexed.
# In Python, a dictionary is a collection of key-value pairs.
# In Python, a dictionary is created by placing all the items (key-value pairs) inside curly braces {}, separated by commas.
# In Python, a dictionary can have any number of items and they may be of different types (integer, float, string, etc.).
# In Python, a dictionary key must be unique and immutable. 
# A dictionary key can be of any data type such as a string, integer, float, or tuple.
# In Python, a dictionary value can be of any data type such as a string, integer, float, list, or dictionary.


print("Looping through a dictionary")
d={1:"One",2:"Two",3:"Three"}
for i in d:
    print(i)

#In Python, the dictionary values() method returns a view object that displays a list of a dictionary's values.
print("Looping through a dictionary using values")
for i in d.values():
    print(i)
    
# In Python, the dictionary items() method returns a view object that displays a list of a dictionary's key-value tuple pairs.
print("Looping through a dictionary using items")
for i in d.items():
    print(i)

# In Python, the dictionary keys() method returns a view object that displays a list of a dictionary's keys.
print("Looping through a dictionary using keys")
for i in d.keys():
    print(i)

print("Looping through a dictionary using keys and values")
for i,j in d.items():
    print(i,j)

print("Looping through a dictionary using keys and values using tuple unpacking")
for i in d.items():
    print(i[0],i[1])



#    Looping through a set

# In Python, a set is an unordered collection of items.
# Every element is unique (no duplicates) and must be immutable (which cannot be changed).
s={10,20,30,40}
print("Looping through a set")  
for i in s:
    print(i)

#    Looping through a range
# The range() function takes one, two, or three arguments.
# In Python, the range() function generates a sequence of numbers.
# The range() function returns a sequence of numbers, starting from 0 by default, and increments by 1 (by default),
# and stops before a specified number. 
# for example, range(5) will generate numbers from 0 to 4.
# and range(10,20) will generate numbers from 10 to 19.
# and range(10,20,2) will generate numbers from 10 to 19 with a step of 2.

print("Looping through a range with steps of 2")
for i in range(1,10,2):
    print(i)

#    Nested loops
#    Looping through a list of lists
for i in [[10,20],[30,40],[50,60]]:
    for j in i:
        print(j)
        
#    Looping through a list of tuples
for i in [(10,20),(30,40),(50,60)]:
    for j in i:
        print(j)

#    Looping through a list of dictionaries
for i in [{"a":10,"b":20},{"c":30,"d":40},{"e":50,"f":60}]:
    for j in i:
        print(j)

#    Looping through a list of sets
for i in [{10,20},{30,40},{50,60}]:
    for j in i:
        print(j)
        
#    Looping through a list of strings
for i in ["Hello","World"]:
    for j in i:
        print(j)

#    Looping through a list of numbers
for i in [10,20,30,40]:
    for j in range(i):
        print(j)

#    Looping through a list of characters
for i in ['H','e','l','l','o']:
    print(i)
    
#    Looping through a list of boolean values
for i in [True,False]:
    print(i)

#    Looping through a list of floats
for i in [10.5,20.5,30.5,40.5]:
    print(i)
    
#    Looping through a list of complex numbers

for i in [10+20j,30+40j,50+60j]:
    print(i)
    
#    Looping through a list of bytes
for i in [b'Hello',b'World']:
    print(i)

#    Looping through a list of bytearrays
for i in [bytearray(b'Hello'),bytearray(b'World')]:
    print(i)

#    Looping through a list of memoryviews
for i in [memoryview(b'Hello'),memoryview(b'World')]:
    print(i)

#    Looping through a list of range
for i in [range(10),range(20),range(30)]:
    for j in i:
        print(j)
    