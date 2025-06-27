type Customer = { Age: int }

let where filter customers = 
    seq {
        for customer in customers do
            if filter customer then 
                yield customer }

let customers = [{Age = 21}; {Age = 35}; {Age = 36}]

let isOver35 customer = customer.Age > 35

customers |> where isOver35
customers |> where (fun customer -> customer.Age > 35)
// return [{Age = 36}]


// the `where` function is generic
let dog = [|1;2;3;4;5;6|]
dog |> where (fun fido -> fido = 4)
// returns a sequence of [4]

// further examples:
open System
open System.IO

let printCustomerAge writer customer =
    let message = 
        if customer.Age < 13 then  "Child"
        elif customer.Age < 20 then  "Teenager"
        else  "Adult"
    writer message

let printToConsole = printCustomerAge Console.WriteLine

let writeToTemp text = File.WriteAllText (Path.GetTempFileName(), text)
let printToDisc = printCustomerAge writeToTemp

printCustomerAge System.Console.WriteLine ({Age = 10})
printToDisc ({Age = 15}) // <- should end up in the temp folder
printToConsole ({Age = 40})