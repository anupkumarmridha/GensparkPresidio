#9) Find All Permutations of a given string programatically.

# Method 1: Using itertools
import itertools

# string = input("Enter a string: ")
string = "ABC"
# permutations = list(itertools.permutations(string))
# print(f"Permutations of the string are: {permutations}")

# Method 2: Using recursion

def permute(data, i, length):
    if i==length:
        print(''.join(data))
    else:
        for j in range(i, length):
            data[i], data[j] = data[j], data[i]
            permute(data, i+1, length)
            data[i], data[j] = data[j], data[i]
            
permute(list(string), 0, len(string))
