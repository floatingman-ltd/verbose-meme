// Records are declared between `{` and `}`
// Fields are delimited with `;` or newlines
// Fields must have type definition
type Colour = { R: byte; G: byte; B: byte }

type Person =
    { FirstName: string
      LastName: string
      FavoriteMathConstant: double
      FavoriteColour: Colour
      Children: Person[] }


// required to access the `Math` namespace
open System

// declaration
let Dragon =
    { FirstName = "Dragon"
      LastName = "Fafnir"
      FavoriteMathConstant = Math.E
      FavoriteColour = { R = 0uy; G = 0uy; B = 0uy }
      Children = [||] }

// Non-destructive decomposition
let Unicorn =
    { Dragon with
        FirstName = "Unicorn"
        FavoriteMathConstant = Math.PI }
