module MetalSucksRss

open Domain

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalSucks"
    
let create () =
    {
        get = fun () -> Url |> RssProvider.get
        plot = fun () -> Url |> RssProvider.plot
        save = fun () -> Url |> RssProvider.save
    }
