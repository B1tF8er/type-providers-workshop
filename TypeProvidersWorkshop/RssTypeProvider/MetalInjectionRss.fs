module MetalInjectionRss

open Domain

let [<Literal>] private Url =
    "http://feeds.feedburner.com/MetalInjection"

let create () =
    {
        get = fun () -> Url |> RssProvider.get
        plot = fun () -> Url |> RssProvider.plot
        save = fun () -> Url |> RssProvider.save
    }
