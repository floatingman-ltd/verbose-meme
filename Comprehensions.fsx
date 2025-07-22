// comprehension syntax - `for .. in .. do .. yield`

let singleYield =
  [
    for i in [ 1..5 ] do
      yield i * i
  ]

printfn "%A" singleYield

let multiYield =
  [
    for i in [ 2..2..6 ] do
      yield i
      yield i * i
      yield i * i * i
  ]

printfn "%A" multiYield

// more complex example
let primesTo n =
  let rec sieve l =
    match l with
    | [] -> []
    // this will match all lists as <head> :: <rest>, think of LISP car & cdr
    | p :: xs ->
    // this will join `p` to the front of the list returned by calling the `sieve` function
      p :: sieve
      // the comprehension, where `xs` is the decomposed tail
        [
          for x in xs do
            if (x % p) > 0 then
              yield x
        ]

  [ 2 ] @ [3 .. 2..n ] |> sieve
#time on
primesTo 100
#time off
