open System
// nullable values in f#
let aNumber: int = 10;
let bNumber: int option = Some 10;

let calculation score =
    match score with 
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None -> 
        printfn "Assigning a temporary value"
        300

type Client =
    {
        Name: string
        SafetyScore: int option
        FirstLicensed: DateTime
    }

let insurance client =
    match client with
    | {SafetyScore = Some 0} -> 250
    | SafetyScore when SafetyScore < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "Assigning a temporary value"
        300