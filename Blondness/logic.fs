module Logic

let rec Repeat whatToRepeat numberOfRepeats start  =
    if numberOfRepeats > 0 then 
        let result = whatToRepeat numberOfRepeats start
        Repeat whatToRepeat  (numberOfRepeats - 1) result
    else
        start

let HowManySatisfy pred = Seq.filter pred >> Seq.length