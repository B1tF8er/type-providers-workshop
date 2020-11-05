module MetalInjectionRss

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalInjection"

let getFeed () =
    Url
    |> RssProvider.getFeed
