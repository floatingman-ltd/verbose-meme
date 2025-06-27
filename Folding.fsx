// imperative folding
let sum inputs =
    let mutable accumulator = 0

    for input in inputs do
        accumulator <- accumulator + input

    accumulator

// the `seq` key is optional
let v = { 1..10 }

sum v

// functional folding
let sum2 inputs =
    Seq.fold
        (fun state input -> state + input) // function that returns the accumulation
        // (( + )) // this is the equivalent abbreviated version - oh this is exciting
        0 // initial value
        inputs // sequence

sum2 v

// other ways of writing the same fold
let sum3 inputs = inputs |> Seq.fold ((+)) 0

let sum4 inputs = (0, inputs) ||> Seq.fold ((+))

// rules engine
open System

type Rule = string -> bool * string

let rules: Rule list =
    [ fun text -> (text.Split ' ').Length = 3, "Must be three words"
      fun text -> (text.Length <= 30, "Max length is 30 characters")
      fun text -> text |> Seq.filter Char.IsLetter |> Seq.forall Char.IsUpper, "All letters must be capitals" ]
