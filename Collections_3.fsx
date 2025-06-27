// Collection manipulation

let numbers = [ 1..5 ]

let sum inputs =
    let mutable accumulator = 0

    for input in inputs do
        accumulator <- accumulator + input

    accumulator

let max inputs =
    let mutable accumulator = 0

    for input in inputs do
        accumulator <- System.Math.Max(accumulator, input)

    accumulator

let count inputs =
    let mutable accumulator = 0

    for input in inputs do
        accumulator <- accumulator + 1

    accumulator

let dump value = value |> Seq.iter printfn $"{value}"

numbers |> sum |> dump
numbers |> max |> dump
numbers |> count |> dump

// using fold various flavours
Seq.fold (fun state input -> state + input) 0 numbers
numbers |> Seq.fold (fun state input -> state + input) 0
(0, numbers) ||> Seq.fold (fun state input -> state + input)

// reduce * beware empty collection
numbers |> Seq.reduce (fun state input -> state + input)

//scan
(0, numbers) ||> Seq.scan (fun state input -> state + input) |> Seq.last

// yield

open System.IO

let lines: string seq =
    seq {
        use sr = new StreamReader(File.OpenRead @"./src/Concepts/Collections_3.fsx")

        while (not sr.EndOfStream) do
            yield sr.ReadLine()
    }

(0, lines) ||> Seq.fold (fun total line -> total + line.Length)

// composing functions
open System

type Rule = string -> bool * string

module Rules =
    let ThreeWordRule =
        printfn "Three Word Rule"
        fun (text: string) -> (text.Split ' ').Length = 3, "Must be three words"

    let LengthRule =
        printfn "Length Rule"
        fun (text: string) -> text.Length <= 10, "Must be less than 10 characters"

    let AllCapsRule =
        printfn "All Caps Rule"

        fun (text: string) ->
            text |> Seq.filter Char.IsLetter |> Seq.forall Char.IsUpper, "Must be uppercase"

    let rules: Rule list = [ ThreeWordRule; LengthRule; AllCapsRule ]

let buildValidator (rules: Rule list) =
    rules
    |> List.reduce (fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word

            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else
                false, error)

let validator = buildValidator Rules.rules

let s1 = "Valid word count."

s1 |> validator


