// What is the largest prime factor of 600_851_475_143?


open System
open System.Linq
open System.Collections.Generic

let testInt = 600_851_475_143L
let testFloat = float testInt
let largestPossibleFloat n = Math.Floor (Math.Sqrt n)
let largestPossibleInt n = int64 (largestPossibleFloat n)
let largestPossibleFactor (n : int64) = largestPossibleInt (float n)

// get all the primes less then `largestPossibleInt`


// trial division

let primesToByTrial n =
  // memoization
  let primes = new List<_> ()
  primes.Add 2L |> ignore

  let rec isPrime n' =
    let mutable isPrimeCandidate = true
    let upperLimit = largestPossibleFactor n'

    match n' with
    | n' when n' < primes.Last () -> false
    | n' when n' = primes.Last () -> true
    | _ ->
      let mutable i = 0

      while i < primes.Count && upperLimit >= primes[i] && isPrimeCandidate do
        if n' % primes[i] = 0 then
          isPrimeCandidate <- false
        else
          i <- i + 1

      if isPrimeCandidate then
        primes.Add n' |> ignore

      isPrimeCandidate

  // isPrime n


//     if memo.ContainsKey x then

//       memo[x]
//     else
//       let t = f x
//       memo.Add (x, t) |> ignore
//       t

// (2)
// |> Seq.unfold (fun i ->
//   let x = largestPossibleFactor i
//   )

// [| 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
// |> Seq.iter (fun i ->
//   printfn "%i : %A" i (primes |> isPrime i)
//   primes |> Seq.iter (printf "%i ")
//   printfn ""
// )
// [| 2; 3; 4; 5; 6; 7; 8; 9; 10 |]
// |> Seq.iter (fun i ->
//   printfn "for %i" i

//   printfn "%i %s prime" i (if primes |> isPrime i then "is" else "is not")
//   |> ignore
//   primes |> Seq.iter (printf "%i ")
//   printfn ""
// )

let sqrt = largestPossibleFactor testInt

let p =
  [ 2L ] @ [ 3L .. 2L .. sqrt ]
  |> Seq.filter (fun i -> primesToByTrial i)
  |> Seq.filter (fun p -> testInt % int64 p = 0)
  |> Seq.max
// // 6857

// let p = [ 3..2..sqrt ] |> Seq.filter (fun i -> primes |> isPrime i)

// printfn "%A" p

let primesTo n =
  let rec sieve l =
    match l with
    | [] -> []
    // this will match all lists as <head> :: <rest>, think of LISP car & cdr
    | p :: xs ->
      // this will join `p` to the front of the list returned by calling the `sieve` function
      p
      :: sieve
        // the comprehension, where `xs` is the decomposed tail
        [
          for x in xs do
            if (x % p) > 0 then
              yield x
        ]

  [ 2 ] @ [ 3..2..n ] |> sieve

// let answer =
//   primesTo sqrt |> Seq.filter (fun p -> testInt % (int64 p) = 0) |> Seq.max
