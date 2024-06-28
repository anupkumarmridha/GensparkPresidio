# 2) Print the list of prime numbers up to a given number


isPrime= lambda x: all(x%i!=0 for i in range(2,x))

def prime_numbers(n):
    numbers= [i for i in range(2,n+1) if isPrime(i)]
    return numbers

# sample testcases
n = 10
print(prime_numbers(n)) # [2, 3, 5, 7]