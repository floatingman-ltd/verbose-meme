// single case discriminated unions

type Address = Address of string
let myAddress = Address "1234 The Street"

// let liveTogether = (myAddress = "1234 The Street")
let (Address address) = myAddress

module ContactList =
    type Address = Address of string
    type Email = Email of string
    type Identifier = Identifier of string
    type PhoneNumber = PhoneNumber of string


    type Customer =
        { Address: Address
          Email: Email
          Identifier: Identifier
          PhoneNumber: PhoneNumber }

    let customerFactory address email identifier phoneNumber =
        { Address = address
          Email = email
          Identifier = identifier
          PhoneNumber = phoneNumber }

    let customer =
        customerFactory
            (Address "123 Road")
            (Email "Dragon@example.com")
            (Identifier "A-One")
            (PhoneNumber "873-555-1212")

    // combined discriminating unions
    type ContactMethod =
        | Address of string
        | PhoneNumber of string
        | Email of string

    type ImprovedCustomer =
        { Identifier: Identifier
          Primary: ContactMethod
          Secondary: ContactMethod option }

    let improvedFactory identity primary secondary =
        { Identifier = identity
          Primary = primary
          Secondary = secondary }

    let anotherCustomer =
        improvedFactory (Identifier "B-52") (Email "bomber@example.com") None

    printfn "%A" anotherCustomer.Identifier

    type GenuineImprovedCustomer = GenuineImprovedCustomer of ImprovedCustomer

// the result pattern
type Result<'a> =
| Success of 'a
| Failure of string

let functionThatCanFail customer =
    try
    Success "Ta-Da"
    with

// match functionThatCanFail (ContactList.Email "Dragon@example.com") with
// | Success customerId -> printfn "Saved with %A" customerId
// | Failure error -> printfn "%s" error
