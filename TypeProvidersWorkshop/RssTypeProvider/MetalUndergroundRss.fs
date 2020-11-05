module MetalUndergroundRss

open Domain

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalUnderground"

let private getFeed () =
    Url
    |> RssProvider.getFeed

let private plotFeed () =
    Url
    |> RssProvider.plotFeed

let private saveFeed () =
    Url
    |> RssProvider.saveFeed

let create () =
    {
        getFeed = getFeed
        plotFeed = plotFeed
        saveFeed = saveFeed
    }
