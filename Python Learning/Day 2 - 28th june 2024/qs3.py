# 3) Sort score and name of players print the top 10

class Player:
    def __init__(self, name, score):
        self.name = name
        self.score = score

    # __repr__ is used to compute the “official” string reputation of an object 
    # and return a string that can be used to recreate the object.
    # string reputation is used to print the object for debugging purposes.
    def __repr__(self):
        return repr((self.name, self.score))

def top_10_players(players):

    # sort the players based on score and name
    # if score is same then sort based on name
    # if score is different then sort based on score
    # key is a function that takes a single argument and returns a key to use for sorting purposes.
    # (-x.score, x.name) is a tuple of two elements. why - is used before x.score?
    # - is used to sort in descending order.
    # x.score is used to sort based on score.
    # x.name is used to sort based on name.
    
    players.sort(key=lambda x: (-x.score, x.name))
    return players[:10]

# sample testcases
players = [
    Player("George", 20),
    Player("John", 100), 
    Player("Anup", 100),
    Player("Doe", 90), 
    Player("Jane", 90), 
    Player("Bob", 70),
    Player("Alice", 80),
    Player("David", 50),
    Player("Charlie", 60),
    Player("Frank", 30),
    Player("Eve", 40),
    Player("Harry", 10),
    Player("Jack", 1),
    Player("Ivan", 5),
    
    ]
print(top_10_players(players))