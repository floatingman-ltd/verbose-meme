// recursion is a function that calls itself
// they must be explicitly identified with the `rec` keyword

// the following will not compile because the keyword is missing
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
  // | n when n < 0 -> failwith "integer overflow results in flipping the signed bit"
  | 0L
  | 1L -> n
  | n -> fibonacci (n - 1L) + fibonacci (n - 2L)

// tail recursion
[<TailCall>]
let tail_fibonacci n =
  let rec loop acc1 acc2 n =
    match n with
    | 0L -> acc1
    | 1L -> acc2
    | _ -> loop acc2 (acc1 + acc2) (n - 1L)

  loop 0L 1L n

// memoization, this is a higher order function because it actually returns a function rather then defining a function
let memoized_fibonacci n =
  let memo = Map []

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
let fibCount = 60
#time on
fibonacci fibCount |> printfn "Mathematically pure: %A"

#time off
#time on

tail_fibonacci fibCount |> printfn "Tail recursive: %A"

#time off
#time on

printf "First call:"
memoized_fibonacci fibCount |> printfn "Memoized recursive: %A"

#time off

#time on

printf "Second call:"
memoized_fibonacci fibCount |> printfn "Memoized recursive: %A"
#time off
