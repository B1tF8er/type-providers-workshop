module JsonProvider

open FSharp.Data

module private Urls =
    [<Literal>]
    let Posts = "https://jsonplaceholder.typicode.com/posts"

    [<Literal>]
    let Comments = "https://jsonplaceholder.typicode.com/comments"

    [<Literal>]
    let Albums = "https://jsonplaceholder.typicode.com/albums"

    [<Literal>]
    let Photos = "https://jsonplaceholder.typicode.com/photos"

module private Types =
    type Posts = JsonProvider<Urls.Posts>

    type Comments = JsonProvider<Urls.Comments>

    type Albums = JsonProvider<Urls.Albums>

    type Photos = JsonProvider<Urls.Photos>

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
    Types.Posts.GetSamples()
    |> ``print twenty items``

let private getComments () =
    Types.Comments.GetSamples()
    |> ``print ten items``

let private getAlbums () =
    Types.Albums.GetSamples()
    |> ``print five items``

let private getPhotos () =
    Types.Photos.GetSamples()
    |> printFirst N

let run () =
    getPosts ()
    getComments ()
    getAlbums ()
    getPhotos ()
