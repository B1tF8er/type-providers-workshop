module MetalSucksRss

open FSharp.Data

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalSucks"

let getFeed () =
    Url
    |> RssProvider.getFeed
