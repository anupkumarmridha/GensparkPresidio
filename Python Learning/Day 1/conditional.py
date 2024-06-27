#    Conditional statements in Python

x=10
y=20
#  if, elif, else

if x>y:
    print("x is greater than y")
elif x==y:
    print("x is equal to y")
else:
    print("x is less than y")
#    Nested if-else

if x==y:
    print("x is equal to y")
else:
    if x>y:
        print("x is greater than y")
    else:
        print("x is less than y")
        
#    Short Hand if-else
print("x is greater than y") if x>y else print("x is less than y")

#    Short Hand if-else with multiple statements
print("x is greater than y") if x>y else print("x is equal to y") if x==y else print("x is less than y")
