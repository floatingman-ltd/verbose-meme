// repeat until, or breaking from a 'loop'
module FirstPass =

  // this is basically a closure function
  let tryGetSomethingFromApi  =
    let mutable thingCount = 0
    let maxThings = 10

    fun () ->
      if thingCount < maxThings then
        thingCount <- thingCount + 1
        "Soup"
      else
        null // done with soup

  let listThingsFromApi () =
    let mutable finished = false

    while not finished do
      let thing = tryGetSomethingFromApi()

      if thing <> null then
        printfn "I got %A" thing
      else
        printfn "Done here"
        finished <- true

module SecondPass =

  let tryGetSomethingFromApi  =
    let mutable thingCount = 0
    let maxThings = 10

    fun () ->
      if thingCount < maxThings then
        thingCount <- thingCount + 1
        "Soup"
      else
        null // done with soup

  let rec apiToSeq () =
    seq {
      match tryGetSomethingFromApi () |> Option.ofObj with
      | Some thing ->
        yield thing
        yield! apiToSeq ()
      | None -> ()
    }

  let listThingsFromApi () =
    apiToSeq () |> Seq.iter (printfn "I still have %A")


FirstPass.listThingsFromApi ()
SecondPass.listThingsFromApi ()
