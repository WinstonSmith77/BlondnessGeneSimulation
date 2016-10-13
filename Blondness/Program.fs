﻿// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 10000

[<Literal>]
let numberOfNonBlond = 160000

[<Literal>]
let numberIterations = 3000

[<Literal>]
let logEach = 20

let CreateFirstGeneration() = 
    let blondGuys = List.init numberOfBlond (fun index -> CreatePerson Feature.Has)
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> CreatePerson Feature.DontHas)
    List.append blondGuys nonBlondGuys

let Log length current index=
    let areBlond = HowManySatisfy IsBlond current
    
    let hasBlondGenes = HowManySatisfy HasBlondGenes current
    
    let percentageBlond = (float areBlond) / (length |> float)
    let percentageBlondGenes = (float hasBlondGenes) / (length |> float)
    printfn "Generation %A Blond %A BlondGenes %A" index percentageBlond percentageBlondGenes
    

[<EntryPoint>]
let main argv = 

    let bla = List.init 1000000 (fun index -> CreatePerson  <| PickAOrBRandom Feature.Has Feature.DontHas)
    let hasBlondGenes = HowManySatisfy HasBlondGenes bla
    let hasBlonde = HowManySatisfy IsBlond bla


    let firstGeneration = CreateFirstGeneration()
    let length = Seq.length firstGeneration

    let createNextGeneration index current = 
        let next = nextGeneration current
        if index % logEach = 0 then
            Log length next (numberIterations - index)
        next

    let lastGeneration = Repeat createNextGeneration firstGeneration numberIterations
    
    Log length lastGeneration numberIterations
    ignore(Console.ReadLine())
   
    0
