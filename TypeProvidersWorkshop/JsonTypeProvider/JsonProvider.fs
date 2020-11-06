module JsonProvider

open FSharp.Data

module private Types =
    type Posts = JsonProvider<Urls.Local.Posts>

    type Comments = JsonProvider<Urls.Local.Comments>

    type Albums = JsonProvider<Urls.Local.Albums>

    type Photos = JsonProvider<Urls.Local.Photos>

[<Literal>]
let private N = 2

let private print item = printfn "%A" item

let private printFirst n items =
    items
    |> Array.take n
    |> Array.iter print

let private ``print twenty items`` =
    printFirst 20

let private ``print ten items`` =
    printFirst 10

let private ``print five items`` =
    printFirst 5

let private getPosts () =
    Types.Posts.Load(Urls.Web.Posts)
    |> ``print twenty items``

let private getComments () =
    Types.Comments.Load(Urls.Web.Comments)
    |> ``print ten items``

let private getAlbums () =
    Types.Albums.Load(Urls.Web.Albums)
    |> ``print five items``

let private getPhotos () =
    Types.Photos.Load(Urls.Web.Photos)
    |> printFirst N

let run () =
    getPosts ()
    getComments ()
    getAlbums ()
    getPhotos ()
