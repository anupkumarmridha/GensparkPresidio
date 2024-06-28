# 1) Longest Substring Without Repeating Characters.
# That is in a given string find the longest substring that does not contain any character twice.

def longest_substring_without_repeating_characters(s):
    # write your code here
    n = len(s)
    if n == 0:
        return ""
    if n == 1:
        return s
    max_len = 0
    start = 0
    end = 0
    substring = ""
    while end < n:
        if s[end] not in s[start:end]:
            end += 1
            if end - start > max_len:
                max_len = end - start
                substring = s[start:end]
        else:
            start += 1
    return substring

# sample testcases
string = "abcabcbb"
print(longest_substring_without_repeating_characters(string)) # abc
