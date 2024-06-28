# 5) Credit card validation - Luhn check algorithm

# The Luhn algorithm is a simple checksum formula used to validate a variety of identification numbers,
# such as credit card numbers, IMEI numbers, National Provider Identifier numbers in the United States, Canadian Social

def luhn_check(card_number):
    # reverse the card number
    card_number = card_number[::-1]
    # convert the card number to a list of integers
    card_number = [int(x) for x in card_number]
    # double every second digit
    doubled = [x * 2 if i % 2 == 1 else x for i, x in enumerate(card_number)]
    # subtract 9 from numbers over 9
    subtracted = [x - 9 if x > 9 else x for x in doubled]
    # sum all the digits
    total = sum(subtracted)
    # return True if the total is divisible by 10
    return total % 10 == 0

# sample testcases
print(luhn_check("4532015112830366")) # True
print(luhn_check("4532015112830367")) # False
print(luhn_check("453201511283036")) # False
print(luhn_check("453201511283036")) # False
print(luhn_check("4532015112830366")) # True
print(luhn_check("4532015112830366")) # True

