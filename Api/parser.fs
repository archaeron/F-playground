
module PlayGround.Parser

open System

type BlockNumber = int
type Data = List<String>

type Line =
    | DataLine of BlockNumber * Data
    | EmptyLine

let parseHexString (s: String): BlockNumber =
    Convert.ToInt32(s, 16)

let parseData (ws) =
    ws |> List.map parseHexString

let parseLine (line: String) =
    match line with
    | "*"   -> EmptyLine
    | _     ->
        let words = Array.toList(line.Split([|' '|]))
        let block = parseHexString words.Head
        DataLine(block, words.Tail)