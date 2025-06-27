// record
type FootballResult =
    { 
        HomeTeam : string      
        AwayTeam : string      
        HomeGoals : int      
        AwayGoals : int 
    }


let create (ht, hg) (at, ag) =    
    { 
        HomeTeam = ht;
        AwayTeam = at; 
        HomeGoals = hg; 
        AwayGoals = ag 
    }    

let results =
    [ 
        create ("Messiville", 1) ("Ronaldo City", 2)
        create ("Messiville", 1) ("Bale Town", 3) 
        create ("Bale Town", 3) ("Ronaldo City", 1)      
        create ("Bale Town", 2) ("Messiville", 1)      
        create ("Ronaldo City", 4) ("Messiville", 2)      
        create ("Ronaldo City", 1) ("Bale Town", 2) 
    ]

let record season = 
    season 
    |> List.filter (fun game -> game.HomeGoals < game.AwayGoals)
    |> List.countBy (fun  result -> result.AwayTeam)
    |> List.sortByDescending (fun (_, awayWins) -> awayWins)

record results


// comparing seq to list to array

let anArray = [|"A";"B";"C";|]
anArray.[2]
anArray.[2] <- "X"

let aList =  ["A";"B";"C"]
aList.[2]
// aList.[2] <- "X" // does not allow 

let aSeq = seq {1..3}
// aSeq.[0] // does not allow

// aggregates

let numbers = [1.0 .. 10.0]   
let total = numbers |> List.sum
let average = numbers |> List.average

let max = numbers |> List.max

let min = numbers |> List.min
