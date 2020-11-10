module CsvProvider

open FSharp.Data
open XPlot.GoogleCharts

let [<Literal>] Url = @".\Resources\FootballResults.csv"

type Football = CsvProvider<Url>

let getFootballData () =
    Football.GetSample().Rows
    |> Seq.toArray

let homeTeamWinner (row : Football.Row) =
    row.``Full Time Home Goals`` > row.``Full Time Away Goals``

let homeTeam (row : Football.Row) =
    row.``Home Team``

let awayTeam (row : Football.Row) =
    row.``Home Team``

let topTenTeamsThanWonAtHome () =
    getFootballData ()
    |> Seq.filter homeTeamWinner
    |> Seq.countBy homeTeam
    |> Seq.sortByDescending snd
    |> Seq.take 10
    |> Chart.Column
    |> Chart.Show

let topFiveTeamsThatScoredTheMostGoals () =
    let homeTeamWinners =
        getFootballData ()
        |> Seq.filter homeTeamWinner
        |> Seq.countBy homeTeam

    let awayTeamWinners =
        getFootballData ()
        |> Seq.filter (not << homeTeamWinner)
        |> Seq.countBy awayTeam

    homeTeamWinners 
    |> Seq.append awayTeamWinners
    |> Seq.sortByDescending snd
    |> Seq.take 5
    |> Chart.Column
    |> Chart.Show

let runXplotExamples () =
    topTenTeamsThanWonAtHome ()
    topFiveTeamsThatScoredTheMostGoals ()

let run () =
    runXplotExamples ()
