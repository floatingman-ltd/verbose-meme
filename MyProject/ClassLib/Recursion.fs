namespace FSharpClassLib

module Recursion =
  // This will issue "warning FS3569: The member or function 'badCountDown' has the 'TailCallAttribute' attribute, but is not being used in a tail recursive way."
  [<TailCall>]
  let rec badCountDown n =
    if n = 0 then 0 else badCountDown (n - 1) + 1

  [<TailCall>]
  let rec goodCountDown n =
    if n = 0 then 0 else goodCountDown (n - 1)
