

class Animal
{
    walking()
    {
        console.log("Animal is walking")
    }

}

class Tiger extends Animal
{
    walking()
    {
        console.log("Tiger is walking with four legs")
    }

}

class Bear extends Animal
{
    walking()
    {
        console.log("Bear is walking with two legs")
    }

}

const animals=[new Tiger(),new Bear()]
animals.forEach(animal=>animal.walking())


class Shape
{
    area(valueOne,valueTwo)
    {
        console.log(valueOne*valueTwo)
    }
}



class Rectangle extends Shape
{
    area(valueOne,valueTwo)
    {
        super.area(valueOne,valueTwo)
    }
}

let rectangle=new Rectangle()
rectangle.area(6,8)


class Person
{
    startWalking()
    {
        console.log("Person starts walking from his home")
    }
    reachedGroceryShop()
    {
        this.startWalking()
        console.log("Reached the grocery shop")
    }
}

let ram=new Person()
ram.reachedGroceryShop()