module Random
    let generateRandom = System.Random()
    let systemRandomBool () = generateRandom.NextDouble() > 0.5  

    let pickAOrB random a b  = 
        if random()  then 
            a
        else 
            b

    let pickAOrBRandom  a b = pickAOrB systemRandomBool  a b