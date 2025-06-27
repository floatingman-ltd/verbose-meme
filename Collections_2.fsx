// Map, dictionaries and sets

// Mutable dictionaries, generally avoid the IDictionary and f# `idict`

// Map
// the final `"Oranges",0.34` will override the previous entry
let inventory =
    [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.12; "Oranges", 0.34 ]
    |> Map.ofList

inventory 
    |> Map.add "Pineapples" 0.87
    |> Map.partition (fun fruit cost -> cost >= 0.50 )

inventory
    |> Map.remove "Bananas"

// for example:
open System
open System.IO

Directory.EnumerateDirectories "/"
    |> Seq.map (fun dir -> dir |> DirectoryInfo)
    |> Seq.map (fun dir -> dir.Name, dir.CreationTimeUtc)
    |> Map.ofSeq
// the key value is returned automatically 
    |> Map.map (fun name date -> DateTime.UtcNow.Subtract(date).Days )
    
// Sets

let myBasket = ["Apples";"Apples";"Apples";"Bananas";"Pineapples"]
let myFruits = 
    myBasket
    |> Set.ofList