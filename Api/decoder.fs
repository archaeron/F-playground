
module PlayGround.Decoder
open System
open PlayGround.Parser

let intToChar (i: int) =
    let t = System.Convert.ToChar(i)
    Console.WriteLine t

let decode line =
    match line with
        | EmptyLine -> EmptyLine
        | DataLine(blockNumber, data)
            ->
                let hs = data |> List.map (hexToInt >> intToChar)
                DataLine(blockNumber, data)