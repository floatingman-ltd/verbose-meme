// If we list all the natural number below 10 that are multiples of 3 or 5, we get 3,5,6,and 9.
// The sum of these multiples is 23.
//
// Find the sum of all the multiples of 3 or 5 below 100.

// common
let ceiling = 999

//* brute force
let isMultipleOf divisor product = product % divisor = 0

let isMultipleOf3 product = isMultipleOf 3 product

let isMultipleOf5 product = isMultipleOf 5 product

let isMultipleOf3Or5 product =
  product |> isMultipleOf3 || product |> isMultipleOf5

let bruteForceAnswer = [ 1..ceiling ] |> Seq.filter (isMultipleOf3Or5) |> Seq.sum

bruteForceAnswer |> printfn "Current answer is: %A"

//* elegance

let sumDivisibleBy n =
  let p = ceiling / n
  n * p * (p + 1) / 2

sumDivisibleBy 3 + sumDivisibleBy 5 - sumDivisibleBy 15
