# 10) Print a pyramid of starts for the number of rows specified
#    *
#   ***
#  ******

n=int(input("Enter the number of rows: "))
for i in range(n):
    print(" "*(n-i-1), end="")
    print("*"*(2*i+1))
