module Random
    let generateRandom = System.Random()
    let systemRandomBool () = generateRandom.NextDouble() > 0.5  

    let pickAOrB random a b  = 
        if random()  then 
            a
        else 
            b

    let pickAOrBRandom  a b = pickAOrB systemRandomBool  a b

    let swap (array: _[]) x y=
        let tmp = array.[x]
        array.[x] <- array.[y]
        array.[y] <- tmp

    let shuffle list = 
        let array = List.toArray list
       
        let n = List.length list
        for x in 0..n-1 do
            let y = generateRandom.Next(n - x) + x
            swap array x y
        Array.toList array

   