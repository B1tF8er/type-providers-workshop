module Domain

type RssFeed =
    {
        get : unit -> unit
        plot : unit -> unit
        save : unit -> unit
    }

type Item =
    {
        Title : string
        Link : string
        Comments : int
    }

type Channel =
    {
        Title : string
        Items : Item list
    }

type Feed =
    {
        Channel : Channel
    }
