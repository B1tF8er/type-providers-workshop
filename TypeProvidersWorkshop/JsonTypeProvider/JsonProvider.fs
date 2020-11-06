module JsonProvider

open FSharp.Data

module private Urls =
    let [<Literal>] Posts =
        "https://jsonplaceholder.typicode.com/posts"

    let [<Literal>] Comments =
        "https://jsonplaceholder.typicode.com/comments"

    let [<Literal>] Albums =
        "https://jsonplaceholder.typicode.com/albums"

    let [<Literal>] Photos =
        "https://jsonplaceholder.typicode.com/photos"

module private Types =
    type Posts = JsonProvider<Urls.Posts>

    type Comments = JsonProvider<Urls.Comments>

    type Albums = JsonProvider<Urls.Albums>

    type Photos = JsonProvider<Urls.Photos>

let private print item =
    printfn "%A" item

let private getPosts () =
    Types.Posts.GetSamples()
    |> Array.take 2
    |> Array.iter print

let private getComments () =
    Types.Comments.GetSamples()
    |> Array.take 2
    |> Array.iter print

let private getAlbums () =
    Types.Albums.GetSamples()
    |> Array.take 2
    |> Array.iter print

let private getPhotos () =
    Types.Photos.GetSamples()
    |> Array.take 2
    |> Array.iter print

let run () =
    getPosts ()
    getComments ()
    getAlbums ()
    getPhotos ()
