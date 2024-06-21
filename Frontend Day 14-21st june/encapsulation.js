class Vehicle
{
    constructor(vehicleType,modelName)
    {
        this.vehicleType=vehicleType
        this.modelName=modelName
    }
    displayDetails()
    {
        console.log(`The type of Vehicle is ${this.vehicleType} and the model is ${this.modelName}`)
    }
}
let vehicleOne=new Vehicle('Car','Audi')
vehicleOne.displayDetails()