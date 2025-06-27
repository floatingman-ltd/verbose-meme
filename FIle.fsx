open System.IO

let roots = 
    Directory.GetLogicalDrives().[0..1]

let files =
    // this can be reduced to 
    // List.map Directory.GetFiles
    Array.collect Directory.GetFiles

let asFileInfo = 
    Array.map (fun f -> 
        let fileInfo = new FileInfo(f)
        fileInfo
        )

type GroupBy = FileInfo[] -> (string * FileInfo[])[]
let groupBy:GroupBy = 
    Array.groupBy (fun f -> f.DirectoryName)

type Folder = 
    {
        Name: string
        Size: int64
        NumberOfFiles: int
        AverageSize : float
        Extensions: string[]
    }

let mapFolder (n, f) =
    {
        Name = n
        Size = f |> Array.sumBy (fun (x:FileInfo) -> x.Length) 
        NumberOfFiles = Array.length(f)
        AverageSize = f |> Array.averageBy (fun x -> float x.Length)
        Extensions = f |> Array.distinctBy (fun x ->  x.Extension) |> Array.map (fun x -> x.Extension)
    }

let folder =
   Array.map (fun (n,f) -> mapFolder (n,f))

let fileViewer = 
    roots 
    |> files
    |> asFileInfo
    |> groupBy
    |> folder