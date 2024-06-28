# 3) Tuples operations
# Tuples are immutable sequences, typically used to store collections of heterogeneous data.
# Tuples are immutable, which means you cannot modify them once they are created.
# Tuples are defined by enclosing the elements in parentheses ().
# Tuples are indexed by integers.
# Tuples are ordered, which means they maintain the order of the elements.
# Tuples can contain elements of different types.
# Tuples can be nested.
# Tuples can be created using the tuple() constructor.
# Tuples can be created using a comma-separated sequence of elements.

# Tuple Creation
# Tuples are defined by enclosing the elements in parentheses ().
# Tuples can contain elements of different types.
# Tuples can be nested.

# empty tuple
t = ()
print(t)

# tuple with single element
t = (1,)
print(t)

# tuple with multiple elements
t = (1, 2, 3)
print(t)

# tuple with elements of different types
t = (1, "Hello", 3.4)
print(t)

# nested tuple
t = (1, (2, 3), (4, 5, 6))
print(t)

# Tuple Indexing
# Tuples are indexed by integers.
# Tuples are ordered, which means they maintain the order of the elements.

t = (1, 2, 3, 4, 5)
print(t[0])  # 1
print(t[1])  # 2
print(t[2])  # 3
print(t[3])  # 4
print(t[4])  # 5

# Tuple Slicing
# Tuples can be sliced using the colon operator (:).
# The colon operator is used to slice the tuple from the start index to the end index.
# The start index is included in the slice.
# The end index is excluded from the slice.

t = (1, 2, 3, 4, 5)
print(t[:])  # (1, 2, 3, 4, 5)
print(t[1:])  # (2, 3, 4, 5)
print(t[:4])  # (1, 2, 3, 4)
print(t[1:4])  # (2, 3, 4)

# Tuple Concatenation
# Tuples can be concatenated using the addition operator (+).

t1 = (1, 2, 3)
t2 = (4, 5, 6)
t3 = t1 + t2
print(t3)  # (1, 2, 3, 4, 5, 6)

# Tuple Repetition
# Tuples can be repeated using the multiplication operator (*).

t = (1, 2, 3)
t1 = t * 3
print(t1)  # (1, 2, 3, 1, 2, 3, 1, 2, 3)

# Tuple Membership
# You can check if an element is present in a tuple using the in operator.

t = (1, 2, 3, 4, 5)
print(1 in t)  # True
print(6 in t)  # False

# Tuple Length
# You can find the length of a tuple using the len() function.

t = (1, 2, 3, 4, 5)
print(len(t))  # 5

# Tuple Iteration
# You can iterate over a tuple using a for loop.

t = (1, 2, 3, 4, 5)
for i in t:
    print(i)
    

# Tuple Comparison
# Tuples can be compared using the comparison operators (<, >, <=, >=, ==, !=).

t1 = (1, 2, 3)
t2 = (4, 5, 6)
print(t1 < t2)  # True
print(t1 > t2)  # False
print(t1 == t2)  # False
print(t1 != t2)  # True

# Tuple Methods
# Tuples have only two methods: count() and index().
# count() method returns the number of occurrences of a specified value in the tuple.
# index() method returns the index of the first occurrence of a specified value in the tuple.

t = (1, 2, 3, 4, 5, 1, 2, 3)
print(t.count(1))  # 2
print(t.index(3))  # 2

# Tuple Packing and Unpacking
# Tuple packing is the process of packing multiple values into a tuple.
# Tuple unpacking is the process of unpacking a tuple into multiple values.

# Tuple Packing
t = 1, 2, 3
print(t)  # (1, 2, 3)

# Tuple Unpacking
a, b, c = t
print(a)  # 1
print(b)  # 2
print(c)  # 3

# Tuple Constructor
# Tuples can be created using the tuple() constructor.

t = tuple((1, 2, 3))
print(t)  # (1, 2, 3)

# Tuple Comprehension
# Tuples do not support comprehension like lists.
# However, you can use a generator expression to create a tuple.

t = tuple(i for i in range(5))
print(t)  # (0, 1, 2, 3, 4)

# Tuple as Dictionary Key
# Tuples can be used as keys in dictionaries.
# Tuples are hashable if all their elements are hashable.

d = {(1, 2): "Hello", (3, 4): "World"}
print(d[(1, 2)])  # Hello
print(d[(3, 4)])  # World

# Tuple as Function Arguments
# Tuples can be used as function arguments.
# You can pass a tuple as an argument to a function.

def add(a, b):
    return a + b

t = (2, 3)
print(add(*t))  # 5

# Tuple as Return Value
# Tuples can be used as return values from functions.
# You can return a tuple from a function.

def add_sub(a, b):
    return a + b, a - b

t = add_sub(5, 3)
print(t)  # (8, 2)
