// ## Lists
// List are single linked, meaning that an item has a reference to the next item, or an empty list.
// Lists consist of two parts, the _head_ and the _tail_, in _LISP_ this would be _car_ and _cdr_.
// Lists can be both composed and decomposed with the `::` operator.  Because an empty list (`[ ]`)
// is a list the following examples wrap the `::` operator in a `match` statement.

//! collection delimiters are `;` if `,` is used it may result in a collection of a single tuple

// Decomposition
let rec headAndTail l =
  match l with
  | [] ->
    printfn "all done"
    []
  | head :: tail ->
    printfn "head | %A" head
    printfn "tail | %A" tail
    headAndTail tail

[ 2; 3; 6; 9 ] |> headAndTail

// Composition
let compose i l = i :: l

[] |> compose 1 |> printfn "%A"

[ 1 ] |> compose 2 |> printfn "%A"

// Lists are:
// - declared between `[` and `]`
// - must be a single type.
// - items are delimited with `;` or new lines.
let aList = [ 1; 2; 3 ]
// range
let bList = [ 1..10 ]
// slicing
let floats = aList[1..2]
// list decomposition with `::`
let head :: tail = aList

// the following will throw a MatchFailureException
try
  let h :: t = []
  sprintf "head: [%A]\ntail: [%A]" h t
with 
    // this is not a good thing to - strictly for demonstration
    // | :? MatchFailureException  -> [1;2]
    | ex ->  $"{ex.Message}" 



// list de-composition with `::`
let cList = 0 :: bList
// list concatenation
let dList = aList @ [ 11; 12 ]
