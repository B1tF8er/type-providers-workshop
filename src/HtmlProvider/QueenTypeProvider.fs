module QueenTypeProvider

open FSharp.Data
open XPlot.GoogleCharts

[<Literal>]
let QueenDiscographyUrl = "https://en.wikipedia.org/wiki/Queen_discography"

type QueenDiscography = HtmlProvider<QueenDiscographyUrl>

let getData () =
    let sample = QueenDiscography.GetSample()

    sample.Tables.``Studio albums``.Rows
    |> Array.iter (fun album ->
        printfn "%s - %A" album.Title album.``Album details``
    )

    [
        sample.Tables.``1970s``.Rows,
        sample.Tables.``1980s``.Rows,
        sample.Tables.``1990s``.Rows,
        sample.Tables.``2000s``.Rows,
        sample.Tables.``2010s``.Rows
    ]
    |> List.iter (fun singles -> printfn "%A" singles)

let asColumn (sample : QueenDiscography) (row : QueenDiscography.``1970s``.Row) =
    let singlesPerYear =
        sample.Tables.``1970s``.Rows
        |> Array.filter (fun r -> r.Year = row.Year)
        |> Array.length

    (row.Year.ToString(), singlesPerYear)

let getReleaseYears (sample : QueenDiscography) =
    sample.Tables.``1970s``.Rows
    |> List.ofSeq
    |> List.map (fun row -> sprintf "Singles from %i" row.Year)
    |> List.distinct

let plotData () =
    let sample = QueenDiscography.GetSample()

    sample.Tables.``1970s``.Rows
    |> Seq.ofArray
    |> Seq.map (sample |> asColumn)
    |> Seq.groupBy (fun column -> column |> fst)
    |> Seq.map (fun group -> group |> snd)
    |> Chart.Column
    |> Chart.WithOptions (Options (title = "1970's Singles"))
    |> Chart.WithLabels (sample |> getReleaseYears)
    |> Chart.Show

let run () =
    getData ()
    plotData ()
