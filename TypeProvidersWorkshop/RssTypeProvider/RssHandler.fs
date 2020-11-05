module RssHandler

open Domain
open System

let private rssFeeds = [
    MetalInjectionRss.create ()
    MetalSucksRss.create ()
    MetalUndergroundRss.create ()
]

let private get rssFeed =
    rssFeed.getFeed ()

let private plot rssFeed =
    rssFeed.plotFeed ()

let private save rssFeed =
    rssFeed.saveFeed ()

let private readUserAction () =
    Console.ReadKey().KeyChar

let private printAllowedActions () =
    printfn ""
    printfn "Allowed actions are:"
    printfn "(g) - Get Feeds"
    printfn "(p) - Plot Feeds"
    printfn "(s) - Save Feeds"
    printfn "(e) - Exit"

let private printUserActionErrorMessage () =
    printfn ""
    printfn ""
    printfn "Invalid user action"

let private printAction message =
    printfn ""
    printfn message

let private ask () =
    printAllowedActions ()

    match readUserAction () with
    | 'g' ->
        printAction "Getting Feeds..."
        rssFeeds |> List.iter get
        true
    | 'p' ->
        printAction "Plotting Feeds..."
        rssFeeds |> List.iter plot
        true
    | 's' ->
        printAction "Savings Feeds..."
        rssFeeds |> List.iter save
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
