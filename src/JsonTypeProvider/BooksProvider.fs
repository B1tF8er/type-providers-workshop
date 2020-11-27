module BooksProvider

open Domain
open FSharp.Data
open XPlot.GoogleCharts

let bookKeys = 
    [
        "OL45883W" // Fantastic Mr. FOX
        "OL82563W" // Harry Potter and the Philosopher's Stone
        "OL1955941W" // Game of Thrones
    ]

[<Literal>]
let SampleBookUrl = "https://openlibrary.org/works/OL45883W.json"

type Book = JsonProvider<SampleBookUrl>

let separator () =
    [1 .. 50]
    |> List.iter (fun _ -> printf "+")
    printfn ""

let print bookKey =
    let bookUrl = sprintf "https://openlibrary.org/works/%s.json" bookKey
    let sample = Book.Load(bookUrl)

    separator ()

    printfn "Book Title: %s" sample.Title
    sample.Authors
    |> Array.map (fun author -> author.Author.Key)
    |> Array.iter (fun authorKey ->
        authorKey |> AuthorsProvider.print
    )

let asShareableObject bookKey =
    let bookUrl = sprintf "https://openlibrary.org/works/%s.json" bookKey
    let sample = Book.Load(bookUrl)

    {
        Title = Title sample.Title
        Authors =
            sample.Authors
            |> Seq.ofArray
            |> Seq.map (fun author ->
                author.Author.Key
                |> AuthorsProvider.asShareableObject
            )
    }

let asChartColumn publicAuthor =
    let (Name name) = publicAuthor.Name
    let links = publicAuthor.Links |> Seq.length

    (name, links)

let plot bookKey =
    let publicBook =
        bookKey
        |> asShareableObject

    let chartOptions =
        Options (
            title = "Links per Author"
        )

    publicBook.Authors
    |> Seq.map asChartColumn
    |> Chart.Column
    |> Chart.WithOptions chartOptions
    |> Chart.WithLabels ["External Links"]
    |> Chart.Show

let run () =
    bookKeys
    |> List.iter print
    
    bookKeys
    |> List.map asShareableObject
    |> List.iter (fun publicBook -> 
        separator ()
        printfn "%A" publicBook
    )

    bookKeys
    |> List.iter plot
