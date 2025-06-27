System.Console.Clear()

type Address =
    { Street: string
      Town: string
      Province: string }

type Customer =
    { FirstName: string
      LastName: string
      Identifier: int
      Address: Address }

let Dragon =
    { FirstName = "Dragon"
      LastName = "Fafnir"
      Identifier = 1
      Address =
        { Street = "602 Guild Street"
          Town = "Narnia"
          Province = "Ontario" } }

let Unicorn = { Dragon with FirstName = "Unicorn" }

let other = { Unicorn with FirstName = "Dragon" }

let _ = (Dragon = Unicorn)
let _ = (Unicorn = other)
let _ = (other = Dragon)
