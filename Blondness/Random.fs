module Random
    open Logic

    let generateRandom = System.Random()
    let randomBool () = generateRandom.Next(2) = 0  

    let PickAOrB random a b  = 
        match random() with
        | true -> a
        | false -> b

    let PickAOrBRandom  a b = PickAOrB randomBool  a b


    let Shuffle list = 
      List.sortBy (fun _ -> generateRandom.NextDouble()) list
      

   