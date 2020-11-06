module JsonProvider

open FSharp.Data

module private LocalUrls =
    [<Literal>]
    let Posts = @".\Resources\posts.json"

    [<Literal>]
    let Comments = @".\Resources\comments.json"

    [<Literal>]
    let Albums = @".\Resources\albums.json"

    [<Literal>]
    let Photos = @".\Resources\photos.json"

module private WebUrls =
    [<Literal>]
    let Posts = "https://jsonplaceholder.typicode.com/posts"

    [<Literal>]
    let Comments = "https://jsonplaceholder.typicode.com/comments"

    [<Literal>]
    let Albums = "https://jsonplaceholder.typicode.com/albums"

    [<Literal>]
    let Photos = "https://jsonplaceholder.typicode.com/photos"

module private Types =
    type Posts = JsonProvider<LocalUrls.Posts>

    type Comments = JsonProvider<LocalUrls.Comments>

    type Albums = JsonProvider<LocalUrls.Albums>

    type Photos = JsonProvider<LocalUrls.Photos>

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
    Types.Posts.Load(WebUrls.Posts)
    |> ``print twenty items``

let private getComments () =
    Types.Comments.Load(WebUrls.Comments)
    |> ``print ten items``

let private getAlbums () =
    Types.Albums.Load(WebUrls.Albums)
    |> ``print five items``

let private getPhotos () =
    Types.Photos.Load(WebUrls.Photos)
    |> printFirst N

let run () =
    getPosts ()
    getComments ()
    getAlbums ()
    getPhotos ()
