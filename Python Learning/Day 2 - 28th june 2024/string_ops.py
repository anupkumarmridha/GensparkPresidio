# string manupulation in python

str1 = "Hello"
str2 = "World"

# string concatenation
str3 = str1 + str2
print(str3)

# string multiplication
str4 = str1 * 3
print(str4)

# string division
# str5 = str1 / 3 # TypeError: unsupported operand type(s) for /: 'str' and 'int'
# strdiv = str1 / str2 # TypeError: unsupported operand type(s) for /: 'str' and 'str'

# string substraction
# str6 = str1 - str2 # TypeError: unsupported operand type(s) for -: 'str' and 'str'

# string slicing
print(str1[:])
print(str1[1])
print(str1[1:4])
print(str1[1:])
print(str1[:4])

print(str1[-1])
print(str1[-4:-1])

# The start index -1 refers to the last character of the string.
# The end index -4 refers to the fourth-to-last character of the string.
# Slicing moves from the start index towards the end index in the positive direction (left to right).
# Since moving from -1 to -4 in the positive direction is not possible within the string's bounds, 
# Python returns an empty string. 

print("Empty String",str1[-1:-4])

# string reverse and step size in slicing  [start:end:step] 
print(str1[::-1]) # reverse the string 
# print(str1[::0]) # ValueError: slice step cannot be zero

print(str1[::1]) # step size 1 

print(str1[::2]) # step size 2 

print(str1[1::2]) # step size 2 starting from index 1

print(str1[:5:2]) # step size 2 starting from index 0 and ending at index 4
print(str1[1:4:2]) # step size 2 starting from index 1 and ending at index 4

print(str1[1:4:1]) # step size 1 starting from index 1 and ending at index 4

print(str1[-1:-4:-1]) # step size -1 starting from index -1 and ending at index -4
print(str1[-1::-1]) # step size -2 starting from index -1 and ending at index 0
print(str1[-1::-2]) # step size -2 starting from index -1 and ending at index 0
print(str1[-1:-5:-2]) # step size -2 starting from index -1 and ending at index -4
print(str1[-5:-1:1]) # step size 1 starting from index -5 and ending at index -1
print("Empty string-> ", str1[-5:-1:-1]) # step size -1 starting from index -5 and ending at index -1

# string length
print("len->",len(str1))

# string methods
# string methods are case sensitive
# string methods are immutable
# string methods are not in-place
# string methods return new string
# string methods are not chainable
# string methods are not index based
# string methods are not slice based
# string methods are not iterable
# string methods are not subscriptable
# string methods are not iterable


#  upper() -> converts all characters to uppercase
print("upper->",str1.upper())

# lower() -> converts all characters to lowercase
print("lower->",str1.lower())

# capitalize() -> converts first character to uppercase
print("capitalize->",str1.capitalize())

# title() -> converts first character of each word to uppercase
print("title->",str1.title())

# swapcase() -> converts all uppercase characters to lowercase and vice versa
print("swapcase->",str1.swapcase())

# casefold() -> converts all characters to lowercase
print("casefold->",str1.casefold())

# center() -> center aligns the string with specified width
print("center->",str1.center(10))

# count() -> returns the number of times a specified value occurs in a string
print("count->",str1.count("l"))

# encode() -> returns the encoded version of the string
print("encode->",str1.encode())

# endswith() -> returns true if the string ends with the specified value
print("endswith->",str1.endswith("o"))

# startswith() -> returns true if the string starts with the specified value
print("startswith->",str1.startswith("H"))

# expandtabs() -> sets the tab size of the string
print("expandtabs->",str1.expandtabs())

# find() -> searches the string for a specified value and returns the position of where it was found
print("find->",str1.find("l"))

# rfind() -> searches the string for a specified value and returns the last position of where it was found
print("rfind->",str1.rfind("l"))

# index() -> searches the string for a specified value and returns the position of where it was found
print("index->",str1.index("l"))

# format() -> formats specified values in a string
print("format->",str1.format())

# format_map() -> formats specified values in a string
print("format_map->",str1.format_map(str2))

# isalnum() -> returns True if all characters in the string are alphanumeric
print("isalnum->",str1.isalnum())

# isalpha() -> returns True if all characters in the string are in the alphabet
print("isalpha->",str1.isalpha())

# isascii() -> returns True if all characters in the string are ascii characters
print("isascii->",str1.isascii())

# isdecimal() -> returns True if all characters in the string are decimals
print("isdecimal->",str1.isdecimal())

# isdigit() -> returns True if all characters in the string are digits
print("isdigit->",str1.isdigit())

# isidentifier() -> returns True if the string is an identifier
print("isidentifier->",str1.isidentifier())

# islower() -> returns True if all characters in the string are lower case
print("islower->",str1.islower())

# isupper() -> returns True if all characters in the string are upper case
print("isupper->",str1.isupper())

# isnumeric() -> returns True if all characters in the string are numeric
print("isnumeric->",str1.isnumeric())

# isprintable() -> returns True if all characters in the string are printable
print("isprintable->",str1.isprintable())

# isspace() -> returns True if all characters in the string are whitespaces
print("isspace->",str1.isspace())

# istitle() -> returns True if the string follows the rules of a title
print("istitle->",str1.istitle())



# join() -> joins the elements of an iterable to the end of the string
print("join->",str1.join(str2))

# ljust() -> returns a left justified version of the string
print("ljust->",str1.ljust(10))

# rjust() -> returns a right justified version of the string
print("rjust->",str1.rjust(10))

# lstrip() -> returns a left trim version of the string
print("lstrip->",str1.lstrip())

# rstrip() -> returns a right trim version of the string
print("rstrip->",str1.rstrip())

# strip() -> returns a trim version of the string
print("strip->",str1.strip())

# partition() -> returns a tuple where the string is parted into three parts
print("partition->",str1.partition("l"))

# rpartition() -> returns a tuple where the string is parted into three parts
print("rpartition->",str1.rpartition("l"))

# replace() -> replaces a specified value with another specified value
print("replace->",str1.replace("l","L"))

# rindex() -> searches the string for a specified value and returns the last position of where it was found
print("rindex->",str1.rindex("l"))

# rsplit() -> splits the string at the specified separator, and returns a list
print("rsplit->",str1.rsplit())

# split() -> splits the string at the specified separator, and returns a list
print("split->",str1.split())

# splitlines() -> splits the string at line breaks and returns a list
print("splitlines->",str1.splitlines())
# zfill() -> fills the string with a specified number of 0 values at the beginning
print("zfill->",str1.zfill(10))

# translate() -> returns a translated string
print("translate->",str1.translate(str2))

# Assuming str1 is the string you want to translate,
# and str2 is the string of characters to replace,
# and str3 is the string of replacement characters.
# Ensure str2 and str3 are of equal length.
translation_table = str3.maketrans(str1, str2)
print("maketrans->", translation_table)




