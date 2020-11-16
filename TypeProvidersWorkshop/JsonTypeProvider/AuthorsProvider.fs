module AuthorsProvider

open Domain
open FSharp.Data

[<Literal>]
let SampleAuthorUrl = "https://openlibrary.org/authors/OL34184A.json"

type Author = JsonProvider<SampleAuthorUrl>

let print authorKey =
    let authorUrl = sprintf "https://openlibrary.org%s.json" authorKey
    let sample = Author.Load(authorUrl)
    
    printfn "Author Name: %s" sample.Name
    printfn "Author Date of Birth: %A" sample.BirthDate
    sample.Links
    |> Array.iter (fun link ->
        printfn "Author Link: %A" link.Url
    )

let asShareableObject authorKey =
    let authorUrl = sprintf "https://openlibrary.org%s.json" authorKey
    let sample = Author.Load(authorUrl)

    {
        Name = Name sample.Name 
        BirthDate = BirthDate sample.BirthDate
        Links =
            sample.Links
            |> Seq.ofArray
            |> Seq.map (fun link ->
                Link (sprintf "Author Link: %A" link.Url)
            )
    }
