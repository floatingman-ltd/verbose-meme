// Unit and option

// Option
let definitelyAnInteger = 10
let maybeAnInteger = Some 10

let calculate value =
  match value with
  | Some 0 -> 0
  | Some value when value < 0 -> -100
  | Some value when value > 0 -> 100
  | None -> 1000

maybeAnInteger |> calculate

// in a record
type Person =
  {
    FirstName : string
    MiddleName : string option
    LastName : string
  }

let showName person =
  match person.MiddleName with
  | None -> printfn $"{person.FirstName} {person.LastName}"
  | Some name -> printfn $"{person.FirstName} {name} {person.LastName}"

let Dragon =
  {
    FirstName = "Dragon"
    LastName = "Fafnir"
    MiddleName = Some "Tiamat"
  }

let Unicorn =
  {
    FirstName = "Unicorn"
    LastName = "Fafnir"
    MiddleName = None
  }

// default value
let middle person =
  person.MiddleName |> Option.defaultValue "Beautiful"

Unicorn |> middle
Dragon |> middle

// iter
Dragon.MiddleName |> Option.iter (fun name -> printfn $"{name}")
Unicorn.MiddleName |> Option.iter (fun name -> printfn $"{name}")

// map
Dragon.MiddleName |> Option.map (fun name -> name.[0])
Unicorn.MiddleName |> Option.map (fun name -> name.[0])
