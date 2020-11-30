module Domain

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
