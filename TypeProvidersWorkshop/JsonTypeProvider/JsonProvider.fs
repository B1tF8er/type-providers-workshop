module JsonProvider

open FSharp.Data

module private Types =
    type Posts = JsonProvider<Urls.Local.Posts>

    type Comments = JsonProvider<Urls.Local.Comments>

    type Albums = JsonProvider<Urls.Local.Albums>

    type Photos = JsonProvider<Urls.Local.Photos>

let run () =
    Types.Posts.Load(Urls.Web.Posts)
    |> Operations.``print twenty``

    Types.Comments.Load(Urls.Web.Comments)
    |> Operations.``print ten``

    Types.Albums.Load(Urls.Web.Albums)
    |> Operations.``print five``

    Types.Photos.Load(Urls.Web.Photos)
    |> Operations.printFirst 2
