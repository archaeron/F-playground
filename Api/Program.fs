
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

module Api.Main

open System
open System.IO

type BlockNumber = String
type Data = String

type Line =
    |   DataLine of BlockNumber * Data
    |   EmptyLine

let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let printLine (line: Line) =
    match line with
    | EmptyLine -> ()
    | DataLine(blockNumber, _) -> Console.WriteLine("Data: " + blockNumber)

let parseLine (line: String) =
    match line with
    | "*"   -> EmptyLine
    | _     ->
        let words = line.Split [|' '|]
        let block: BlockNumber = words.[0]
        DataLine(block, "")

let parseLines (lines: seq<String>) =
    lines |> Seq.map parseLine
         |> Seq.iter printLine


[<EntryPoint>]
let main args = 
    Console.WriteLine (Directory.GetCurrentDirectory())

    let lines = readLines "../../Data/data"

    let parsedLines = parseLines lines

    Console.WriteLine("Hello world!")
    0

