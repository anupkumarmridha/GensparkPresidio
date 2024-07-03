#<================Start HackerRank====================>
# Merge the Tools!
def merge_the_tools(string, k):
    # your code goes here
    n=len(string)
    for i in range(0,n,k):
        substr=string[i:i+k]
        output=""
        for ch in substr:
            if ch not in output:
                output+=ch
        print(output)

def swap_case(s):
    x=''
    for i in s:
        if i == i.upper():
            x+=i.lower()
        else:
            x+=i.upper()
    return x
    

def split_and_join(line):
    # write your code here
    return '-'.join(line.split(' '))


def print_full_name(first, last):
    # Write your code here
    print(f"Hello {first} {last}! You just delved into python.")
    

def mutate_string(string, position, character):
    l=list(string)
    l[position]=character
    return ''.join(l)

# collections.Counter()
# A counter is a container that stores elements as dictionary keys, and their counts are stored as dictionary values.

from collections import Counter
no_of_shoes=int(input())
shoes=Counter(list(map(int, input().split())))

no_of_customer=int(input())
amount=0

for i in range(no_of_customer):
    require_size, require_money = map(int, input().split())
    
    for key, value in Counter(shoes.items()):
        if require_size==key:
            amount+=require_money
            shoes[key]=shoes[key]-1
            if shoes[key]==0:
                del shoes[key]
print(amount)


# Arithmetic Operators
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a+b)
    print(a-b)
    print(a*b)


# Company Logo
if __name__ == '__main__':
    s = sorted(input())
    d=Counter(s).most_common(3)
    for i in d:
        print(f'{i[0]} {i[1]}')

# Python: Division
if __name__ == '__main__':
    a = int(input())
    b = int(input())
    print(a//b)
    print(a/b)
    
    
# loop
if __name__ == '__main__':
    n = int(input())
    for i in range(n):
        print(i*i)


# leap year
def is_leap(year):
    if (year%4==0 and year%100!=0) or (year%400==0):
        return True
    else:
        return False

# Print Function
if __name__ == '__main__':
    n = int(input())
    ans=''
    for i in range(1, n+1):
        ans+=str(i)
    print(ans)    
    
# List Comprehensions
if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    print([[i,j,k] for i in range(x+1) for j in range(y+1) for k in range(z+1) if(i+j+k!=n)])
    
#<================End HackerRank====================>
    
    
    
    
    
    
    
    
    
    
    
    
    
#<================Start LeetCode====================>

    class Solution:
    #3. Longest Substring Without Repeating Characters
        def lengthOfLongestSubstring(self, s: str) -> int:
            left = max_length = 0
            char_set = set()
            
            for right in range(len(s)):
                while s[right] in char_set:
                    char_set.remove(s[left])
                    left += 1

                char_set.add(s[right])
                max_length = max(max_length, right - left + 1)
            
            return max_length
        
        # 6. Zigzag Conversion
        def convert(self, s: str, numRows: int) -> str:
            if numRows == 1 or numRows >= len(s):
                return s
        
            rows = [[] for row in range(numRows)]
            index = 0
            step = -1
            for char in s:
                rows[index].append(char)
                if index == 0:
                    step = 1
                elif index == numRows - 1:
                    step = -1
                index += step

            for i in range(numRows):
                rows[i] = ''.join(rows[i])
            return ''.join(rows)
        
        # 16. 3Sum Closest
        def threeSumClosest(self, nums: list[int], target: int) -> int:
            nums.sort()
            res = sum(nums[:3])
            for i in range(len(nums) - 2):
                start = i + 1
                end = len(nums) - 1
                
                while start < end:
                    current_sum = nums[i]+nums[start]+nums[end]
                    if current_sum > target:
                        end -= 1
                    else:
                        start += 1
                    if abs(current_sum - target) < abs(res - target):
                        res = current_sum
            return res
        
        # 22. Generate Parentheses
        def generateParenthesis(self, n: int) -> List[str]:
            n -= 1
            result = {"()"}

            while n > 0:
                newResult = set()
                for item in result:
                    for i in range(len(item)):
                        newResult.add(item[:i] + "()" + item[i:])
                result = newResult
                n -= 1
            return result
        
    # 43. Multiply Strings
    def multiply(self, num1: str, num2: str) -> str:
        return str(int(num1) * int(num2))
    
    # 49. Group Anagrams
    def groupAnagrams(self, strs: list[str]) -> list[list[str]]:
        grouped = {}
        for word in strs:
            sorted_word = ''.join(sorted(word))
            if sorted_word in grouped:
                grouped[sorted_word].append(word)
            else:
                grouped[sorted_word] = [word]
        return list(grouped.values())
    
    # 55. Jump Game
    def canJump(self, nums: list[int]) -> bool:
        last_position = 0
        for i in range(len(nums)):
            if i > last_position:
                return False
            last_position = max(last_position, i + nums[i])
            if last_position >= len(nums) - 1:
                return True
        return last_position >= len(nums) - 1
    
    # 62. Unique Paths
    def uniquePaths(self, m: int, n: int) -> int:
        oldrow = [1]*n
        for i in range(m-1):
            newrow = [1]*n
            for j in range(n-2, -1, -1):
                newrow[j] = newrow[j+1] + oldrow[j]
            oldrow = newrow
        return oldrow[0]
    
# 68. Text Justification
def fullJustify(self, words: list[str], maxWidth: int) -> list[str]:
    result, current, num_of_letters = [], [], 0
    for word in words:
        if num_of_letters + len(word) + len(current) > maxWidth:
            for i in range(maxWidth - num_of_letters):
                current[i % (len(current) - 1 or 1)] += ' '
            result.append(''.join(current))
            current, num_of_letters = [], 0
        current += [word]
        num_of_letters += len(word)
    return result + [' '.join(current).ljust(maxWidth)]
