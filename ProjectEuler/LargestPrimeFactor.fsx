// What is the largest prime factor of 600_851_475_143?


open System
open System.Linq
open System.Collections.Generic

let testInt = 600_851_475_143L
let testFloat = float testInt
let largestPossibleFloat n = Math.Floor (Math.Sqrt n)
let largestPossibleInt n = int (largestPossibleFloat n)
let largestPossibleFactor (n : int64) = largestPossibleInt (float n)

// get all the primes less then `largestPossibleInt`

let primes = new List<_> ()
primes.Add (2) |> ignore

let isPrime f (primes : List<int>) =
  // test if it is larger then the current largest known prime
  // printfn "test:%i  last prime:%i" f (primes.Last ())
  if f < primes.Last () then
    false
  elif f = primes.Last () then
    true
  else
    let upperLimit = largestPossibleFactor f
    // printfn "upper limit %i" upperLimit
    let mutable prime = true
    let mutable index = 0

    while index < primes.Count && upperLimit >= primes[index] && prime do
      // printfn "%i %% %i = %i" f primes[index] (f % primes[index])
      if f % primes[index] = 0 then
        prime <- false
      else
        index <- index + 1

    if prime then
      primes.Add (f)

    prime

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
  [ 2..sqrt ]
  |> Seq.filter (fun i -> primes |> isPrime i)
  |> Seq.filter (fun p -> testInt % (int64 p) = 0)
  |> Seq.max 
