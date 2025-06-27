open System.Collections.Generic

// Dictionary <t,u>
let inventory = Dictionary<string,float>()
inventory.Add("Apples",1.25)
inventory.Add("Bananas",0.65)
inventory.Add("Cucumbers",3.25)
inventory.Add("Dill",0.25)

let banana = inventory.["Bananas"]

// should throw a KeyNotFoundException
// let zebra = inventory.["Zebra"]

// this initially declares an infered generic
let immutableInventory: IDictionary<_,_> = 
    ["apples",1.23;"bananas",0.45]
    |> dict

let otherBanana = immutableInventory.["bananas"]

// should throw NotSupportedException
// immutableInventory.Add("cucumber",2.92)
// immutableInventory.Remove("bananas")

// Map
let mapInv =
    ["apples",1.23;"bananas",0.45]
    |> Map.ofList

let mapApple = mapInv.["apples"] 

// same KeyNotFound
// let mapPineapple = mapInv.["pineapples"]

let newMapInv = 
    mapInv
    |> Map.add "pineapples" 1.23
    |> Map.remove "apples"

let mapPineapple = newMapInv.["pineapples"]

let cheapFruit, expensiveFruit = 
    mapInv
    |> Map.partition (fun fruit cost -> cost < 1.0)
