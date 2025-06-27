//
module imperative =

    let read_line () = System.Console.ReadLine ()
    let print_string s = printfn "%A" s

imperative.print_string "Hey - Who are you?"
let name = imperative.read_line ()
imperative.print_string ("Oh hey " + name)

module monadic =
    let read_line f = f (System.Console.ReadLine ())
    let print_string (s, f) = f (printfn "%s" s)

monadic.print_string (
    "yo-yo-yo - what's up?",
    fun () -> monadic.read_line (fun name -> monadic.print_string ("hey " + name, fun () -> ()))
)
