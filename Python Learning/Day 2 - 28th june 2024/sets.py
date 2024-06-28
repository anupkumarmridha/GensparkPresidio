# 5) Sets

# Sets are unordered collections of unique elements. Sets are mutable, which means you can add or remove elements from the set. Sets are defined by enclosing the elements in curly braces {}.

# Sets are unordered, which means they do not maintain the order of the elements.

# Sets are optimized for checking if an element is present in the set.

# Sets can contain elements of different types.

# Sets can be created using the set() constructor.

# Sets can be created using a comma-separated sequence of elements within curly braces {}.

# Sets can be created using a comma-separated sequence of elements within curly braces {} with the set() constructor.

# Set Creation

# Sets are defined by enclosing the elements in curly braces {}.

# empty set

s = set()
print(s)

# set with single element

s = {1}
print(s)

# set with multiple elements

s = {1, 2, 3}
print(s)

# set with elements of different types

s = {1, "Hello", 3.4}
print(s)

# Set Indexing

# Sets are unordered, which means they do not maintain the order of the elements.

# Sets are indexed by integers.

s = {1, 2, 3, 4, 5}
# print(s[0])  # TypeError: 'set' object is not subscriptable

# Set Slicing

# Sets cannot be sliced using the colon operator (:).

# The colon operator is used to slice the set from the start index to the end index.

# The start index is included in the slice.

# The end index is excluded from the slice.

# print(s[:])  # TypeError: 'set' object is not subscriptable

# Set Concatenation

# Sets cannot be concatenated using the plus operator (+).

s1 = {1, 2, 3}
s2 = {4, 5, 6}
# print(s1 + s2)  # TypeError: unsupported operand type(s) for +: 'set' and 'set'

# Set Modification

# Sets are mutable, which means you can modify them after they are created.

s = {1, 2, 3, 4, 5}
print(s)

# add a new element

s.add(6)
print(s)

# add multiple elements

s.update([7, 8, 9])
print(s)

# remove an element

s.remove(9)
print(s)

# remove an element that does not exist

# s.remove(10)  # KeyError: 10

# remove an element using discard

s.discard(10)
print(s)

# remove an element using pop

s.pop()
print(s)

# remove all elements

s.clear()
print(s)

# Set Operations

# Sets support various operations such as union, intersection, difference, and symmetric difference.

# Union

# The union of two sets A and B is a set that contains all the elements of A and B.

# The union of two sets A and B is denoted by A | B.

A = {1, 2, 3, 4, 5}
B = {4, 5, 6, 7, 8}

print(A | B)  # {1, 2, 3, 4, 5, 6, 7, 8}

# Intersection

# The intersection of two sets A and B is a set that contains all the elements that are common to both A and B.

# The intersection of two sets A and B is denoted by A & B.

print(A & B)  # {4, 5}

# Difference

# The difference of two sets A and B is a set that contains all the elements that are present in A but not in B.

# The difference of two sets A and B is denoted by A - B.

print(A - B)  # {1, 2, 3}

# Symmetric Difference

# The symmetric difference of two sets A and B is a set that contains all the elements that are present in A but not in B, and all the elements that are present in B but not in A.

# The symmetric difference of two sets A and B is denoted by A ^ B.

print(A ^ B)  # {1, 2, 3, 6, 7, 8}

# Set Methods

# Sets have several built-in methods that you can use to perform common operations.

# add() - Adds an element to the set.

s = {1, 2, 3}
s.add(4)
print(s)

# update() - Adds multiple elements to the set.

s.update([5, 6, 7])
print(s)

# remove() - Removes an element from the set.

s.remove(7)
print(s)

# discard() - Removes an element from the set if it is present.

s.discard(6)
print(s)

# pop() - Removes and returns an arbitrary element from the set.

print(s.pop())
print(s)

# clear() - Removes all the elements from the set.

s.clear()
print(s)

# copy() - Returns a shallow copy of the set.

s = {1, 2, 3}
s1 = s.copy()
print(s1)

# difference() - Returns a set containing the difference between two or more sets.

A = {1, 2, 3, 4, 5}
B = {4, 5, 6, 7, 8}
print(A.difference(B))  # {1, 2, 3}

# intersection() - Returns a set containing the intersection of two or more sets.

print(A.intersection(B))  # {4, 5}

# isdisjoint() - Returns True if two sets have a null intersection.

A = {1, 2, 3}
B = {4, 5, 6}
print(A.isdisjoint(B))  # True

# issubset() - Returns True if another set contains this set.

A = {1, 2, 3}
B = {1, 2, 3, 4, 5}
print(A.issubset(B))  # True

# issuperset() - Returns True if this set contains another set.

A = {1, 2, 3, 4, 5}
B = {1, 2, 3}
print(A.issuperset(B))  # True

# symmetric_difference() - Returns a set with the symmetric differences of two sets.

A = {1, 2, 3, 4, 5}
B = {4, 5, 6, 7, 8}
print(A.symmetric_difference(B))  # {1, 2, 3, 6, 7, 8}

# union() - Returns a set containing the union of sets.

A = {1, 2, 3, 4, 5}
B = {4, 5, 6, 7, 8}
print(A.union(B))  # {1, 2, 3, 4, 5, 6, 7, 8}


