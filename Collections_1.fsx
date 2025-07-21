// Collections -

//! collection delimiters are `;` if `,` is used it may result in a collection of a single tuple

// Arrays are declared between `[|` and `|].
// Arrays must be a single type.
// Array items are delimited with `;` or new lines.
// The explicit declaration for the following array is `: string[]`
let anArray = [| "item1"; "item2" |]
// indexes
// note the `.` between the array and the index
//                         v
let item1 = anArray.[0]
// the newer syntax allows for the `.` to be omitted
let item_x = anArray[1]
// slicing
let items = anArray[0..1]
// mutating, wait. what? yup by default, however the _items_ array declared just above is
// not affected, because the slice operator returns a new array.  On the other hand simply
// assignment to a new variable copies the reference.
let changed = anArray
anArray.[1] <- "mutated item"
changed

// Lists are declared between `[` and `]`
// Lists must be a single type.
// Lists items are delimited with `;` or new lines.
let aList = [ 1; 2; 3 ]
// range
let bList = [ 1..10 ]
// slicing
let floats = aList[1..2]
// list decomposition with `::`
let head :: tail = aList

// list de-composition with `::`
let cList = 0 :: bList
// list concatenation
let dList = aList @ [ 11; 12 ]

// Sequences are lazy evaluated
// Sequences are declared between `seq {` and `}`
// Sequences must be a single type.
// Sequences items are delimited with `;` or new lines.
let aSequence =
    seq {
        1
        2
        3
    }
// though more commonly generated
// let bSequnce =


// Most collections operators will have the pattern:
// 1. input func
// 2. input collection
// 3. output collection
//
//

// Map
// convert one list to another
let list_1 = [ 1..9 ]
let map_1 = list_1 |> List.map (fun int -> int * int)

let list_2 =
    [ "Dragon", 58
      "Unicorn", 56
      "Griffin", 30
      "Phoenix", 29
      "Mermaid", 27
      "Minotaur", 25
      "Chimera", 23 ]

let map_2 = list_2 |> List.map (fun (name, age) -> name.Length)

list_2
|> List.sortBy (fun (name, _) -> name.Length)
|> List.iteri (fun i (name, age) -> printfn $"{i} \t: {name}")

list_2
|> List.pairwise
|> List.map (fun ((_, older), (_, younger)) -> older - younger)

type PlaceOfBirth =
    { Name: string
      City: string
      Province: string }

let list_3 =
    [ { Name = "Dragon"
        City = "Atlantis"
        Province = "NS" }
      { Name = "Unicorn"
        City = "Avalon"
        Province = "ON" }
      { Name = "Griffin"
        City = "El Dorado"
        Province = "ON" }
      { Name = "Phoenix"
        City = "El Dorado"
        Province = "ON" }
      { Name = "Mermaid"
        City = "El Dorado"
        Province = "ON" }
      { Name = "Minotaur"
        City = "Shangri-La"
        Province = "NS" }
      { Name = "Chimera"
        City = "Shangri-La"
        Province = "NS" } ]

// return a list of tuple of (group * T' list)
list_3 |> List.groupBy (fun pob -> pob.City)
// return a list
list_3 |> List.countBy (fun pob -> pob.City)
// return a tuple
list_3 |> List.partition (fun pob -> pob.Province = "ON")

// conversions
// the `to*` and `of*` are generally the oppisite side of the same action
// for example: the following both result in an array
list_3 |> List.toArray
list_3 |> Array.ofList
