// for loops
for x in 1..10 do
    printfn $"Line: {x}"

// perhaps a more functional "listy" way would be
[ 1..10 ] |> List.iter (fun i -> printfn $"Line: {i}")

for x in 10..-1..1 do
    printfn $"and now backwards: {x}"

for x in 2..2..20 do
    printfn $"by twos:\t{x}"

// while loops too

// comprehensions

let arrayOfChar = [| for c in 'a' .. 'z' -> Char.ToUpper c |]
let listOfSquares = [ for i in 1..10 -> i * i ]
let seqOfStrings = seq { for i in 2..4..20 -> $"Number:\t{i}" }

// if else - poor example
let limit = if score = "medium" && years = 1 then 500 else 250

// switch and pattern matching
let limit customer =
    match customer with
    | "medium", 1 -> 500.00M
    | "good", years when years < 2 -> 750M
    | _ -> 250.00M

let Dog mansBestFriend =
    match mansBestFriend with
    | (name: string, age: int) -> printfn $"{name} is {age} years old"

// collection and pattern matching
type Customer = { Name: string; Balance: decimal }

let handleCustomers (customers: Customer List) =
    match customers with
    | [] -> failwith "No customers supplied"
    | [ customer ] -> printfn $"woot: {customer.Name}"
    | [ first; second ] -> printfn $"Two customer {first.Balance + second.Balance}"
    | customers -> printfn $"There are {customers.Length} customers"

// [] |> handleCustomers
[ { Name = "Dragon"; Balance = 45.0m } ] |> handleCustomers

[ { Name = "Dragon"; Balance = 45.0m }; { Name = "Unicorn"; Balance = 55.0m } ]
|> handleCustomers

let customers =
    [ { Name = "Dragon"; Balance = 45.0m }
      { Name = "Unicorn"; Balance = 55.0m }
      { Name = "Julius"; Balance = 100.0m } ]

customers |> handleCustomers

// record and pattern matching
let getStatus (customer: Customer) =
    match customer with
    | { Balance = 50m } -> " meh - soso "
    | { Name = "Unicorn" } -> "we like Unicorn"
    | { Name = name } when name = "Dragon" -> $"we tolerate {name}"
    | { Name = name; Balance = 100M } -> $"we really like {name}"

customers |> List.map getStatus

// Only list and array can be matched - sequences are lazy loaded and therefore cannot be
