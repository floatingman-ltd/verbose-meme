type Location = 
    | Home = 0
    | Office = 1
    | Gas = 2
    | Store = 3

let parseLocation location = 
    System.Enum.Parse(typedefof<Location>,location) :?> Location
let mutable remainingGas = 10
let mutable current = parseLocation("Home")

let Drive current destination initialGas = 
    let distanceMatrix = [[|0;5;3;3|];[|5;0;2;4|];[|3;2;0;3|];[|3;4;3;0|]]
    let requiredGas = distanceMatrix.[int current].[int destination]
    if initialGas >= requiredGas then
        let gas = if destination = Location.Gas then System.Math.Min(initialGas + 7,10) else initialGas - requiredGas 
        (destination,gas)
    else
       (current,initialGas)

while remainingGas > 0 do
    System.Console.Write("Drive from {0} to: ",current)
    let destination = parseLocation(System.Console.ReadLine())
    let (current,remainingGas) = Drive current destination remainingGas
    ignore 0

let dog a b c =
 a * b * c 
let dog2 =
 dog 2
let dog3 =
 dog2 3
let a =
 dog3 4
let b =
 dog 2 3 4 