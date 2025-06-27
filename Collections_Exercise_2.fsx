// clipping
let clip max collection =
  collection |> Seq.map (fun f -> min f max)

let clipped = [| 1.0; 2.3; 11.1; -5.0 |] |> clip 10.

printfn "%A" clipped

// min-max
let min_max collection =
  collection |> Array.min, //* note the coma and resultant implied tuple return with out parenthesis
  collection |> Array.max

[| 1.0; 2.3; 11.1; -5.0 |] |> min_max
