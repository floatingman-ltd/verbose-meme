// currying
let add a b = a + b
let add5 = add 5

let answer = add5 5


// uncurried function
let b_add (a, b) = a + b

let b_answer = b_add (5, 5)
// constrained functions
open System
let buildDate year month day = DateTime(year, month, day)

// using wrapper functions
let buildDateThisYear month day =
    buildDate DateTime.UtcNow.Year month day

let buildDateThisMonth day =
    buildDateThisYear DateTime.UtcNow.Month day

// using currying
let curryBuildDateThisYear = buildDate DateTime.UtcNow.Year
let curryBuildDateThisMonth = curryBuildDateThisYear DateTime.UtcNow.Month

// for example
let uncurried = buildDateThisMonth 15
let curried = curryBuildDateThisMonth 15

// practical example
let writeToFile (date: DateTime) filename text =
    let path = sprintf "%s-%s.txt" (date.ToString "yyyyMMdd") filename
    System.IO.File.WriteAllText(path, text)

let writeToToday = writeToFile DateTime.UtcNow.Date

// here's a funny thing 1.0 can equally be written as 1. and 0.1 as .1, both result in a double or 1m
let writeAsTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays 1.0)

// uncomment this to see in effect
// writeToToday "afile" "The quick brown fox jumped over the lazy dog."

// pipelines ...
let CheckCreation whenCreated = whenCreated < DateTime.UtcNow

let time =
    let directory = System.IO.Directory.GetCurrentDirectory()
    System.IO.Directory.GetCreationTime directory

CheckCreation time

open System.IO

()
|> Directory.GetCurrentDirectory
|> Directory.GetCreationTime
|> CheckCreation

// as a composed function
let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory >> Directory.GetCreationTime >> CheckCreation

let description = () |> checkCurrentDirectoryAge

// this is fun

let times a b = a * b
let anotheranswer = 10 |> add 5 |> times 2 |> add -3 |> times -3
