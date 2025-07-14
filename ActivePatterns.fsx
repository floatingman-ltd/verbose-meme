// active pattern 
// let (|identifier|) [arguments] valueToMatch = expression

let (|Even|Odd|) input = if input % 2 = 0 then Even else Odd

let TestNumber input = 
    match input with
    | Even -> printfn "%d is even" input
    | Odd -> printfn "%d is Odd" input

TestNumber 7
TestNumber 32
TestNumber -1
TestNumber -0

// Currency
open System

let (|Currency|) (x:float) = 
    Math.Round(x, 2)

match 100.0 / 3.0 with
| Currency 33.33 -> true
| _ -> false
