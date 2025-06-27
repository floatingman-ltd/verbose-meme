// constants
// simple value
let c = 5

// function value
let cf1 = fun () -> 5
(* --or-- *)
let cf2 () = 5;;

// function
 let add1 x = x + 1

// int -> int -> int
// x      y      return
let addThese x y = x + y

// unit -> string
// ()      "Hey there"
let magicValue () = "Hey there!"

let write string = System.Console.Write( "{0}",  string)

// defining function signatures

type Adder = int -> int
type AdderGenerator = int -> Adder

let a:AdderGenerator = fun x -> (fun y -> x + y)

// will not compile
// let b:AdderGenerator = fun (x:float) -> (fun y -> x + y)

let c = fun (x:float) -> (fun y -> x + y)

// val testA = int -> int
let testA x = x * 2

// val testB = int -> int -> int
let testB x y = x + y

// val testC = int -> (int -> int)
let testC x =
    fun y -> y + x + 0

// val testD = (int -> int) -> int
let testD x =
    let z = x 4
    z
