#7) Take 10 numbers and find the average of all the prime numbers in the collection.
from functools import reduce

def is_prime(n):
    if n<=1:
        return False
    for i in range(2,n):
        if n%i==0:
            return False
    return True

colletcion = map(int, input("Enter 10 numbers: ").split())

# use filter to get only prime numbers
primeNumbers = list(filter(is_prime, colletcion))
print(f"Prime numbers in the collection are: {primeNumbers}")

# use reduce to get the sum of prime numbers and then divide by the length of prime numbers
avg_prime = reduce(lambda x, y: x+y, primeNumbers)/len(primeNumbers)

print(f"Average of prime numbers is: {avg_prime}")
