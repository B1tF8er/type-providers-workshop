module JsonProvider

open FSharp.Data
open System

module private Types =
    type Posts = JsonProvider<Urls.Local.Posts>

    type Comments = JsonProvider<Urls.Local.Comments>

    type Albums = JsonProvider<Urls.Local.Albums>

    type Photos = JsonProvider<Urls.Local.Photos>

let print () =
    Types.Posts.Load(Urls.Web.Posts)
    |> Operations.Print.``first twenty``

    Types.Comments.Load(Urls.Web.Comments)
    |> Operations.Print.``first ten``

    Types.Albums.Load(Urls.Web.Albums)
    |> Operations.Print.``first five``

    Types.Photos.Load(Urls.Web.Photos)
    |> Operations.Print.first 2

let plot () =
    let random () =
        let random = new Random()
        random.Next()

    Types.Posts.Load(Urls.Web.Posts)
    |> Seq.ofArray
    |> Seq.groupBy (fun post -> post.UserId)
    |> Seq.map (fun group -> (group |> fst, random ()))
    |> Operations.Plot.totalPostsPerUser

    Types.Comments.Load(Urls.Web.Comments)
    |> Seq.ofArray
    |> Seq.groupBy (fun commemt -> commemt.PostId)
    |> Seq.map (fun group -> (group |> fst, random ()))
    |> Operations.Plot.totalCommentsPerPost

    Types.Albums.Load(Urls.Web.Albums)
    |> Seq.ofArray
    |> Seq.groupBy (fun album -> album.UserId)
    |> Seq.map (fun group -> (group |> fst, random ()))
    |> Operations.Plot.totalAlbumsPerUser

    Types.Photos.Load(Urls.Web.Photos)
    |> Seq.ofArray
    |> Seq.groupBy (fun photo -> photo.AlbumId)
    |> Seq.map (fun group -> (group |> fst |> string, random (), random ()))
    |> Operations.Plot.photosPerAlbum

let run () =
    print ()
    plot ()
