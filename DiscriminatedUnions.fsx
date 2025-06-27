// composition of records
type Disk = { SizeGb: int}

type Computer= 
    {
        Manufacturer: string
        Disks: Disk list
    }

let myPc = 
    {
        Manufacturer = "Parts by me"
        Disks = 
            [
                {SizeGb  = 500}
                {SizeGb  = 1000}
                {SizeGb  = 1000}
            ]
    }

// also units of measure
[<Measure>] type Tb
[<Measure>] type Gb
[<Measure>] type Mb
[<Measure>] type Kb

type DiskSize = 
    | Kb of int<Kb>
    | Mb of int<Mb>
    | Gb of int<Gb>
    | Tb of int<Tb>

let asKb size = 
    match size with 
    | Kb size -> Kb size
    | Mb size -> Kb (size * 1024<_>)
    | Gb size -> Kb (size * 1024 * 1024<_>)
    | Tb size -> Kb (size * 1024 * 1034 * 1024<_>)

let asMb size =
    match size with 
    | Kb size -> Mb (size / 1024<_>)
    | Mb size -> Mb (size)
    | Gb size -> Mb (size * 1024<_>)
    | Tb size -> Mb (size * 1024 * 1024<_>)

// let asGb size =
//     match size with 
//     | Kb size -> size / (1024 * 1024)
//     | Mb size -> size / 1024<_>
//     | Gb size -> size * 1<_>
//     | Tb size -> size * 1024<_>
    
// let asTb size =
//     match size with 
//     | Kb size -> size / (1024 * 1024 * 1024)
//     | Mb size -> size / (1024 * 1024<_>)
//     | Gb size -> size / 1024<_>
//     | Tb size -> size * 1<_>

// research active patterns

// enums are easy
type Dog = 
    | Terrier = 0
    | Shepard = 1
    | PitBull = 2
