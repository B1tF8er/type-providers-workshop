module MetalUndergroundRss

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalUnderground"

let getFeed () =
    Url
    |> RssProvider.getFeed
