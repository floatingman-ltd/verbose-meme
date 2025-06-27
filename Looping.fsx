open System
// standard for in loops

for number in 1..10 do
  printfn "%d forward" number

for number in 10..-1..1 do
  printfn "%d backward " number

// this does not work since the default incrementor is +1
for number in 10..1 do
  printfn "%d easy backward " number

for number in 45..50 do
  printfn "%d sliced" number

for number in 2..2..10 do
  printfn "%d by 2's" number

// comprehensions => list generating
let generatedArray = [| for x in 'a' .. 'z' -> Char.ToUpper x |]

let generatedList = [ for i in 1..10 -> i * i ]

let generatedSeq = seq { for j in 2..4..30 -> sprintf "Number %d" j }
