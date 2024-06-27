# Type Conversion
x=10
y=20.5
z="30"
print(float(x))
print(int(y))
print(int(z))
print(str(x))
print(str(y))
print(str(z))

# Type Conversion using map()

a,b,c=map(int,input("Enter three numbers: ").split())
print(a)
print(b)
print(c)

# Type Conversion using list comprehension

x=[int(i) for i in input("Enter n numbers: ").split()]
print(x)
print(type(x))
