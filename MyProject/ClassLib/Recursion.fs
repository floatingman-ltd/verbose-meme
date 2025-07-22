namespace FSharpClassLib

module Recursion =
  // This will issue "warning FS3569: The member or function 'badCountDown' has the 'TailCallAttribute' attribute, but is not being used in a tail recursive way."
  [<TailCall>]
  let rec badCountDown n =
    if n = 0 then 0 else badCountDown (n - 1) + 1

  [<TailCall>]
  let rec goodCountDown n =
    if n = 0 then 0 else goodCountDown (n - 1)

  [<TailCall>]
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