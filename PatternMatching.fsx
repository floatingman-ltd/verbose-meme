// explicit pattern matching
let switchValue = 3

match switchValue with
| 1 -> printfn "Value is one."
| 2 -> printfn "Value is two."
| 3
| 4
| 5 as x -> printfn "Somewhat greater then 2, value is << %A >>." x
| _ -> printfn "There's a lot of things it could be."

// when guards
let switchWhen = 3

match switchWhen with
| 1 -> printfn "Value is one."
| 2 -> printfn "Value is two."
| v when v < 10 -> printfn "Less the ten, it's << %A >>." v
| v when v = 10 -> printfn "TEN!"
| _ -> printfn "There's a lot of things it could be."

// array matching
let c1 = [||]
let c2 = [| 1 |]
let c3 = [| 1; 2 |]
let c4 = [| 1; 2; 3 |]
let c5 = [| 1; 2; 3; 4 |]

let matchingCollection coll =
  match coll with
  | [||] -> printfn "Empty"
  | [| a |] -> printfn "One item - %A" a
  | [| a; b |] -> printfn "Two items"
  | _ -> printfn "More then two items."

[| c1; c2; c3; c4; c5 |] |> Array.iter matchingCollection

// list matching
let l1 = []
let l2 = [ 1 ]
let l3 = [ 1; 2 ]
let l4 = [ 1; 2; 3 ]
let l5 = [ 1; 2; 3; 4 ]

let matchingList lst =
  match lst with
  | [] -> printfn "Empty"
  | [ a ] -> printfn "One item - %A" a
  | head :: tail -> printfn "First item << %A >> and %A more." head (tail |> List.length)
  // note that the `head :: tail` construct matched all and the `_` will never be hit
  | _ -> printfn "More then two items."

[| l1; l2; l3; l4; l5 |] |> Array.iter matchingList

// tuple decomposition
let MinMax v = v |> Seq.min, v |> Seq.max
let values = [| -1; 45; 0; 3; 10; 0 |]
let minimum, maximun = values |> MinMax

let showMe aTuple =
  match aTuple with
  | min, max -> printfn "min: %A\nmax: %A" min max

values |> MinMax |> showMe

// discriminating unions
type MeterReading =
  | Standard of int
  | TimeOfUse of OnPeak : int * MidPeak : int * OffPeak : int

module MeterReading =
  let format reading =
    match reading with
    | Standard reading -> sprintf "Your usage: %07i" reading
    | TimeOfUse (onPeak, midPeak, offPeak) -> sprintf "On: %07i\nMid: %07i\nOff: %07i" onPeak midPeak offPeak

Standard 378593 |> MeterReading.format |> printfn "%A"
TimeOfUse (8365, 26462, 09846) |> MeterReading.format |> printfn "%A"

// duplicate yet interesting example
type Complex = | Complex of Real : float * Imaginary : float

module Complex =
  // the method parameter decomposes the DU
  // the signature of this method is Complex -> Complex -> Complex, meaning
  // it accepts two Complex numbers and returns a COmplex number
  let add (Complex (r1, i1)) (Complex (r2, i2)) = Complex (r1 + r2, i1 + i2)

// moving along
type Number =
  | Real of float
  | Complex of Complex

// since the Number is now a DU it cannot be decomposed
//! the following will *NOT* compile with the message clearly indicating that _PatternMatching_ is to blame.
// module Number =
//   let add (Complex (r1, i1)) (Complex (r2, i2)) = Complex (r1 + r2, i1 + i2)

// finally something fun
module Heading = 
//   [<struct>]
  type Heading =
    private
    | Heading of double

    member this.Value = this |> fun (Heading h) -> h

  let rec create value = 
    if value >= 0.0 then    
      value % 360.0 |> Heading
    else 
      value + 360.0 |> create

let h1 = Heading.create 180.0
let h2 = Heading.create -143.0
let h3 = Heading.create 534.9