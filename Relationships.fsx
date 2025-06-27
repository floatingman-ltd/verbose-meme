// basic composition

type Disk = { SizeGb : int }
type Computer = { CPU : string; Disks : Disk List }

let thislaptop =
  {
    CPU = "AMD"
    Disks = [ { SizeGb = 500 } ]
  }

// discriminated unions
type Drive =
  | HardDisk of RPM : int * Platters : int
  | SolidState
  | MMC of NumberOfPins : int

let hd_1 = HardDisk (RPM = 7200, Platters = 5)
let hd_2 = HardDisk (5400, 4)
let args = 7200, 6
let hd_3 = HardDisk args
let ssd = SolidState
let mmc = MMC 5

// DU and pattern matching
let seek disk =
  match disk with
  | HardDisk (5400, _) -> "Slow ahead"
  | HardDisk (7200, platters) -> $"Platters : {platters}"
  | HardDisk _ -> "Seeking loudly"
  | SolidState _ -> "Done!"
  | MMC _ -> "Shh"
// avoid using the `_` wildcard match  it will not warn on new discriminating union members
hd_1 |> seek

// shared fields
type DriveInfo =
  {
    Manufacturer : string
    SizeGb : int
    Hardware : Drive
  }

type Device =
  {
    Manufacturer : string
    Drives : DriveInfo List
  }

let (myOtherComputer : Device) =
  {
    Manufacturer = "Me"
    Drives =
      [
        {
          Manufacturer = "Western Digital"
          SizeGb = 1000
          Hardware = SolidState
        }
      ]
  }

// enums
type Printer =
  | DotMatrix = 0
  | Laser = 1
  | InkJet = 2
  | Thermal = 3
