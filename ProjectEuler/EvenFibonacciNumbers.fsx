// Each new term in the Fibonacci sequence is generated by adding the previous two terms.
// By starting with 1 and 2, the first 10 terms will be:
// 1,2,3,5,8,13,21,34,55,89,...
// By considering the terms in the Fibonacci sequence whose values do not exceed four
// million, find the sum of the even-valued terms.

//* brute force

// tail recursion
[<TailCall>]
let tail_fibonacci n =
  let rec loop acc1 acc2 n =
    match n with
    | 0L -> acc1
    | 1L -> acc2
    | _ -> loop acc2 (acc1 + acc2) (n - 1L)

  loop 0L 1L n

let isEven v = v % 2L = 0L

#time on

let brute_fib =
  Seq.initInfinite (fun i -> tail_fibonacci i)
  |> Seq.takeWhile (fun v -> v <= 4_000_000L)
  |> Seq.filter (fun v -> isEven v)
  |> Seq.sum

#time off

printfn "Brute force: %i" brute_fib

// refinement #1 - golden ratio
let fib_series =
  Seq.initInfinite (fun i -> tail_fibonacci i)
  |> Seq.takeWhile (fun v -> v <= 4_000_000L)
  // |> Seq.filter (fun v -> isEven v)
  |> Seq.toArray
// |> Seq.iter (fun v -> printf "%i " v)
fib_series
|> Array.iteri (fun i v -> printfn "% 3i: % 8i - %A " i v (float (v) / float (fib_series[max 0 (i - 1)])))

open System
open System.Collections.Generic

let Phi = (1.0 + Math.Sqrt 5.0) / 2.0
let Phi' = 1.0 / Phi
let Phi'' = Math.Pow (Phi, 3)

let memoize f =
  let memo = new Dictionary<_, _> ()
  memo.Add (0, 0)
  memo.Add (1, 1)
  memo.Add (2, 1)
  memo.Add (3, 2)

  fun x ->
    if memo.ContainsKey x then
      memo[x]
    else
      let t = f x
      memo.Add (x, t) |> ignore
      t

// given one fibonacci number determine the next
let floor n = int (Math.Floor (float n / Phi'))
let ceiling n = int (Math.Ceiling (float n / Phi'))

[| 0, 1; 1, 1; 1, 2; 2, 3; 3, 5; 5, 8; 8, 13; 13, 21; 21, 34 |]
// |> Seq.map following_fibonacci
|> Seq.iter (fun (v, v') -> printfn "% 3i : % 3i : % 3i : % 3i" v v' (floor v) (ceiling v))

let following_EvenFibonacci n = int (Math.Floor (float n * Phi''))

let memo_fibonacci n = memoize floor n


let phi_fib =
  2
  // |> Seq.unfold (fun i -> if i > 4_000_000 then None else Some (i, following_EvenFibonacci i))
  |> Seq.unfold (fun i -> if i > 4_000_000 then None else Some (i, floor i))
  // |> Seq.filter (fun v -> isEven v)
  |> Seq.iter (fun v -> printfn "%i " v)
// |> Seq.sum


#time on

let unfold =
  (0, 1)
  |> Seq.unfold (fun (last, current) ->

    if (current > 4_000_000) then
      None
    else
      let next = last + current
      let state = current, next
      Some (current, state)
  )
  |> Seq.filter (fun v -> isEven v)

unfold
  |> Seq.iter (printfn "% 8i")
  // |> Seq.sum
#time off

printfn "Unfolding: %i" (unfold |> Seq.sum)

