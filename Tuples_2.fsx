let nameAndAge = "Dragon", "Fafnir", 54

let explicit : int * int = 10, 0

let implicit = 2, 5

let addNumber arguments =
  let a, b = arguments
  a + b

let x = addNumber (1, 2)
