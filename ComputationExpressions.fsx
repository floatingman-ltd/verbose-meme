

// trivial example
let logged x = printfn "[%A : %A]" (nameof x) x 

let loggedWorkflow =
    let x = 42
    logged x
    let y = 43
    logged y
    let z = x + y
    logged z
    // a return value 
    z


// this works either as a public method or a private embedded method
let logger x = printfn "[%A : %A] (with magic sauce)" (nameof x) x 

type LoggingBuilder () =
    
    // the private method
    // let logger x = printfn "[%A : %A] (with magic sauce)" (nameof x) x 

    member this.Bind(x, f) = 
        logger x
        f x
        
    member this.Return(x) =
        x

let logster = new LoggingBuilder()

let anotherWorkflow = 
    logster {
        let! x = 42
        let! y = 43
        let! z = x + y
        return z
    }
    
// an example with continuations

let divide ifZero ifSuccess numerator denominator  =
    if denominator = 0
    then ifZero()
    else ifSuccess (numerator / denominator)

// test 1 - message
let ifZero_1 () = printfn "BAD"
let ifSuccess_1 x = printfn "woot: %i" x
// partial 
let divide_1 = divide ifZero_1 ifSuccess_1
// test
let good_1 = divide_1 6 3
let bad_1 = divide_1 6 0

// test 2 - option
let ifZero_2 () = None
let ifSuccess_2 x = Some x
// partial 
let divide_2 = divide ifZero_2 ifSuccess_2
// test
let good_2 = divide_2 6 3
let bad_2 = divide_2 6 0

// test 3 - option
let ifZero_3 () = failwith "div by 0"
let ifSuccess_3 x = x
// partial 
let divide_3 = divide ifZero_3 ifSuccess_3
// test
let good_3 = divide_3 6 3
let bad_3 = divide_3 6 0

// archaic let usage
let xx = 42 in 
    let yy = 43 in
        let zz = xx + yy in
            zz
            
// which is the same as
42 |> (fun x -> 
    43 |> (fun y ->
        x + y 
            |> (fun z ->
                z)))
                
// moving along
// define a let like expression
let pipeInto (expression, lambda) =
    printfn "[%A : %A] (injected common functionality)" (nameof expression) expression 
    expression |> lambda
// because these are function calls the indents can be removed
pipeInto (42, fun x -> 
pipeInto (43, fun y ->
pipeInto ( x + y, fun z ->
z))) 

// further down the rabbit hole

let (>>=) m f = 
    printfn "boo: %A" m
    f m
    
let logThis = 
    1 >>= (+) 2 >>= (*) 42 >>= id

logThis
