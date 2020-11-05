module MetalSucksRss

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalSucks"

let getFeed () =
    Url
    |> RssProvider.getFeed
