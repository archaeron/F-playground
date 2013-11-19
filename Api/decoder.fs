
module PlayGround.Decoder

open PlayGround.Parser


let decode line =
    match line with
        | EmptyLine -> EmptyLine
        | DataLine(blockNumber, data) -> DataLine(blockNumber, data)