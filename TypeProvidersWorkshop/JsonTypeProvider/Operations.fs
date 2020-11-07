module Operations

module Print =
    let private print item =
        printfn "%A" item
    
    let first n items =
        items
        |> Array.take n
        |> Array.iter print
    
    let ``first twenty`` items =
        items
        |> first 20
    
    let ``first ten`` items =
        items
        |> first 10
    
    let ``first five`` items =
        items
        |> first 5

module Plot =
    open XPlot.GoogleCharts

    let totalPostsPerUser (items : (int * int) seq) =
        items
        |> Chart.Column
        |> Chart.Show

    let totalCommentsPerPost (items : (int * int) seq) =
        items
        |> Chart.Line
        |> Chart.Show

    let totalAlbumsPerUser (items : (int * int) seq) =
        items
        |> Chart.Bar
        |> Chart.Show

    let photos (items : (string * int * int) seq) =
        items
        |> Chart.Bubble
        |> Chart.Show
