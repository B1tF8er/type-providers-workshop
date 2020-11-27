module RssHandler

open Domain
open System

let private rssFeeds = [
    MetalInjectionRss.create
    MetalSucksRss.create
    MetalUndergroundRss.create
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

let private get rssFeed =
    () |> rssFeed.get

let private plot rssFeed =
    () |> rssFeed.plot

let private save rssFeed =
    () |> rssFeed.save

let private run action =
    printAction "Executing Action on Feeds..."
    rssFeeds |> List.iter action
    true

let private ask () =
    printAllowedActions ()

    match Console.ReadKey().KeyChar with
    | 'g' -> get |> run
    | 'p' -> plot |> run
    | 's' -> save |> run
    | 'e' -> false
    | _ -> printUserActionErrorMessage ()

let rec askUserInput () =
    match ask () with
    | true -> askUserInput ()
    | false -> ()
