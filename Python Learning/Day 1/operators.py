# Operators

# Arithmetic Operators
x=10
y=20
print("value of x is: ",x)
print("value of y is: ",y)
print("Sum of the numbers is: ",x+y)
print("Difference of the numbers is: ",x-y)
print("Product of the numbers is: ",x*y)
print("Division of the numbers is: ",x/y)
print("Modulus of the numbers is: ",x%y)
print("Exponent of the numbers is: ",x**y)
print("Floor Division of the numbers is: ",x//y)


# Comparison Operators
print("x==y",x==y)
print("x!=y", x!=y)
print("x>y", x>y)
print("x<y", x<y)
print("x>=y", x>=y)
print("x<=y", x<=y) 

# Logical Operators
print("x>5 and x<15",x>5 and x<15)
print("x>5 or x<5", x>5 or x<5)
print("not(x>5 and x<15)", not(x>5 and x<15))

# Assignment Operators
x+=5
print("increment x by 5: ", x)
x-=5
print("decrement x by 5: ",x)
x*=5
print("multiply x by 5: ",x)
x/=5
print("divide x by 5: ",x)
x%=5
print("modulus x by 5: ",x)
x**=5
print("exponent x by 5: ",x)
x//=5
print("floor division x by 5: ",x)

# Bitwise Operators
a=10
b=4
print("And operator a&b: ",a&b)
print("Or operator a|b: ",a|b)
print("Xor operator a^b: ",a^b)
print("Not operator ~a: ",~a)
print("Left Shift operator a<<2: ",a<<2)
print("Right Shift operator a>>2: ",a>>2)

# Identity Operators
print("Identity a is b: ", a is b)
print("Identity a is not b: ", a is not b)

# Membership Operators
a="Hello"
print("H in Hello: ",("H" in a))
print("H not in Hello: ",("H" not in a))

# Ternary Operator
p=10
q=20

print("value of p is: ",p)
print("value of q is: ",q)

print("p if p>q else q: ", p if p>q else q)

# Operator Precedence
print("10+10/20*4 = ", 10+10/20*4)
