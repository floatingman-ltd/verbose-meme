open System.IO

let cDrive = Directory.EnumerateDirectories "C:"

let dirInfos = cDrive |> Seq.map (fun d -> new DirectoryInfo(d))

// this is a sequence of tuples
let subDirInfo = dirInfos |> Seq.map (fun d -> (d.Name, d.CreationTimeUtc))

// but here the same two values have been converted to a key-value pair in the map
let mapDirInfo = subDirInfo |> Map.ofSeq 

let mapAge = mapDirInfo |> Map.map (fun name date -> 
    let now = System.DateTime.UtcNow
    (now - date).TotalDays
    )