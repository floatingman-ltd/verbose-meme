// as an exercise=
let strToInt (str : string) =
    let success, num = System.Int32.TryParse str
    if success then num else 0

type stringify() =

    member this.Bind (m, f) = f m

    member this.Return (x) = x

let stringer = new stringify ()

let stringAddWorkflow x y z =
    stringer {
        let! a = strToInt x
        let! b = strToInt y
        let! c = strToInt z
        return a + b + c
    }



// test
let good = stringAddWorkflow "12" "3" "2"
let bad = stringAddWorkflow "12" "xyz" "2"

let strAdd str = strToInt str
let (>>=) m f = f m

let good = strToInt "1" >>= strAdd "2" >>= strAdd "3"
let bad = strToInt "1" >>= strAdd "xyz" >>= strAdd "3"
