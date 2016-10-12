module Bio
    open Random

    type Feature = Has=0 | DontHas=1 
    type Person = { GeneA : Feature ; GeneB : Feature } 

    let isBlond gene = gene.GeneA = Feature.Has && gene.GeneB = Feature.Has

    let breed mother father = {GeneA = pickAOrBRandom mother.GeneA father.GeneA; GeneB = pickAOrBRandom mother.GeneB father.GeneB}

    let create isBlond = {GeneA = isBlond; GeneB = isBlond}

    let hasBlondGenes gene = gene.GeneA = Feature.Has || gene.GeneB = Feature.Has

    let nextGeneration current =
        let halfLenght = (List.length current) /2 
        let shuffled = Random.shuffle current

        let mothers = List.take halfLenght shuffled
        let fathers = List.skip halfLenght shuffled

        let helper acc mother father =
            let firstChild = breed mother father
            let acc = List.Cons (firstChild, acc)

            let secondChild = breed mother father
            let acc = List.Cons (secondChild, acc)
            acc

        List.fold2 helper List.empty<Person> mothers fathers