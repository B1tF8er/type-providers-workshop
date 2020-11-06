module Operations

let private print item =
    printfn "%A" item

let printFirst n items =
    items
    |> Array.take n
    |> Array.iter print

let ``print twenty`` items =
    items
    |> printFirst 20

let ``print ten`` items =
    items
    |> printFirst 10

let ``print five`` items =
    items
    |> printFirst 5
