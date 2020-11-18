module QueenTypeProvider

open FSharp.Data

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

let run () =
    getData ()
