module RssHandler

open System

[<Literal>]
let private BaseUrl = "http://feeds.feedburner.com/"

let private urls = [
    sprintf "%sMetalInjection" BaseUrl
    sprintf "%sMetalSucks" BaseUrl
    sprintf "%sMetalUnderground" BaseUrl
]

let private printAllowedActions () =
    printfn ""
    printfn "Allowed actions are:"
    printfn "(g) - Get Feeds"
    printfn "(p) - Plot Feeds"
    printfn "(s) - Save Feeds"
    printfn "(e) - Exit"

let private printAction message =
    printfn ""
    printfn message

let private printUserActionErrorMessage () =
    printfn ""
    printfn ""
    printfn "Invalid user action"
    true

let private ask () =
    printAllowedActions ()

    match Console.ReadKey().KeyChar with
    | 'g' ->
        printAction "Getting Feeds..."
        urls |> List.iter RssProvider.get
        true
    | 'p' ->
        printAction "Plotting Feeds..."
        urls |> List.iter RssProvider.plot
        true
    | 's' ->
        printAction "Saving Feeds..."
        urls |> List.iter RssProvider.save
        true
    | 'e' -> false
    | _ -> printUserActionErrorMessage ()

let rec askUserInput () =
    match ask () with
    | true -> askUserInput ()
    | false -> ()
