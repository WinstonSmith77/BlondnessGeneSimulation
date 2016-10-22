module Bio
    open Random
    open Logic

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

        let mothers = List.take halfLenght shuffled
        let fathers = List.skip halfLenght shuffled

        let a = HowManySatisfy IsBlond mothers
        let b = HowManySatisfy IsBlond fathers

        let foldingHelper acc mother father =
            let firstChild = Breed mother father
            let acc = List.Cons (firstChild, acc)

            let secondChild = Breed mother father
            let acc = List.Cons (secondChild, acc)
            acc

        List.fold2 foldingHelper List.empty<Person> mothers fathers