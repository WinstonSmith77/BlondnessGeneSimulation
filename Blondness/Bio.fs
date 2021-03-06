﻿module Bio
    open Random

    type Feature = Has=0 | DontHas=1 
    type Person = { 
        GeneA : Feature 
        GeneB : Feature 
        } 

    let IsBlond person = person.GeneA = Feature.Has && person.GeneB = Feature.Has

    let Breed mother father = {GeneA = PickAOrBRandom mother.GeneA father.GeneA; GeneB = PickAOrBRandom mother.GeneB father.GeneB}

    let CreatePerson isBlond = {GeneA = isBlond; GeneB = isBlond}

    let HasBlondGenes person = person.GeneA = Feature.Has || person.GeneB = Feature.Has

    let NextGeneration current =
        let halfLenght = (List.length current) /2 
        let shuffled = Random.Shuffle current

        let (mothers, fathers) = List.splitAt halfLenght shuffled
       
        let foldingHelper acc mother father =
            let firstChild = Breed mother father
            let acc = firstChild :: acc

            let secondChild = Breed mother father
            let acc = secondChild :: acc
            acc

        List.fold2 foldingHelper List.empty mothers fathers