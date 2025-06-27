type House = { Address : string; Price : decimal }

module House =

  let private random = System.Random (Seed = 1)

  // Random number of houses
  let getRandom count =
    Array.init
      count
      (fun i ->
        {
          Address = sprintf "%i Doogie Road" (i + 1)
          Price = random.Next (50_000, 500_000) |> decimal
        }
      )

module Distance =

  let private random = System.Random (Seed = 1)

  let tryToSchool house =
    let dist = random.Next 10 |> double
    if dist < 5.0 then Some dist else None

type PriceBand =
  | Cheap
  | Medium
  | Expensive

module PriceBand =
  let fromPrice price =
    match price with
    | p when p < 10_000m -> Cheap
    | p when p < 200_000m -> Medium
    | _ -> Expensive

// exercise one - formatting 20 houses
let housePrices =
  House.getRandom 20
  |> Array.map (fun h -> sprintf "Address: %s | Price: $%.2f" h.Address h.Price)

// exercise two - average house cost
let averageCost = House.getRandom 20 |> Array.averageBy (fun h -> h.Price)

// exercise three - list of houses over 250,000
let priceyHouses =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price > 250_000m)
  // pretty print
  |> Array.map (fun h -> sprintf "Address: %s | Price: $%.2f" h.Address h.Price)

// exercise four - distance to school
let distanceToSchool =
  House.getRandom 20
  |> Array.choose (fun h ->
    match h |> Distance.tryToSchool with
    | Some d -> Some (h, d)
    | None -> None
  )

// exercise five - filter and iterate
let filterAndIterate =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price > 100_000m)
  |> Array.iter (fun h -> printfn "Address: %s | Price: $%.2f" h.Address h.Price)

// exercise six - filter, order and iterate
let filterOrderAndIterate =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price > 100_000m)
  |> Array.sortByDescending (fun h -> h.Price)
  |> Array.iter (fun h -> printfn "Address: %s | Price: $%.2f" h.Address h.Price)

// exercise seven - filter and average
let filterAndAverage =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price > 200_000m)
  |> Array.averageBy (fun h -> h.Price)

// exercise eight - find an element
let findAHouse =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price < 100_000m)
  |> Array.pick (fun h ->
    match h |> Distance.tryToSchool with
    | Some d -> Some (h, d)
    | None -> None
  )

// exercise nine - grouping
let grouping =
  House.getRandom 20
  |> Array.groupBy (fun h -> h.Price |> PriceBand.fromPrice)
  |> Array.map (fun (p, h) -> p, h |> Array.sortBy (fun h' -> h'.Price))

// exercise ten - partial functions
module Array =
  let tryAverage (a : House[]) =
    match a |> Array.length with
    | 0 -> None
    | _ -> Some (a |> Array.averageBy (fun h -> h.Price))

let filterAverageAndTry criteria =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price > criteria)
  |> Array.tryAverage

let somePrice = filterAverageAndTry 200_000m
let nonePrice = filterAverageAndTry 500_000m

// exercise eleven

let cheapAndHasSchool criteria =
  House.getRandom 20
  |> Array.filter (fun h -> h.Price < criteria)
  |> Array.tryPick (fun h ->
    match h |> Distance.tryToSchool with
    | Some d -> Some (h, d)
    | None -> None
  )

let someCheap = cheapAndHasSchool 100_000m
let noneCheap = cheapAndHasSchool 10_000m
