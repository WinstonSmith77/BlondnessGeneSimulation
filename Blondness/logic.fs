module Logic

let rec repeat whatToRepeat start numberOfRepeats =
    if numberOfRepeats > 0 then 
        let start = whatToRepeat start 
        repeat whatToRepeat start (numberOfRepeats - 1)
    else
        start
