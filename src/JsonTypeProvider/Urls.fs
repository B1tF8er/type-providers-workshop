module Urls

module Local =
    [<Literal>]
    let Posts = @".\Resources\posts.json"

    [<Literal>]
    let Comments = @".\Resources\comments.json"

    [<Literal>]
    let Albums = @".\Resources\albums.json"

    [<Literal>]
    let Photos = @".\Resources\photos.json"

module Web =
    [<Literal>]
    let Posts = "https://jsonplaceholder.typicode.com/posts"

    [<Literal>]
    let Comments = "https://jsonplaceholder.typicode.com/comments"

    [<Literal>]
    let Albums = "https://jsonplaceholder.typicode.com/albums"

    [<Literal>]
    let Photos = "https://jsonplaceholder.typicode.com/photos"
