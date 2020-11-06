module RssHandler

open Domain
open System

let private rssFeeds = [
    MetalInjectionRss.create ()
    MetalSucksRss.create ()
    MetalUndergroundRss.create ()
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

let private ask () =
    printAllowedActions ()

    match Console.ReadKey().KeyChar with
    | 'g' ->
        printAction "Getting Feeds..."
        rssFeeds |> List.iter (fun rssFeed -> rssFeed.get ())
        true
    | 'p' ->
        printAction "Plotting Feeds..."
        rssFeeds |> List.iter (fun rssFeed -> rssFeed.plot ())
        true
    | 's' ->
        printAction "Savings Feeds..."
        rssFeeds |> List.iter (fun rssFeed -> rssFeed.save ())
        true
    | 'e' ->
        false
    | _ ->
        printUserActionErrorMessage ()
        true

let rec askUserInput () =
    match ask () with
    | true -> askUserInput ()
    | false -> ()
