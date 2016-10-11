open System

module Random =

    let generateRandom = System.Random()
    let systemRandomBool () = generateRandom.NextDouble() > 0.5  

    let pickAOrB random a b  = 
        if random()  then 
            a
        else 
            b
    let pickAOrBRandom  a b = pickAOrB systemRandomBool  a b

module Bio=

    type BlondFeature = { GeneA : bool ; GeneB : bool } 

    let isBlond gene = gene.GeneA && gene.GeneB
    let breed mother father = {GeneA = Random.pickAOrBRandom mother.GeneA father.GeneA; GeneB = Random.pickAOrBRandom mother.GeneB father.GeneB}
    let createByGod () = {GeneA = Random.systemRandomBool(); GeneB = Random.systemRandomBool()}

  module Problem=

    let numberOfIndividuals = 1000
    let start = List.init numberOfIndividuals  (fun index -> Bio.createByGod())

    let areBlond =  List.filter Bio.isBlond start |> List.length

    let percentage = (float areBlond) / (float numberOfIndividuals)
    