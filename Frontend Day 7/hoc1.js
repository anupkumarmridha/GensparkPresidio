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
    return ()=>console.log(numberArray)
}

let arrayOfNumbers=[22,45,99,3,8,44]
// console.log(filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers))
let result=filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers)
result()


//reduce
// let arrayOfNumbers=[1,2,3,4,5]
// let sumOfArrayElements=arrayOfNumbers.reduce((sum,value)=>{
// return sum+value
// })
// console.log(sumOfArrayElements)

//foreach
// let arrayOfNumbers=[22,45,99,3,8,44]
// arrayOfNumbers.forEach(num=>{console.log(num)})

//sort
// let arrayOfNumbers=[22,45,99,3,8,44]
// arrayOfNumbers.sort((numOne,numTwo)=>numOne-numTwo)
// console.log(arrayOfNumbers)