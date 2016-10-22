﻿module Random
    open Logic

    let generateRandom = System.Random()
    let systemRandomBool () = generateRandom.Next(2) = 0  

    let PickAOrB random a b  = 
        match random() with
        | true -> a
        | false -> b

    let PickAOrBRandom  a b = PickAOrB systemRandomBool  a b


    let Shuffle list = 
      List.sortBy (fun _ -> generateRandom.NextDouble()) list
      

   