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

let private runAction message action =
    message |> printAction
    urls |> List.iter action
    true

let private ask () =
    printAllowedActions ()

    match Console.ReadKey().KeyChar with
    | 'g' -> RssProvider.get |> runAction "Getting Feeds..."
    | 'p' -> RssProvider.plot |> runAction "Plotting Feeds..."
    | 's' -> RssProvider.save |> runAction "Saving Feeds..."
    | 'e' -> false
    | _ -> printUserActionErrorMessage ()

let rec askUserInput () =
    match ask () with
    | true -> askUserInput ()
    | false -> ()
