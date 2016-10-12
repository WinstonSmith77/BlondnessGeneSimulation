module Logic

let rec Repeat whatToRepeat start numberOfRepeats =
    if numberOfRepeats > 0 then 
        let start = whatToRepeat numberOfRepeats start
        Repeat whatToRepeat start (numberOfRepeats - 1)
    else
        start

let HowManySatisfy pred = Seq.filter pred >> Seq.length