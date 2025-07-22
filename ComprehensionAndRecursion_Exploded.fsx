// sieve of eratosthenes
let eratosthenes n =
  let rec sieve l =
    match l with
    | [] -> []
    | p :: xs ->
      p
      :: sieve
        [
          for x in xs do

            if (x % p) > 0 then
              yield x
        ]


  // [ 2 ] @ [ 3..2..n ] |> sieve
  [ 2..n ] |> sieve

// sieve of prichard


#time on
eratosthenes 10
#time off
