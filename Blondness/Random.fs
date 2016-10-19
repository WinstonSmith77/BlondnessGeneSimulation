module Random
    open Logic

    let generateRandom = System.Random()
    let systemRandomBool () = generateRandom.Next(2) = 0  

    let PickAOrB random a b  = 
        match random() with
        | true -> a
        | false -> b

    let PickAOrBRandom  a b = PickAOrB systemRandomBool  a b


    let Shuffle list = 
        let swap x y (array: _[]) =
            let tmp = array.[x]
            array.[x] <- array.[y]
            array.[y] <- tmp

        let swapRandomly x array  =
             let n = Array.length array    
             let y = generateRandom.Next(n - x) + x
             swap x y array
             array

        let n = List.length list 
        let array = Repeat swapRandomly (n - 1) <| List.toArray list 
           
        Array.toList array

   