module NugetProvider

open FSharp.Data
open XPlot.GoogleCharts

[<Literal>]
let LocalSamplePackage = @".\Resources\Sample.html"

[<Literal>]
let RemoteSamplePackageNUnit = "https://www.nuget.org/packages/NUnit"

[<Literal>]
let RemoteSamplePackageEntityFramework = "https://www.nuget.org/packages/EntityFramework"

[<Literal>]
let RemoteSamplePackageNewtonsoftJson = "https://www.nuget.org/packages/Newtonsoft.Json"

type NuGet = HtmlProvider<LocalSamplePackage>

let getLastVersion (nuget : NuGet) =
    nuget.Tables.``Version History``.Rows.[0]

let getSample () =
    printfn "Get NuGet package data from LOCAL source"

    let sample = NuGet.GetSample()

    printfn "LOCAL Newtonsoft.Json = %A" (sample |> getLastVersion)

let loadSample () =
    printfn "Get NuGet package data from REMOTE source"

    let nUnit = NuGet.Load RemoteSamplePackageNUnit
    let entityFramework = NuGet.Load RemoteSamplePackageEntityFramework
    let newtonsoftJson = NuGet.Load RemoteSamplePackageNewtonsoftJson

    printfn "REMOTE NUnit = %A" (nUnit |> getLastVersion)
    printfn "REMOTE Entity Framework = %A" (entityFramework |> getLastVersion)
    printfn "REMOTE Newtonsoft.Json = %A" (newtonsoftJson |> getLastVersion)

    [ nUnit; entityFramework; newtonsoftJson ]
    |> Seq.collect (fun package -> package.Tables.``Version History``.Rows)
    |> Seq.sortByDescending (fun versionHistory -> versionHistory.Downloads)
    |> Seq.take 10
    |> Seq.map (fun versionHistory -> (versionHistory.Version, versionHistory.Downloads))
    |> Chart.Column
    |> Chart.Show

let run () =
    printfn "Get NuGet package data"
    getSample ()
    loadSample ()
