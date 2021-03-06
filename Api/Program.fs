
// NOTE: If warnings appear, you may need to retarget this project to .NET 4.0. Show the Solution
// Pad, right-click on the project node, choose 'Options --> Build --> General' and change the target
// framework to .NET 4.0 or .NET 4.5.

module PlayGround.Main

open System
open System.IO
open PlayGround.Parser
open PlayGround.Filter
open PlayGround.Decoder


let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let printLine (line: Line) =
    match line with
    | EmptyLine -> ()
    | DataLine(blockNumber, data)
        ->
            Console.WriteLine("")
            Console.WriteLine("Block: "+blockNumber.ToString())

let parseLines (lines: seq<String>) =
     lines   |> Seq.map parseLine
            |> Seq.filter filter
            |> Seq.map decode
            |> Seq.iter printLine


[<EntryPoint>]
let main args =
    Console.WriteLine (Directory.GetCurrentDirectory())

    let lines = readLines "../../Data/data"

    let parsedLines = parseLines lines

    Console.WriteLine("Done.")
    0
