module Bio
    open Random
    type BlondFeature = { GeneA : bool ; GeneB : bool } 

    let isBlond gene = gene.GeneA && gene.GeneB

    let breed mother father = {GeneA = Random.pickAOrBRandom mother.GeneA father.GeneA; GeneB = Random.pickAOrBRandom mother.GeneB father.GeneB}

    let create isBlond = {GeneA = isBlond; GeneB = isBlond}