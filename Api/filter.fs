
module PlayGround.Filter

open PlayGround.Parser

let filter line =
    match line with
        | EmptyLine
            -> false
        | DataLine(_)
            -> true