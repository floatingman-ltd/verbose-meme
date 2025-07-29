open System.Collections.Generic
// recursion is a function that calls itself
// they must be explicitly identified with the `rec` keyword

// the following will not compile because the `rec` keyword is missing
// let bad_fibonacci n =
//   match n with
//   | 0
//   | 1 -> n
//   | n -> bad_fibonacci (n - 1) + bad_fibonacci (n - 2)

// this calculates the nth fibonacci value
// - the intermediate values are not saved and are recalculated with each recursive call
// - the fibonacci function is called twice and therefore this cannot be tail recursive
// - the `TailCall` attribute will issue a compiler warning

let rec fibonacci n =
  match n with
  | 0L
  | 1L -> n
  | n -> fibonacci (n - 1L) + fibonacci (n - 2L)

// Memoized
let memoized_fibonacci n =
  let memo = new Dictionary<int64, int64> ()
  memo.Add (0, 0)
  memo.Add (1, 1)

  let rec loop n =
    match n with
    | 0L
    | 1L -> n
    | n ->
      if memo.ContainsKey (n) then
        memo[n]
      else
        let t = loop (n - 1L) + loop (n - 2L)
        memo.Add (n, t) |> ignore
        t

  loop n

// tail recursion
[<TailCall>]
let tail_fibonacci n =
  let rec loop acc1 acc2 n =
    match n with
    | 0L -> acc1
    | 1L -> acc2
    | _ -> loop acc2 (acc1 + acc2) (n - 1L)

  loop 0L 1L n

// Memoization, this is a higher order function because it actually returns a function rather then
// defining a function.
// The memoized version of the tail recursive fibonacci function is actually slightly slower then
// the non-memoized function, this is because the act of adding to the dictionary takes some small
// amount of time.  Subsequent runs of this function would be O(1) whereas the original complexity
// is O(n).
let memoized_tail_fibonacci n =
  let memo = new Dictionary<int64, int64> ()
  memo.Add (0, 0)
  memo.Add (1, 1)

  let rec loop acc1 acc2 n =
    match n with
    | 0L -> acc1
    | 1L -> acc2
    | _ ->
      if memo.ContainsKey (n) then
        memo[n]
      else
        let t = loop acc2 (acc1 + acc2) (n - 1L)
        memo.Add (n, t) |> ignore
        t

  loop 0L 1L n

// note that the largest fibonacci number that can be represented by 32 bit (2_147_483_647) integer is the 46th (1_836_311_903) with the 47th being out of range (2_971_215_073)
// in 64 bit (9_223_372_036_854_775_807) this becomes the 92nd (7_540_113_804_746_346_429)
let fibCount = 50L
#time on
fibonacci fibCount |> printfn "Mathematically pure: %A"

#time off

#time on

memoized_fibonacci fibCount |> printfn "Memoized mathematically pure: %A"

#time off

#time on

tail_fibonacci fibCount |> printfn "Tail recursive: %A"

#time off

#time on

printf "First call:"
memoized_tail_fibonacci fibCount |> printfn "Memoized recursive: %A"

#time off

#time on

printf "Second call:"
memoized_tail_fibonacci fibCount |> printfn "Memoized recursive: %A"
#time off


// mutually recursive functions
// the `and` keyword is used to tie them together
open System
let rec Even x = if x = 0 then true else Odd(Math.Abs x - 1)
and Odd x = if x = 0 then false else Even (Math.Abs x - 1)

[-2; -1; 0; 1; 2] |> Seq.iter (fun v -> printfn "%i is %s." v (if Even v then "even" else "odd"))
[-12; -11; 0; 11; 12] |> Seq.iter (fun v -> printfn "% 3i is %s." v (if Odd v then "odd" else "even"))
