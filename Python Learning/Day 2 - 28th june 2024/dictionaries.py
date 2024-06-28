# 4) Dictionaries

# Dictionaries are unordered collections of items.
# Dictionaries are mutable, which means you can modify them after they are created.
# Dictionaries are indexed by keys.
# Dictionaries are defined by enclosing the elements in curly braces {}.
# Dictionaries are composed of key-value pairs.
# Dictionaries are optimized for retrieving data.
# Dictionaries can contain elements of different types.
# Dictionaries can be nested.
# Dictionaries can be created using the dict() constructor.
# Dictionaries can be created using a comma-separated sequence of key-value pairs.
# Dictionaries can be created using a comma-separated sequence of key-value pairs within curly braces {}.
# Dictionaries can be created using a comma-separated sequence of key-value pairs within curly braces {} with the dict() constructor.

# Dictionary Creation
# Dictionaries are defined by enclosing the elements in curly braces {}.

# empty dictionary
d = {}
print(d)

# dictionary with single element
d = {1: "Hello"}
print(d)

# dictionary with multiple elements
d = {1: "Hello", 2: "World"}
print(d)

# dictionary with elements of different types
d = {1: "Hello", "World": 2}
print(d)

# nested dictionary
d = {1: {2: "Hello"}, 3: {4: "World"}}
print(d)

# Dictionary Indexing
# Dictionaries are indexed by keys.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d[1])  # Hello
print(d[2])  # World
print(d[3])  # Python

# Dictionary Slicing
# Dictionaries cannot be sliced using the colon operator (:).
# The colon operator is used to slice the dictionary from the start index to the end index.
# The start index is included in the slice.
# The end index is excluded from the slice.

d = {1: "Hello", 2: "World", 3: "Python"}
# print(d[:])  # TypeError: unhashable type: 'slice'

# Dictionary Concatenation
# Dictionaries cannot be concatenated using the plus operator (+).

d1 = {1: "Hello"}
d2 = {2: "World"}
# print(d1 + d2)  # TypeError: unsupported operand type(s) for +: 'dict' and 'dict'

# Dictionary Modification
# Dictionaries are mutable, which means you can modify them after they are created.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d)

# add a new key-value pair
d[4] = "Java"
print(d)

# update an existing key-value pair
d[3] = "JavaScript"
print(d)

# remove a key-value pair
del d[2]
print(d)

# Dictionary Methods
# Dictionaries have several built-in methods that you can use to perform common operations.

# clear() - Removes all the elements from the dictionary.

d = {1: "Hello", 2: "World", 3: "Python"}
d.clear()
print(d)

# copy() - Returns a shallow copy of the dictionary.

d = {1: "Hello", 2: "World", 3: "Python"}
d1 = d.copy()
print(d1)

# fromkeys() - Returns a new dictionary with the specified keys and values.

keys = [1, 2, 3]
values = ["Hello", "World", "Python"]
d = dict.fromkeys(keys, values)
print(d)

# get() - Returns the value of the specified key.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d.get(1))  # Hello
print(d.get(2))  # World
print(d.get(3))  # Python

# items() - Returns a list containing a tuple for each key-value pair.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d.items())

# keys() - Returns a list containing the dictionary's keys.
d = {1: "Hello", 2: "World", 3: "Python"}
print(d.keys())

# pop() - Removes the element with the specified key.

d = {1: "Hello", 2: "World", 3: "Python"}
d.pop(2)
print(d)

# popitem() - Removes the last inserted key-value pair.

d = {1: "Hello", 2: "World", 3: "Python"}
d.popitem()
print(d)

# setdefault() - Returns the value of the specified key. If the key does not exist, insert the key with the specified value.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d.setdefault(1))  # Hello
print(d.setdefault(4, "Java"))  # Java
print(d)

# update() - Updates the dictionary with the specified key-value pairs.

d = {1: "Hello", 2: "World", 3: "Python"}
d1 = {4: "Java", 5: "JavaScript"}
d.update(d1)
print(d)



# values() - Returns a list of all the values in the dictionary.

d = {1: "Hello", 2: "World", 3: "Python"}
print(d.values())

# Dictionary Comprehension
# Dictionary comprehension is a concise way to create dictionaries using an expression.

# Dictionary Comprehension Syntax
# {key: value for (key, value) in iterable}

# Dictionary Comprehension Example
# Create a dictionary with numbers as keys and their squares as values.

d = {x: x ** 2 for x in range(5)}
print(d)

# Dictionary Comprehension with Condition

# Dictionary Comprehension Syntax
# {key: value for (key, value) in iterable if condition}

# Dictionary Comprehension Example
# Create a dictionary with numbers as keys and their squares as values if the number is even.

d = {x: x ** 2 for x in range(5) if x % 2 == 0}
print(d)

# Nested Dictionary Comprehension

# Nested Dictionary Comprehension Syntax
# {key: {key: value for (key, value) in iterable} for key in iterable}

# Nested Dictionary Comprehension Example
# Create a nested dictionary with numbers as keys and their squares as values.

d = {x: {y: y ** 2 for y in range(5)} for x in range(5)}
print(d)

# Dictionary as Function Argument
# Dictionaries can be used as function arguments.
# You can pass a dictionary as an argument to a function.

def greet(d):
    for key in d:
        print(key, d[key])
        
d = {1: "Hello", 2: "World", 3: "Python"}
greet(d)

# Dictionary as Return Value
# Dictionaries can be used as return values from functions.
# You can return a dictionary from a function.

def create_dict():
    return {1: "Hello", 2: "World", 3: "Python"}

d = create_dict()

print(d)

# Dictionary Length

# The len() function returns the number of key-value pairs in the dictionary.

d = {1: "Hello", 2: "World", 3: "Python"}
print(len(d))

# Dictionary Membership

# The in keyword checks if the specified key is present in the dictionary.

d = {1: "Hello", 2: "World", 3: "Python"}
print(1 in d)  # True
print(4 in d)  # False
print(2 in d)  # True
print(5 in d)  # False
print(3 in d)  # True
print(6 in d)  # False


