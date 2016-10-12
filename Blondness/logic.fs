module Logic

let rec repeat whatToRepeat start numberOfRepeats =
    if numberOfRepeats > 0 then 
        let acc = whatToRepeat start 
        repeat whatToRepeat acc (numberOfRepeats - 1)
    else
        start
