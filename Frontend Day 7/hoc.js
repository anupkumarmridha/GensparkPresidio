function checkingEvenNumbers(num)
{
    return num%2==0//boolean
}


function filteringEvenNumbers(numbers,callbackFunc)
{
    let numberArray=[]
    for(let value of numbers)
    {
        if(callbackFunc(value))
            numberArray.push(value)
    }
    return numberArray
}

let arrayOfNumbers=[22,45,99,3,8,44]
console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))