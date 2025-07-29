// ## Array
// An array is a contiguous block of cells, each cell contains a value.  The type of the value
// defines the size of the cell, all data types must be the same type.  In the case of reference
// types, strings, structures, etc., the memory pointer is the contained value.

// Arrays are:
// - declared between `[|` and `|].
// - a single type.
// - delimited with `;` or new lines.

// The explicit declaration for the following array is `: string array`
let anArray = [| "item1"; "item2"; "item3" |]

// indexes
// - arrays can addressed by the zero based index
// - indexes are denoted using the `[index]`
// - using a negative value or a value greater then the size of the array will result in an out of
//   bounds exception

let goodPicker i (a : string array) =
  try
    Some a[i]
  with :? System.IndexOutOfRangeException ->
    None

let badPicker i (a : string array) = a[i]

// this chain does not necessarily represent a 'real' process 
[| -1; 0; 1; 2; 3 |]
// using `rev` to invert the the items in the list
|> Array.rev
// this mapping is not strictly required because Array.choose could be called directly here (like the bad picker)
|> Array.map (fun i -> [| "item1"; "item2"; "item3" |] |> goodPicker i)
// but the `id` function is introduced, it is effectively an identity 
|> Array.choose id

// will throw IndexOutOfRange
[| -1; 0; 1; 2; 3 |]
|> Array.map (fun i -> [| "item1"; "item2"; "item3" |] |> badPicker i)

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
