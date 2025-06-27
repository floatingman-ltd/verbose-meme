// tradition flow control
let limit score years =
    if score = "medium" && years >= 1 then 500
    elif score = "good" && (years = 0 || years = 1) then 750
    elif score = "good" && years = 2 then 1000
    elif score = "good" then 750
    else 250

// pattern matching
let patternLimit customer =
    match customer with
    | "medium", 1 -> 500
// first pass
//    | "good", 0 | "good", 1 -> 750
// second pass -> better
    | "good", years when years < 2 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _ -> 250

//  a customer
type Customer = 
    {
        Name: string
        Balance: double
        CreditRating: string
        Years: int
    }
    
// matching lists
let handleCustomerList customers = 
    match customers with
    | [] -> failwith "Empty List"
    | [customer] -> printfn "Greetings %s" customer.Name
    | [ first; second ] -> printfn "Balance: %f" (first.Balance + second.Balance)
    | customers -> printfn "Customer: %d" customers.Length

handleCustomerList []
handleCustomerList [{Name = "Dave"; Balance=1.23;CreditRating="Shitty";Years=12}]

// matching using records
let getStatus customer = 
     match customer with 
     | {Balance = 0.0} -> printfn "%s is broke" customer.Name
     | {Name = "Dave"} -> printfn "%f money" customer.Balance