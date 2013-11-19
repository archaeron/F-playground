
module PlayGround.Parser

open System

type BlockNumber = int
type Data = List<String>

type Line =
    | DataLine of BlockNumber * Data
    | EmptyLine

let hexToInt (s: String): BlockNumber =
    Convert.ToInt32(s, 16)

let split (length: int) (s: String) =
    s.[0..length-1], s.[length-1..3]

let parseLine (line: String) =
    match line with
    | "*"   -> EmptyLine
    | _     ->
        let words = Array.toList(line.Split([|' '|]))
        let block = hexToInt words.Head
        let splitted =
                words.Tail
                |> List.map split 2
                |> List.concat
        DataLine(block, words.Tail)
