open Domain
open System

let private rssFeeds = [
    MetalInjectionRss.create ()
    MetalSucksRss.create ()
    MetalUndergroundRss.create ()
]

let private get rssFeed = rssFeed.getFeed ()

let private plot rssFeed = rssFeed.plotFeed ()

let private save rssFeed = rssFeed.saveFeed ()

let private readUserAction () =
    Console.ReadKey().KeyChar.ToString().ToLowerInvariant()

let [<Literal>] private AllowedActions =
    "Allowed actions are: (g) Get Feeds | (p) Plot Feeds | (s) Save Feeds | (e) Exit"

let private UserActionErrorMessage =
    sprintf "Invalid user action, %s" AllowedActions

let private printMessage message =
    printfn ""
    printfn "%s" message

let askUserAction () =
    AllowedActions |> printMessage

    match readUserAction () with
    | "g" ->
        rssFeeds |> List.iter get
        true
    | "p" ->
        rssFeeds |> List.iter plot
        true
    | "s" ->
        rssFeeds |> List.iter save
        true
    | "e" ->
        false
    | _ ->
        UserActionErrorMessage |> printMessage
        true

[<EntryPoint>]
let main _ =
    printfn "RSS TYPE PROVIDERS WITH F#!"

    let mutable askAgain = true

    while (askAgain) do
        askAgain <- askUserAction ()

    0
