// error cases on empty arrays

let emptyArray : int[] = [||]
let nonemptyArray = [| 3; 8; 2; 6; 4; 1; 9; 5; 0; 7 |]

//! these are exceptions
// System.ArgumentException: The input array was empty. (Parameter 'array')
// emptyArray |> Array.head
let head = nonemptyArray |> Array.head
let tryFirst = emptyArray |> Array.tryHead |> Option.map (fun i -> i)
let tryFirst' = nonemptyArray |> Array.tryHead |> Option.map (fun i -> i)
// emptyArray |> Array.max
// emptyArray |> Array.min

// int cannot be average
// emptyArray |> Array.average
// emptyArray |> Array.map (fun i ->  i |> double) |> Array.average

// System.ArgumentException: The input sequence has an insufficient number of elements. (Parameter 'array')
// emptyArray |> Array.tail


//! these are okay
let sorted = emptyArray |> Array.sort
let grouped = emptyArray |> Array.groupBy (fun i -> i % 2)
let mapped = emptyArray |> Array.map (fun i -> i |> double)
